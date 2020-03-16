using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerController playerController;
    private NavMeshAgent _agent;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>(); //NavMeshAgentを保持しておく
    }

    // Update is called once per frame
    private void Update()
    {
        _agent.destination = playerController.transform.position;
    }
}
