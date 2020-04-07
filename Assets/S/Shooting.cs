﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //弾(水)prefab
    public GameObject bullet;

    //弾(水)の複製
    public static GameObject bullets;

    //弾(水)発射点
    public Transform muzzle;

    //水発射フラグ
    public bool WaterLaunch;

    //水消費フラグ
    public static bool WaterConsumption;

    //弾(水)の速度
    public float WaterSpeed;

    //水のアニメーションスピード
    public static float WatarAnimationSpeed;

    //補給フラグ
    public bool SupplyFlg;

    //MAXフラグ
    public bool WatarMax;

    //弾(水)のチャージ
    public float charge;

    //右クリックフラグ
    private bool MouseRightFlg;

    //左クリックフラグ
    private bool MouseLeftFlg;

    //マウスの座標を記録するフラグ
    private bool chackflg;

    //感覚をあけるためのカウント
    private float cnt;

    //チェックカウント
    private float chackcnt;

    //一個目のマウス座標を取得していれる
    private Vector3 mousePosition;

    //二個目のマウス座標を取得していれる
    private Vector3 chack;

    // Use this for initialization
    void Start()
    {
        charge = 0.5f;
        bullet.transform.localScale = new Vector3(charge, charge, charge);
        WaterConsumption = false;
        WaterSpeed = 600;
        WatarAnimationSpeed = 20;
        MouseRightFlg = false;
        MouseLeftFlg = false;
        chackflg = false;
        cnt = 0;
        chackcnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //水発射フラグをUIWatarGaugeクラスから取得
        WaterLaunch = UIWatarGauge.WaterLaunch;

        //MaxフラグをUIWatarGaugeクラスから取得
        WatarMax = UIWatarGauge.WaterMax;

        //水消費フラグをShootingクラスから取得
        SupplyFlg = SupplyPoints.SupplyFlg;

        //  右クリックが押されている状態なら
        if (Input.GetMouseButtonDown(1))
        {
            MouseRightFlg = true;
        }
        //右クリックが離されている状態なら
        if (Input.GetMouseButtonUp(1))
        {
            MouseRightFlg = false;
        }
        //左クリックが押されている状態なら
        if (Input.GetMouseButtonDown(0))
        {
            MouseLeftFlg = true;
            MouseRightFlg = false;
        }
        //左クリックが離されている状態なら
        if (Input.GetMouseButtonUp(0))
        {
            MouseLeftFlg = false;
            WaterConsumption = false;
        }
        //左クリックが押された時かつ水発射フラグがtrueの時
        if (MouseLeftFlg == true && WaterLaunch == true) 
        {
            //カウントアップ
            chackcnt++;

            if (chackcnt == 5)
            {
                //弾(水)の複製
                bullets = Instantiate(bullet) as GameObject;

                Vector3 force;

                force = this.gameObject.transform.forward * WaterSpeed;

                //Rigidbodyに力を加えて発射
                bullets.GetComponent<Rigidbody>().AddForce(force);

                //弾丸の位置を調整
                bullets.transform.position = muzzle.position;

                //水消費フラグをtrueにする
                WaterConsumption = true;

                //三秒後に削除
                Destroy(bullets, 1.0f);

                //水のスピードを弱める
                WaterSpeed -= 10;

                //カウントリセット
                chackcnt = 0;
            }
        }

        //右クリックが押され続けているなら
        if (MouseRightFlg == true)
        {
            //カウントが0の時
            if (cnt == 0)
            {
                //マウスの座標を取得(Aとする)
                mousePosition = Input.mousePosition;
            }

            //カウントアップ
            cnt++;

            //カウントが10の時
            if (cnt == 10)
            {
                //マウスの座標を取得(Bとする)
                chack = Input.mousePosition;

                //マウスAとマウスBの座標を比べる。一定以上動いていればマウスを振っていると認識
                //振っているのを確認するため、chackflgがtrueだと右に振ったfalseだと左に振った
                //マウスAとマウスBは一定の間隔で座標を取得するため、cntでカウントされている

                //右に振った
                if (mousePosition.x > chack.x + 50 && 
                    chackflg == true && WaterLaunch == true ) 
                {
                    //弾チャージ
                    WaterSpeed += 100;

                    //フラグを反転
                    chackflg = false;
                }

                //左に振った
                if (mousePosition.x < chack.x - 50 &&
                    chackflg == false && WaterLaunch == true)
                {
                    //弾チャージ
                    WaterSpeed += 100;

                    //フラグを反転
                    chackflg = true;
                }

                //カウントリセット
                cnt = 0;
            }
        }

        //最遅値のアニメーションスピードを設定
        if (WatarAnimationSpeed >= 20)
        {
            WatarAnimationSpeed = 20;
        }

        //最速値のアニメーションスピードを設定
        if (WatarAnimationSpeed <= 4)
        {
            WatarAnimationSpeed = 4;
        }

        //ゲージが空になったらアニメーションと勢いの速度をリセット
        if(WaterLaunch == false)
        {
            WatarAnimationSpeed = 20;
            WaterSpeed = 400;
        }

        //チャージ上限
        if (WaterSpeed >= 2000)
        {
            WaterSpeed = 2000;
            WatarAnimationSpeed = 9;
            MouseRightFlg = false;
        }

        //チャージ加限
        if (WaterSpeed <= 400)
        {
            WaterSpeed = 400;
            WatarAnimationSpeed = 20;
        }

        //補給中は水の速度を少しずつ落としていく
        if (WatarMax == false && SupplyFlg == true) 
        {
            WaterSpeed -= 1;
        }

        //仮の処理---
        if (WaterSpeed >= 1800 && WaterSpeed < 2000) WatarAnimationSpeed = 11;
        if (WaterSpeed >= 1600 && WaterSpeed < 1800) WatarAnimationSpeed = 13;
        if (WaterSpeed >= 1400 && WaterSpeed < 1600) WatarAnimationSpeed = 15;
        if (WaterSpeed >= 1200 && WaterSpeed < 1400) WatarAnimationSpeed = 16;
        if (WaterSpeed >= 1000 && WaterSpeed < 1200) WatarAnimationSpeed = 17;
        if (WaterSpeed >= 800  && WaterSpeed < 1000) WatarAnimationSpeed = 18;
        if (WaterSpeed >= 600  && WaterSpeed <  800) WatarAnimationSpeed = 19;
        //----------
    }
}