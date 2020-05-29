using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class StoryText_ST03 : MonoBehaviour
{
    //システムオブジェクト
    [SerializeField] GameObject systemObject;

    //メッセージマネージャークラス
    [SerializeField] MessageManager mManager;

    private int cnt;
    private bool flg;
    public bool Flg { get { return this.flg; } }
    private string Message0 = "\n暴食なドラゴンは\n素直に返す素振りを見せないため";
    private string Message1 = "\n実力行使でやるしかないようです。\n懲らしめてやりましょう。";
    private void Start()
    {
        cnt = 0;
        flg = true;
        mManager = systemObject.GetComponent<MessageManager>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && flg == true)
        {
            cnt += 1;
        }

        if (flg == true)
        {
            switch (cnt)
            {
                case 0:
                    mManager.SetTutorialMessage(Message0);
                    break;
                case 1:
                    mManager.SetTutorialMessage(Message1);
                    break;
                default:
                    mManager.HiddenTutorial();
                    flg = false;
                    break;
            }
        }
    }
}