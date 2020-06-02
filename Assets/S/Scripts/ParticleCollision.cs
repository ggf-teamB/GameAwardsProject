using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public static bool ObstaclesFlg;
    public int cnt;
    private void Start()
    {
        cnt = 0;
        ObstaclesFlg = false;
    }
    private void Update()
    {
        cnt++;
        if(cnt>=10)
        {
            ObstaclesFlg = false;
            cnt = 0;
            Debug.Log("当");
        }
    }
    void OnParticleCollision(GameObject Object)
    {
        if (Object.gameObject.tag == "Enemy")
        {
            // Object.gameObject.GetComponent<zako_Controll>().TakeDamage(10);
            Destroy(gameObject);
            Debug.Log("敵に当たったよ");
        }

        if (Object.gameObject.tag == "Obstacles")
        {
            Debug.Log("浦部");
            ObstaclesFlg = true;
        }
        else
        {
            ObstaclesFlg = false;
        }

        if (Object.gameObject.tag == "Field")
        {
            Destroy(gameObject, 0.1f);
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