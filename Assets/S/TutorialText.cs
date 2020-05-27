using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    //システムオブジェクト
    [SerializeField] GameObject systemObject;

    //メッセージマネージャークラス
    [SerializeField] MessageManager mManager;

    private int cnt;
    private bool flg;
    public bool Flg { get { return this.flg; } }
    private string Message0 = "～チュートリアル説明～   右クリックで進む／左クリックで戻る";
    private string Message1 = "「 移動 」\nＷＳＡＤキーで上下左右に\n移動することが出来ます。";
    private string Message2 = "「 チャージ 」\nマウスの右クリックしたまま、\n左右に振ることによって\n右下に青色のゲージが溜まります。";
    private string Message3 = "「 発射 」\nマウスの左クリックで\n炭酸を発射することが出来ます。";
    private string Message4 = "「 補充 」\n水がある場所に行けば\nＵｎｉｔｙちゃんオリジナルの銃が\n  自動で水を補充してくれます。";
    private string Message5 = "「 ポーズメニュー 」\nＥＳＣキーで開くことができ、\nここで設定を変更することが出来ます。";
    private string Message6 = "\n以上でチュートリアル説明終了です。";
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

        if (Input.GetMouseButtonUp(1) && flg == true)
        {
            cnt -= 1;
        }
        if (cnt <= 0)
        {
            cnt = 0;
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
                case 2:
                    mManager.SetTutorialMessage(Message2);
                    break;
                case 3:
                    mManager.SetTutorialMessage(Message3);
                    break;
                case 4:
                    mManager.SetTutorialMessage(Message4);
                    break;
                case 5:
                    mManager.SetTutorialMessage(Message5);
                    break;
                case 6:
                    mManager.SetTutorialMessage(Message6);
                    break;
                default:
                    mManager.HiddenTutorial();
                    flg = false;
                    break;
            }
        }
    }
}