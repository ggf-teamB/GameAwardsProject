using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Door : MonoBehaviour
{
    //表示させるメッセージエリア
    [SerializeField] GameObject message;

    //プレイヤーオブジェクト
    [SerializeField] GameObject playerObject;

    //Playerクラス
    [SerializeField] Player player;

    //システムオブジェクト
    [SerializeField] GameObject systemObject;

    //Gameクラス
    [SerializeField] Game game;

    private void Start()
    {
        //playerにPlayerクラスを代入させる
        player = playerObject.GetComponent<Player>();

        game = systemObject.GetComponent<Game>();
    }


    //イベントに参加したとき
    private void OnTriggerEnter(Collider invasion)
    {
        //Playerの時処理を行う
        if (invasion.tag == "Player")
        {
            if (player.isKey)
            {
                game.GameClear();
            }
            else
            {
                message.SetActive(true);
            }
        }
    }

    //エリアから離れたとき
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            message.SetActive(false);
        }
    }
}
