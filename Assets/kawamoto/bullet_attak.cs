using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_attak : MonoBehaviour
{
    void Start()
    {
        
    }

    //　コライダのIsTriggerのチェックを外し物理的な衝突をさせる場合
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<zako_Controll>().TakeDamage(100);
            Destroy(gameObject);
        }
    }
}
