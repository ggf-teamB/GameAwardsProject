using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave_X : MonoBehaviour
{
    private float limit,speed,timer;
    private bool flg;

    // Use this for initialization
    void Start()
    {
        timer = 0;
        flg = true;
        limit = 0;
        speed = 0.5f;
    }
    // Update is called once per frame
    void Update()
    {
        timer++;
        if (limit >= 0.5) flg = false;
        if (limit <= -13) flg = true;
        if (limit <= 0 || timer < 150) 
        {
            if (flg == true) speed = 0.5f;
            if (flg == false) speed = -0.5f;

            this.gameObject.transform.Translate(speed, 0, 0);
            limit += speed;
        }
        if (timer > 2000)timer = 0;
    }
}