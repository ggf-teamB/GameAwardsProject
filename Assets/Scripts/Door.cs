using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Door : MonoBehaviour
{
    //メッセージ表示させる
    [SerializeField] GameObject message;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            message.SetActive(true);

            Debug.Log("今日のごはんは浦部とリューロウの和え物");
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
