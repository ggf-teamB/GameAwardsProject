using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Door : MonoBehaviour
{
    //表示させるメッセージエリア
    [SerializeField] GameObject message;

    [SerializeField] GameObject playerObject;

    [SerializeField] Player player;

    private void Start()
    {
        //playerにPlayerクラスを代入させる
        player = playerObject.GetComponent<Player>();
    }


    //イベントに参加したとき
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(player.isKey == false)
            {
                message.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            message.SetActive(false);
        }
    }
}
