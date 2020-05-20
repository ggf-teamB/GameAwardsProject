using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    //メッセージUI
    [SerializeField] private GameObject messageUI;

    //メッセージを表示するかどうか
    [SerializeField] private bool isMessage;

    //非表示タイマー
    [SerializeField] private float hiddenTime;

    //表示するテキスト
    private Text messgaeText;

    //非表示にする秒数
    private const float hidden = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //テキストを代入する
        messgaeText = messageUI.GetComponentInChildren<Text>();
        messgaeText.text = "";

        //初期化
        isMessage = false;
        hiddenTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //メッセージを表示してるとき
        if (isMessage == true)
        {
            //タイマーがhiddenを超えたとき
            if (hiddenTime > hidden)
            {
                messageUI.SetActive(false);
                hiddenTime = 0f;
                isMessage = false;
            }

            hiddenTime += Time.deltaTime;
        }
    }

    //テキストをセットする
    public void SetMessage(string message)
    {
        messageUI.SetActive(true);

        messgaeText.text = message;

        isMessage = true;
    }

    public void SetHidden()
    {
        messageUI.SetActive(false);

        isMessage = false;

        hiddenTime = 0f;
    }
}