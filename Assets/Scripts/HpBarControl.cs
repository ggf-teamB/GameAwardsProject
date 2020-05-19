using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarControl : MonoBehaviour
{

    [SerializeField] GameObject player;     //プレイヤー
    MobStatus LifeMax;                        //PlayerHpクラス
    [SerializeField] Slider hpSlider;       //Slider
    private float hp;                         //プレイヤーの体力

    // Start is called before the first frame update
    void Start()
    {
        //PlayerHpを代入
        LifeMax = player.GetComponent<MobStatus>();

        //プレイヤーの最大体力を代入する
        hp = LifeMax._life;

        //Sliderのvalueの値を最大HPにする
        hpSlider.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        //nowHpにplayerHp.hpを代入する
        float nowHp = LifeMax._life;

        //SliderのvalueのnowHpにする
        hpSlider.value = nowHp;
    }
}
