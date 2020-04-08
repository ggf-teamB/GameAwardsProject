using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMoob : MonoBehaviour
{

    [SerializeField] private GameObject enemyObj;

    private Enemy enemy;

    private void Start()
    {
        enemy = enemyObj.GetComponent<Enemy>();
    }

    //当たってるとき
    private void OnTriggerStay(Collider hit)
    {
        if(hit.tag == "Player")
        {
            Debug.Log("当たり");
            enemy.AreaIntrusion_SetState();
        }
    }

    //当たってないとき
    private void OnTriggerExit(Collider notHit)
    {
        if(notHit.tag == "Player")
        {
            Debug.Log("当たってない");
            enemy.AreaLeaving_SetState();
        }
    }
}
