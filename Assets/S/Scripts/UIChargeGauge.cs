using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIChargeGauge : MonoBehaviour
{
    //いじくるゲージ
    public Image ChargeGauge;

    public float countTime;

    //fillAmountの最大値
    public float Max;

    //弾(水)の速度
    public float WaterSpeed;

    // Use this for initialization
    void Start()
    {
        countTime = 5.0f;
        Max = 0;
        ChargeGauge.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //shootingから値を取得
        WaterSpeed = Shooting.WaterSpeed;

        //ゲージの変動設定
        if (Max > ChargeGauge.fillAmount)
        {
            ChargeGauge.fillAmount += 4f / countTime * Time.deltaTime;
        }
        //ゲージのガタガタを抑えるために空の処理
        else
            if (Max + 0.0005f >= ChargeGauge.fillAmount &&
                Max - 0.0005f <= ChargeGauge.fillAmount   ) 
            {

            }
            else 
                if(WaterSpeed <=1600)
                {
                    ChargeGauge.fillAmount -= 1.65f / countTime * Time.deltaTime;
                }
                else
                {
                    ChargeGauge.fillAmount -= 1.1f / countTime * Time.deltaTime;
                }

        //弾(水)との良い連動方法が思い浮かばなかったのでif文で汚いが細かく設定
        if (WaterSpeed == 2000) Max = 1f;
        if (WaterSpeed >= 1995 && WaterSpeed < 2000) Max = 0.99f;
        if (WaterSpeed >= 1990 && WaterSpeed < 1995) Max = 0.96f;
        if (WaterSpeed >= 1980 && WaterSpeed < 1990) Max = 0.93f;
        if (WaterSpeed >= 1970 && WaterSpeed < 1980) Max = 0.90f;
        if (WaterSpeed >= 1960 && WaterSpeed < 1970) Max = 0.87f;
        if (WaterSpeed >= 1950 && WaterSpeed < 1960) Max = 0.84f;
        if (WaterSpeed >= 1900 && WaterSpeed < 1950) Max = 0.81f;
        if (WaterSpeed >= 1850 && WaterSpeed < 1900) Max = 0.78f;
        if (WaterSpeed >= 1800 && WaterSpeed < 1850) Max = 0.75f;
        if (WaterSpeed >= 1750 && WaterSpeed < 1800) Max = 0.72f;
        if (WaterSpeed >  1700 && WaterSpeed < 1750) Max = 0.69f;
        if (WaterSpeed >= 1650 && WaterSpeed < 1700) Max = 0.66f;
        if (WaterSpeed >= 1600 && WaterSpeed < 1650) Max = 0.63f;
        if (WaterSpeed >= 1550 && WaterSpeed < 1600) Max = 0.60f;
        if (WaterSpeed >= 1500 && WaterSpeed < 1550) Max = 0.54f;
        if (WaterSpeed >= 1450 && WaterSpeed < 1500) Max = 0.51f;
        if (WaterSpeed >= 1400 && WaterSpeed < 1450) Max = 0.48f;
        if (WaterSpeed >= 1350 && WaterSpeed < 1400) Max = 0.45f;
        if (WaterSpeed >= 1300 && WaterSpeed < 1350) Max = 0.42f;
        if (WaterSpeed >= 1250 && WaterSpeed < 1300) Max = 0.39f;
        if (WaterSpeed >= 1200 && WaterSpeed < 1250) Max = 0.36f;
        if (WaterSpeed >= 1150 && WaterSpeed < 1200) Max = 0.33f;
        if (WaterSpeed >= 1100 && WaterSpeed < 1150) Max = 0.30f;
        if (WaterSpeed >= 1050 && WaterSpeed < 1100) Max = 0.27f;
        if (WaterSpeed >= 1000 && WaterSpeed < 1050) Max = 0.24f;
        if (WaterSpeed >= 950  && WaterSpeed < 1000) Max = 0.21f;
        if (WaterSpeed >= 900  && WaterSpeed < 950 ) Max = 0.18f;
        if (WaterSpeed >= 850  && WaterSpeed < 900 ) Max = 0.15f;
        if (WaterSpeed >= 800  && WaterSpeed < 850 ) Max = 0.12f;
        if (WaterSpeed >= 750  && WaterSpeed < 800 ) Max = 0.09f;
        if (WaterSpeed >= 700  && WaterSpeed < 750 ) Max = 0.06f;
        if (WaterSpeed >= 650  && WaterSpeed < 700 ) Max = 0.03f;
        if (WaterSpeed <= 600) Max = 0f;
        //-------------------------------------------------------
    }
}