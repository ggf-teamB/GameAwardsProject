using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MovingObstacles : MonoBehaviour
{
    [SerializeField] private GameObject Pot;

    private EyeChange pt;

    public bool flg;

    public Vector3 force;

    void Start()
    {
        pt = Pot.GetComponent<EyeChange>();
    }
    // Update is called once per frame
    void Update()
    {
        flg = ParticleCollision.ObstaclesFlg;
        force = Shooting.force / 10;
        if (flg == true)
        {
            //Rigidbodyに力を加えて発射
            this.GetComponent<Rigidbody>().AddForce(force,ForceMode.Force);
            pt.ChangeStateToHold();
        }
        else
        {
            //Rigidbodyに力を加えて発射
            this.GetComponent<Rigidbody>().AddForce(0f,0f,0f);
            pt.Hold();
        }
    }
}