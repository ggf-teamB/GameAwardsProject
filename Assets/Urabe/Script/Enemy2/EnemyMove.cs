using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
//[RequireComponent(EnemyStatus)]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private LayerMask raycastLayerMask;
    private NavMeshAgent _agent;
    private RaycastHit[] _raycastHits = new RaycastHit[10];
    private EnemyStatus _status;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    /*private void Update()
    {
         _agent.destination = PlayerController.transform.position;
    }*/

    public void OnDetectObject(Collider collider)
    {
        if(!_status.IsMovable)
        {
            _agent.isStopped = true;
            return;
        }
        
        if(collider.CompareTag("Player"))
        {
            var positionDiff = collider.transform.position - transform.position;
            var distance = positionDiff.magnitude;
            var direction = positionDiff.normalized;
            //var hitCount = Physics.RaycastNonAlloc(transform.position,
               // direction, _raycastHits, distance);
            var hitCount = Physics.RaycastNonAlloc(transform.position,
            direction, _raycastHits, distance, raycastLayerMask);

            if (hitCount == 0)
            {
                _agent.isStopped = false;
                _agent.destination = collider.transform.position;

            }
            else
            {
                _agent.isStopped = true;
            }
        }
    }
}
