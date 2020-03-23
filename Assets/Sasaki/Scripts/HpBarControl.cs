using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarControl : MonoBehaviour
{

    [SerializeField] GameObject player;     //プレイヤー
    PlayerHp playerHp;                      //PlayerHpクラス
    [SerializeField] Slider hpSlider;       //Slider
    private int hp;                         //プレイヤーの体力

    // Start is called before the first frame update
    void Start()
    {
        //PlayerHpを代入
        playerHp = player.GetComponent<PlayerHp>();

        //プレイヤーの最大体力を代入する
        hp = playerHp.maxHp;

        //Sliderのvalueの値を最大HPにする
        hpSlider.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        //nowHpにplayerHp.hpを代入する
        int nowHp = playerHp.hp;

        //SliderのvalueのnowHpにする
        hpSlider.value = nowHp;
    }
}
