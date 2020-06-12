using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//壁君が水に当たった時の動きとか目の挙動とか
public class MovingObstacles : MonoBehaviour
{
    [SerializeField] private GameObject Pot;

    [SerializeField] private CountDownHP.zako_status hp;
    private int maxhp;
    private EyeChange pt;
    private int cnt;

    private AudioSource break_wall;

    //ドカンのフラグ
    private bool break_triger;

    [SerializeField] private bool flg;
    public bool Flg
    {
        get { return this.flg; }
    }

    private Vector3 force;

    private float x;

    void Start()
    {
        pt = Pot.GetComponent<EyeChange>();
        flg = false;
        maxhp = hp.HP;

        break_triger = false;
        break_wall = gameObject.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (flg == false) pt.Unknowm_eye();
        //対象のローテーションを取得する
        Vector3 _Rotation = gameObject.transform.localEulerAngles;
        x = _Rotation.x;
        force = Shooting.force / 50;

        if (x >= 45)
        {
            //目の描画を変える
            flg = true;
        }
        if (maxhp / 10 * 7 < hp.HP)
        {
            if (flg == true) pt.Normal_eye();
        }
        else
        if (maxhp / 10 * 8 > hp.HP && maxhp / 10 * 3 < hp.HP)
        {
            if (flg == true) pt.Tears_eye();
        }
        else
        if (maxhp / 10 * 4 > hp.HP)
        {
            if (flg == true) pt.Damage_eye();
        }
    }
    //当たり判定を記述するとこ
    void OnParticleCollision(GameObject Object)
    {
        //弾(水)と当たったら
        if (Object.gameObject.tag == "bullet")
        {
            //力を加えて突き飛ばす
            this.GetComponent<Rigidbody>().AddForce(force, ForceMode.Force);

            if (!break_triger)
            {
                break_triger = true;
                //壁ぶっ飛ぶ時SE
                break_wall.Play();

            }

            //目の描画を変える
            if (flg == true) pt.Damage_eye();
            flg = true;
        }
        else
        {
            //力を加えて突き飛ばす
            this.GetComponent<Rigidbody>().AddForce(0f, 0f, 0f);
            //目の描画を変える
            if (flg == true) pt.Normal_eye();
        }
    }
}