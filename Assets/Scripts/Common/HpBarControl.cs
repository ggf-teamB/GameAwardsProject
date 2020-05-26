using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarControl : MonoBehaviour
{
    //プレイヤーのオブジェクト
    [SerializeField] private GameObject playerObj;

    //プレイヤークラス
    [SerializeField] private Player player;

    //HPバーのスライダー
    [SerializeField] private Slider hpBer;

    //HPバーの適用体力
    private int hp;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤークラスを代入
        player = playerObj.GetComponent<Player>();

        //プレイヤーの最大体力を代入する
        hp = player.MaxHp;

        //HPバーのvalueに最大体力を適用
        hpBer.value = hp;

        Debug.Log(hp);
    }

    // Update is called once per frame
    void Update()
    {
        //現在の体力をプレイヤークラスから取得する
        int nowHp = player.Durability;

        //HPバーに現在の体力を反映させる
        hpBer.value = nowHp;
    }
}
