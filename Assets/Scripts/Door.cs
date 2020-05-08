using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //メッセージ表示させる
    [SerializeField] GameObject message;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            Instantiate(message);

            Debug.Log("今日のごはんは浦部とリューロウの和え物");
        }
    }
}
