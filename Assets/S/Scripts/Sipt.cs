using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            float s = Random.Range(-WaterSpeed, WaterSpeed);
            pos.x+=s; ;
            GetComponent<RectTransform>().anchoredPosition = pos;
            flg = false;
        }

        if (flg == false)
        {
            float s = Random.Range(-WaterSpeed, WaterSpeed);
            pos.y += s;
            GetComponent<RectTransform>().anchoredPosition = pos;
            flg = true;
        }

        if(cnt>10)
        {
            pos.x = x;
            pos.y = y;
            GetComponent<RectTransform>().anchoredPosition = pos;
            cnt = 0 ;
        }
    }
}
