using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    void OnParticleCollision(GameObject Object)
    {
        if (Object.gameObject.tag == "Enemy")
        {
           // Object.gameObject.GetComponent<zako_Controll>().TakeDamage(10);
            Destroy(gameObject);
            Debug.Log("敵に当たったよ");
        }
       


        if (Object.gameObject.tag == "Field")
        {
            Destroy(gameObject,0.1f);
            Debug.Log("地面との濃厚接触");
        }
    }
    void OnCollisionExit(Collision urabe)
    {
        if (urabe.gameObject.tag == "Enemy")
        {
            urabe.gameObject.GetComponent<zako_Controll>().TakeDamage(0);
            Debug.Log("当たらなくなったよ");
        }
    }
}
