using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Door : MonoBehaviour
{
    //プレイヤーオブジェクト
    [SerializeField] GameObject playerObject;

    //Playerクラス
    [SerializeField] Player player;

    //システムオブジェクト
    [SerializeField] GameObject systemObject;

    //メッセージマネージャークラス
    [SerializeField] MessageManager mManager;

    //Gameクラス
    [SerializeField] Game game;

    private string notKeyMessage = "この扉を開けるには鍵が必要なのだ！";

    private void Start()
    {
        //playerにPlayerクラスを代入させる
        player = playerObject.GetComponent<Player>();

        mManager = systemObject.GetComponent<MessageManager>();

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
                mManager.SetMessage(notKeyMessage);
            }
        }
    }

    //エリアから離れたとき
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            mManager.SetHidden();
        }
    }
}
