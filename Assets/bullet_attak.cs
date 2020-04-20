using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_attak : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter(Collision col)
        {
            if(col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<zako_Controll>().TakeDamage(100);
                Destroy(gameObject);
                Debug.Log("aaaaaaa");
            }
        }
    }
}
