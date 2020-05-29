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
    private bool fg;
    [SerializeField] private bool flg;
    public bool Flg
    {
        get { return this.flg; }
    }
    private string Message0 = "～チュートリアル説明～   右クリックで進む／左クリックで戻る";
    private string Message1 = "「 移動 」\nＷＳＡＤキーで上下左右に\n移動することが出来ます。";
    private string Message2 = "「 チャージ 」\nマウスを右クリックしたまま、\n左右に振ることによって\n右下に青色のゲージが溜まります。";
    private string Message3 = "「 発射 」\nマウスの左クリックで\n炭酸を発射することが出来ます。";
    private string Message4 = "「 補充 」\n水がある場所に行けば\nＵｎｉｔｙちゃんオリジナルの銃が\n  自動で水を補充してくれます。";
    private string Message5 = "「 ポーズメニュー 」\nＥＳＣキーで開くことができ、\nここで設定を変更することが出来ます。";
    private string Message6 = "\n\n以上でチュートリアル説明終了です。";
    private string Message7 = "\n\n～ストーリー～";
    private string Message8 = "\n Ｕｎｉｔｙちゃんの大事な\n炭酸に合う食べ物が\n暴食なドラゴンに奪われてしまいました";
    private string Message9 = "\n取り戻すため、\n暴食なドラゴンの手下とともに\n懲らしめてやりましょう。";
    private string Message10 = "\n道具作成が趣味の\nＵｎｉｔｙちゃんは水を炭酸に変換する銃を作成していました。";
    private string Message11 = "\nそれを試すため炭酸に合う食べ物を\n用意していたのです。";

    private void Start()
    {
        cnt = 0;
        flg = true;
        mManager = systemObject.GetComponent<MessageManager>();
    }
    private void Update()
    {
        fg=Flg;
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
                case 7:
                    mManager.SetTutorialMessage(Message7);
                    break;
                case 8:
                    mManager.SetTutorialMessage(Message8);
                    break;
                case 9:
                    mManager.SetTutorialMessage(Message9);
                    break;
                case 10:
                    mManager.SetTutorialMessage(Message10);
                    break;
                case 11:
                    mManager.SetTutorialMessage(Message11);
                    break;
                default:
                    mManager.HiddenTutorial();
                    flg = false;
                    break;
            }
        }
    }
}