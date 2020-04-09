using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIWatarGauge : MonoBehaviour
{
    //いじくるゲージ
    public Image WatarGauge;

    //満タンで5秒発射できる設定
    public float countTime;

    //水発射フラグ
    public static bool WaterLaunch;

    //水消費フラグ
    public bool WaterConsumption;

    //MAXフラグ
    public static bool WaterMax;

    //補給フラグ
    public bool SupplyFlg;

    // Use this for initialization
    void Start()
    {
        countTime = 5.0f;
        WaterLaunch = true;
        WaterMax = false;
    }

    // Update is called once per frame
    void Update()
    {
        //水消費フラグをShootingクラスから取得
        WaterConsumption = Shooting.WaterConsumption;

        //水消費フラグをShootingクラスから取得
        SupplyFlg = SupplyPoints.SupplyFlg;

        //水消費フラグがtrueなら
        if (WaterConsumption)
        {
            //ゲージが減る処理
            WatarGauge.fillAmount -= 1.0f / countTime * Time.deltaTime;
        }

        //ゲージが空になったら
        if (WatarGauge.fillAmount == 0)
        {
            //水発射フラグをfalseにする
            WaterLaunch = false;
        }
        else
        {
            //水発射フラグをtrueにする
            WaterLaunch = true;
        }

        if(WatarGauge.fillAmount == 1)
        {
            WaterMax = true;
        }
        else
        {
            WaterMax = false;
        }

        //flgがtrueなら
        if (SupplyFlg == true)
        {
            //ゲージが増える処理
            WatarGauge.fillAmount += 0.75f / countTime * Time.deltaTime;
        }
    }
}