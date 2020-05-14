using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Door : MonoBehaviour
{
    //メッセージ表示させる
    [SerializeField] GameObject message;

    //イベントに参加したとき
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            message.SetActive(true);
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
