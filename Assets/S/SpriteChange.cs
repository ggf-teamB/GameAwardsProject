using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UI処理のクラスを使用する宣言
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    //Image コンポーネントを格納する変数
    private Image m_Image;

    //スプライトオブジェクトを格納する配列
    public Sprite[] m_Sprite;

    //水のアニメーションスピード
    public float WatarAnimationSpeed;

    //アニメーション画像の番号
    int number;

    //アニメーションのスピード用タイマー
    int timer;

    //ゲーム開始時に実行する処理
    void Start()
    {
        //Image コンポーネントを取得して変数 m_Image に格納
        m_Image = GetComponent<Image>();

        number = 0;
        timer = 0;
    }

    //ゲーム実行中に毎フレーム実行する処理
    void Update()
    {
        //shootingから値を取得
        WatarAnimationSpeed = Shooting.WatarAnimationSpeed;

        //カウントアップ
        timer++;

        //一定までカウントしたら画像を切り替える
        if (timer >= WatarAnimationSpeed) 
        {
            number++;

            //タイマーリセット
            timer = 0;
        }
        //画像の枚数分まで超えたら0に戻す
        if (number == 19) 
        {
            number = 0;
        }
        //アニメーション再生番号
        switch(number)
        {
            case 0:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[0] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[0];
                break;

            case 1:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[1] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[1];
                break;

            case 2:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[2] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[2];
                break;

            case 3:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[3] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[3];
                break;

            case 4:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[4] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[4];
                break;

            case 5:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[5] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[5];
                break;

            case 6:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[6] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[6];
                break;

            case 7:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[7] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[7];
                break;

            case 8:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[8] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[8];
                break;

            case 9:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[9] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[9];
                break;

            case 10:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[10] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[10];
                break;

            case 11:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[11] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[11];
                break;

            case 12:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[12] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[12];
                break;

            case 13:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[13] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[13];
                break;

            case 14:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[14] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[14];
                break;

            case 15:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[15] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[15];
                break;

            case 16:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[16] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[16];
                break;

            case 17:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[17] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[17];
                break;

            case 18:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[18] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[18];
                break;

            case 19:
                // スプライトオブジェクトの変更
                //（配列 m_Sprite[19] に格納したスプライトオブジェクトを変数 m_Image に格納したImage コンポーネントに割り当て）
                m_Image.sprite = m_Sprite[19];
                break;

        }
    }
}