using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyStatus))]
public class enemSlimemove : MonoBehaviour
{
    public float speed = 1f; 　　　　　//徘徊してるときの敵の速さ
    public float rotationspeed = 1f; 　//徘徊途中の方向転換で、体を目標位置に向ける回転速度
    public float posrange = 10f;       //ランダムで目標位置を決めるときの範囲
    private Vector3 targetpos;         //目標位置の位置（具体的な座標）
    private float changetarget = 50f;  //方向転換
    public float targetdistance;       //目標位置までの距離

    //ランダムの目標位置を決める
    Vector3 GetRandomPosition(Vector3 currentpos)
    {
        return new Vector3(Random.Range(-posrange + currentpos.x, posrange + currentpos.x), 0, Random.Range(-posrange + currentpos.z, posrange + currentpos.z));
    }

    //ただ徘徊するだけ
    void haikai()
    {
        if (targetdistance < changetarget) targetpos = GetRandomPosition(transform.position);

        Quaternion targetRotation = Quaternion.LookRotation(targetpos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationspeed);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //Debug.Log("haikai");
    }

    private NavMeshAgent _agent;
    private RaycastHit[] _raycastHits_raycastHits = new RaycastHit[10];
    private EnemyStatus _status;

    private void Start()
    {
        targetpos = GetRandomPosition(transform.position);
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        targetdistance = Vector3.SqrMagnitude(transform.position - targetpos);
        haikai();
        //_agent.destination = Player.transform.position;
    }

    //CollisionDetectorのonTriggerStayにセットし、衝突判定を起こす
    public void OnDetectObject(Collider collider)
    {
        if(!_status.IsMovable)
        {
            _agent.isStopped = true;
            return;
        }

        //検知したオブェクトに「player」のタグがついていれば、そのオブェクトを追いかける
        if(collider.CompareTag("Player"))
        {
            //自身とプレイヤーの座標差分を計算
            var positionDiff = collider.transform.position - transform.position;

            //プレイヤーとの距離を計算
            var distance = positionDiff.magnitude;

            //プレイヤーへの方向
            var direction = positionDiff.normalized;

            //_raycastHitsに、ヒットしたCollderや座標情報の格納
            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits_raycastHits, distance);
            Debug.Log("hitCount:" + hitCount);
            if (hitCount == 0)
            {
                //ヒット数が0であればプレイヤーとの間に障害物がない
                _agent.isStopped = false;
                _agent.destination = collider.transform.position;
            }
            else
            {
                //見失ったら停止する
                _agent.isStopped = true;
            }
        }
    }
}
