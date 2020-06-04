using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyStatus))]
public class Rabbit_Move : MonoBehaviour
{
    [SerializeField] private LayerMask raycastLayerMask;

    private NavMeshAgent _agent;
    private RaycastHit[] _raycastHits = new RaycastHit[10];
    private EnemyStatus _status;
    public Transform[] points;
    private int destPoint = 0;

    public void Start()
    {
        _agent = GetComponent<NavMeshAgent>();  //NavMeshAgentの情報をagentに代入
        _status = GetComponent<EnemyStatus>();

        // autoBraking を無効にすると、目標地点の間を継続的に移動します
        //(つまり、エージェントは目標地点に近づいても
        // 速度をおとしません)
        _agent.autoBraking = false;

        destPoint = Random.Range(0, points.Length);

        GotoNextPoint();

    }

    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときに返します
        if (points.Length == 0)
            return;

        // エージェントが現在設定された目標地点に行くように設定します
        _agent.destination = points[destPoint].position;

        // 配列内の次の位置を目標地点に設定し、
        // 必要ならば出発地点にもどります
        destPoint = (destPoint + 1) % points.Length;
    }

    public void Update()
    {
        // エージェントが現目標地点に近づいてきたら、
        // 次の目標地点を選択します
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            GotoNextPoint();
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
            else
            {
                //見失ったら停止する
                _agent.isStopped = true;
            }
        }
    }
}

