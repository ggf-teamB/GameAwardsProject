using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    // bullet prefab
    public GameObject bullet;

    // 弾丸発射点
    public Transform muzzle;

    // 弾丸の速度
    public float speed = 600;

    public float charge= 0.5f;

    private bool flg = false;
    private bool bflg = false;
    private bool chackflg = false;
    private float cnt = 0;
    private float bcnt = 0;

    private Vector3 chack;
    private Vector3 mousePosition;


    // Use this for initialization
    void Start()
    {
        bullet.transform.localScale = new Vector3(charge, charge, charge);
        speed = 600;
}

    // Update is called once per frame
    void Update()
    {
        //  右クリックが押されている状態なら
        if (Input.GetMouseButtonDown(1))
        {
            flg = true;
        }
        //  右クリックが離されている状態なら
        if (Input.GetMouseButtonUp(1))
        {
            flg = false;
        }
        //  右クリックが押されている状態なら
        if (Input.GetMouseButtonDown(0))
        {
            bflg = true;
            flg = false;
        }
        //  右クリックが離されている状態なら
        if (Input.GetMouseButtonUp(0))
        {
            bflg = false;
        }
        // 左クリックが押された時
        if (bflg == true) 
        {
            bcnt++;
            if (bcnt == 5)
            {
                // 弾丸の複製
                GameObject bullets = Instantiate(bullet) as GameObject;

                Vector3 force;

                force = this.gameObject.transform.forward * speed;

                // Rigidbodyに力を加えて発射
                bullets.GetComponent<Rigidbody>().AddForce(force);

                // 弾丸の位置を調整
                bullets.transform.position = muzzle.position;

                // 三秒後に削除
                Destroy(bullets, 1.0f);
                speed -= 10;
                bcnt = 0;
            }
        }
        // 右クリックが押され続けているなら
        if (flg == true)
        {
            // カウント
            if (cnt == 0)
            {
                // マウスの座標を取得(Aとする)
                mousePosition = Input.mousePosition;
            }
            // カウントアップ
            cnt++;

            if (cnt == 10)
            {
                // マウスの座標を取得(Bとする)
                chack = Input.mousePosition;

                // マウスAとマウスBの座標を比べる一定以上動いていればマウスを振っていると認識
                // 振っているのを確認するため、chackflgがtrueだと右に振ったfalseだと左に振った
                // マウスAとマウスBは一定の間隔で座標を取得するため、cntでカウントされている

                //右に振った
                if (mousePosition.x > chack.x + 50 && chackflg == true) 
                {
                    // 弾チャージ
                    speed += 100;

                                        // フラグを反転
                                        chackflg = false;
                }

                //左に振った
                if (mousePosition.x < chack.x - 50 && chackflg == false)
                {
                    // 弾チャージ
                    speed += 100;

                    // フラグを反転
                    chackflg = true;
                }
                // カウントリセット
                cnt = 0;
            }
        }

        // チャージ上限
        if (speed >= 2000)
        {
            speed = 2000;
        }
        // チャージ上限
        if (speed <= 400)
        {
            speed = 400;
        }
    }
}