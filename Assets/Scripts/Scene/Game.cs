using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    GameObject clear;//オブジェクトいれるためのやつ
    Clear_img c_img;//上のスクリプトいれるやつ
    bool clear_flg;//クリアフラグ

    float seconds;//シーン遷移までの時間変数
    private void Start()
    {
        //現在のシーンを記録する
        SceneDate.Instance.referer = SceneManager.GetActiveScene().name;

        clear = GameObject.Find("Clear_Canvas");//クリア画像のオブジェクト格納

        c_img = clear.GetComponent<Clear_img>();//オブジェクトのスクリプト

        seconds = 0;//クリア時の画像表示時間

        clear_flg = false;//クリアフラグの初期化
    }


    //ゲームオーバーの時シーンを切り替える
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    //ゲームクリア時シーンを切り替える
    public void GameClear()
    {
        c_img.c_imgActive();//画像のアクティブ化関数の呼び出し
        clear_flg = true;//クリアフラグture


    }
    private void Update()
    {
        if (clear_flg == true)
        {
            seconds += Time.deltaTime;//クリア後にカウント
        }
        if (seconds >= 4)
        {
            SceneManager.LoadScene("Menu");

            SceneManager.sceneLoaded += GameSceneLoaded;
        }//秒数たつとメニューに
    }
    //シーンが変わる際に行う処理
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        MenuData menuData = GameObject.FindWithTag("System").GetComponent<MenuData>();

        //ステージ１をクリアしたとき
        if (SceneDate.Instance.referer == "Game_St01") menuData.SetStData01();

        //ステージ２をクリアしたとき
        if (SceneDate.Instance.referer == "Game_St02") menuData.SetStData02();

        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
