using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyStatus))]
public class DragonMove : MonoBehaviour
{
    [SerializeField] private LayerMask raycastLayerMask;
    //[SerializeField] private float Speed = 3;

    public Vector3[] wayPoints = new Vector3[3];   //徘徊するポイントの座標を代入するVector3型の変数を配列で作る
    private int currentRoot;                       //現在目指すポイントを代入する変数
    private NavMeshAgent _agent;
    private RaycastHit[] _raycastHits = new RaycastHit[10];
    private EnemyStatus _status;
    private int Mode;                             //敵の行動パターンを分けるための変数
    public Transform player;                      //プレイヤーの位置を取得するためのTransform型の変数
    public Transform enemypos;                   //敵の位置を取得するためのTransform型の変数

    public void Start()
    {
        _agent = GetComponent<NavMeshAgent>();  //NavMeshAgentの情報をagentに代入
        _status = GetComponent<EnemyStatus>();
    }

    //CollisionDetectorのonTriggerStayにセットし、衝突判定を起こす
    public void OnDetectObject(Collider collider)
    {
        if (!_status.IsMovable)
        {
            _agent.isStopped = true;
            return;
        }

        //検知したオブェクトに「player」のタグがついていれば、そのオブェクトを追いかける
        if (collider.CompareTag("Player"))
        {
            //自身とプレイヤーの座標差分を計算
            var positionDiff = collider.transform.position - transform.position;

            //プレイヤーとの距離を計算
            var distance = positionDiff.magnitude;

            //プレイヤーへの方向
            var direction = positionDiff.normalized;

            //_raycastHitsに、ヒットしたCollderや座標情報の格納
            var hitCount = Physics.RaycastNonAlloc(transform.position,
           direction, _raycastHits, distance, raycastLayerMask);

            Debug.Log("hitCount:" + hitCount);

            if (hitCount == 0)
            {
                //ヒット数が0であればプレイヤーとの間に障害物がない
                _agent.isStopped = false;
                _agent.destination = collider.transform.position;
            }
            /*else
            {
                //見失ったら停止する
                _agent.isStopped = true;
            }*/
        }
    }
}
