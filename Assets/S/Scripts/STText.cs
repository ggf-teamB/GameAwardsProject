using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class STText : MonoBehaviour
{
    //システムオブジェクト
    [SerializeField] GameObject systemObject;

    //メッセージマネージャークラス
    [SerializeField] MessageManager mManager;

    private int cnt;

    [SerializeField] private bool flg;
    public bool Flg
    {
        get { return this.flg; }
    }
    public bool fg;
    private string[] ST01 = new string[12];
    private string[] ST02 = new string[2];
    private string[] ST03 = new string[2];

    private void Start()
    {
        ST01[0] = "～チュートリアル説明～   右クリックで進む／左クリックで戻る";
        ST01[1] = "「 移動 」\nＷＳＡＤキーで上下左右に\n移動することが出来ます。";
        ST01[2] = "「 チャージ 」\nマウスを右クリックしたまま、\n左右に振ることによって\n右下に青色のゲージが溜まります。";
        ST01[3] = "「 発射 」\nマウスの左クリックで\n炭酸を発射することが出来ます。";
        ST01[4] = "「 補充 」\n水がある場所に行けば\nＵｎｉｔｙちゃんオリジナルの銃が\n  自動で水を補充してくれます。";
        ST01[5] = "「 ポーズメニュー 」\nＥＳＣキーで開くことができ、\nここで設定を変更することが出来ます。";
        ST01[6] = "\n\n以上でチュートリアル説明終了です。";
        ST01[7] = "\n\n～ストーリー～";
        ST01[8] = "\n Ｕｎｉｔｙちゃんの大事な\n炭酸に合う食べ物が\n暴食なドラゴンに奪われてしまいました";
        ST01[9] = "\n取り戻すため、\n暴食なドラゴンの手下とともに\n懲らしめてやりましょう。";
        ST01[10] = "\n道具作成が趣味の\nＵｎｉｔｙちゃんは水を炭酸に変換する銃を作成していました。";
        ST01[11] = "\nそれを試すため炭酸に合う食べ物を\n用意していたのです。";

        ST02[0] = "\n暴食なドラゴンは\nさらに奥の場所にいるようです。";
        ST02[1] = "\n襲いかかってくる手下を返り討ちにして\n暴食なドラゴンを追い詰めましょう。";

        ST03[0] = "\n暴食なドラゴンは素直に返す素振りを見せないため、";
        ST03[1] = "\n実力行使でやるしかないようです。懲らしめてやりましょう。";


        cnt = 0;
        flg = true;
        mManager = systemObject.GetComponent<MessageManager>();
    }

    private void Update()
    {
        fg = Flg;
        if (Input.GetMouseButtonUp(0) && flg == true) cnt += 1;

        if (Input.GetMouseButtonUp(1) && flg == true) cnt -= 1;

        if (cnt <= 0) cnt = 0;
        //関数分けすればよかった
        if (SceneManager.GetActiveScene().name == "Game_St01")
        {
            Debug.Log("01");
            if (flg == true)
            {
                switch (cnt)
                {
                    case 0:
                        mManager.SetTutorialMessage(ST01[cnt]);
                        break;
                    case 1:
                        mManager.SetTutorialMessage(ST01[cnt]);
                        break;
                    case 2:
                        mManager.SetTutorialMessage(ST01[cnt]);
                        break;
                    case 3:
                        mManager.SetTutorialMessage(ST01[cnt]);
                        break;
                    case 4:
                        mManager.SetTutorialMessage(ST01[cnt]);
                        break;
                    case 5:
                        mManager.SetTutorialMessage(ST01[cnt]);
                        break;
                    case 6:
                        mManager.SetTutorialMessage(ST01[cnt]);
                        break;
                    case 7:
                        mManager.SetTutorialMessage(ST01[cnt]);
                        break;
                    case 8:
                        mManager.SetTutorialMessage(ST01[cnt]);
                        break;
                    case 9:
                        mManager.SetTutorialMessage(ST01[cnt]);
                        break;
                    case 10:
                        mManager.SetTutorialMessage(ST01[cnt]);
                        break;
                    case 11:
                        mManager.SetTutorialMessage(ST01[cnt]);
                        break;

                    default:
                        mManager.HiddenTutorial();
                        flg = false;
                        break;
                }
            }
        } 
        else if (SceneManager.GetActiveScene().name == "Game_St02")
        {
            Debug.Log("02");
            if (flg == true)
            {
                switch (cnt)
                {

                    case 0:
                        mManager.SetTutorialMessage(ST02[cnt]);
                        break;
                    case 1:
                        mManager.SetTutorialMessage(ST02[cnt]);
                        break;

                    default:
                        mManager.HiddenTutorial();
                        flg = false;
                        break;
                }
            }
        } 
        else if (SceneManager.GetActiveScene().name == "Game_St03")
        {
            Debug.Log("03");
            if (flg == true)
            {
                switch (cnt)
                {
                    case 0:
                        mManager.SetTutorialMessage(ST03[cnt]);
                        break;
                    case 1:
                        mManager.SetTutorialMessage(ST03[cnt]);
                        break;

                    default:
                        mManager.HiddenTutorial();
                        flg = false;
                        break;
                }
            }
        }
    }
}
