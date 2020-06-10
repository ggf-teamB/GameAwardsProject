using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//チャ－ジしたら水のUIゲージをガタガタ震わせる処理をするよ
public class Sipt : MonoBehaviour
{
    Vector2 pos;

    int cnt = 0;
    float x, y;
    bool flg;
    //弾(水)の速度
    public float WaterSpeed;

    // Start is called before the first frame update
    void Start()
    {
        pos= GetComponent<RectTransform>().anchoredPosition;
        flg = false;
        cnt = 0;
        x = pos.x;
        y = pos.y;
    }
    // Update is called once per frame
    void Update()
    {
        //shootingから値を取得
        WaterSpeed = Shooting.WaterSpeed/1000;
        if (WaterSpeed <= 1) WaterSpeed = 0;
         cnt++;

        if (flg == true)
        {
            //ランダムな数字を取得
            float s = Random.Range(-WaterSpeed, WaterSpeed);
            //現在の水のUIの座標に取得したランダムな数値を足す x方面に
            pos.x += s;
            //現在のUIを表示
            GetComponent<RectTransform>().anchoredPosition = pos;
            flg = false;  //falseの処理へ
        }

        if (flg == false)
        {
            //ランダムな数字を取得
            float s = Random.Range(-WaterSpeed, WaterSpeed);
            //現在の水のUIの座標に取得したランダムな数値を足す y方面に
            pos.y += s;
            //現在のUIを表示
            GetComponent<RectTransform>().anchoredPosition = pos;
            flg = true;   //trueの処理へ
        }

        //カウント10いったら初期値にリセット
        if(cnt>10)
        {
            pos.x = x;
            pos.y = y;
            GetComponent<RectTransform>().anchoredPosition = pos;
            cnt = 0 ;
        }
    }
}
