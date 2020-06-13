using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    //public　private
    public float limit, speed;
    public int timer;
    public bool flg;
    BoxCollider box;
    // Use this for initialization
    void Start()
    {
        timer = 0;
        flg = true;
        limit = 0;
        speed = 0.5f;
        box = GetComponent<BoxCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        timer++;
        if (limit >= 0.5) flg = false;
        if (limit <= -13) flg = true;
        if (limit <= 0 || timer < 20)
        {
            if (flg == true) speed = 0.5f;
            if (flg == false) speed = -0.5f;

            this.gameObject.transform.Translate(-speed, 0, 0);
            limit += speed;
        }

        if (timer >= 60)
        {

            box.center = new Vector3(6, 0, 0);
            box.size = new Vector3(16, 2, 2);
        }
        if (timer >= 400)
        {
            box.center = new Vector3(0, 0, 0);
            box.size = new Vector3(2, 2, 2);
        }
        if (timer > 1000)
        {
            timer = 0;
        }
    }
}