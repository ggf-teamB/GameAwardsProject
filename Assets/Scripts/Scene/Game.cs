using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private void Start()
    {
        //現在のシーンを記録する
        SceneDate.Instance.referer = SceneManager.GetActiveScene().name;
    }

    //ゲームオーバーの時シーンを切り替える
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    //ゲームクリア時シーンを切り替える
    public void GameClear()
    {
        SceneManager.LoadScene("Menu");

        SceneManager.sceneLoaded += GameSceneLoaded;
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
