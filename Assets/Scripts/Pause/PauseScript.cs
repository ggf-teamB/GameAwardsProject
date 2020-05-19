using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    //GameManagerスクリプトがアタッチされてるゲームオブジェクト
    [SerializeField] private GameObject gmObject;

    //GameManagerスクリプト
    [SerializeField] private GameManager gm;

    //ポーズ前のGameStateを保存
    [SerializeField] private GameState tmpGameState;

    //ポーズメニューUI
    [SerializeField] private GameObject pauseMenu;

    //設定メニューUI
    [SerializeField] private GameObject settingsMenu;

    //設定画面が表示されているかの判定
    [SerializeField] private bool isSettingsMenu;

    private void Start()
    {
        //GameManagerタグのついたオブジェクトを代入する
        gmObject = GameObject.FindGameObjectWithTag("GameManager");

        //GameManagerスクリプトを代入する
        gm = gmObject.GetComponent<GameManager>();

        //tmpGameStateを初期化
        tmpGameState = GameState.None;

        //isSettingsMenuを初期化する
        isSettingsMenu = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //ESCキーを入力したとき
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isSettingsMenu == false)
            {
                PauseMenu();
            }
        }
    }

    private void PauseMenu()
    {
        //gameStateがGameState.Pause以外の場合
        if (gm.gameState != GameState.Pause)
        {
            //ポーズ前のgameStateを記録
            tmpGameState = gm.gameState;

            //GameState.Pauseをセット
            gm.SetGameState(GameState.Pause);

            //ポーズメニューを表示するように
            pauseMenu.SetActive(true);
        }
        else
        {
            //ポーズ前のgameStateに戻す
            gm.SetGameState(tmpGameState);

            //tmpGameStateをNoneにする
            tmpGameState = GameState.None;

            //ポーズメニューを非表示にする
            pauseMenu.SetActive(false);
        }
    }

    public void Settings()
    {
        //設定メニューを表示する
        settingsMenu.SetActive(true);

        //ポーズメニューを非表示にする
        pauseMenu.SetActive(false);

        //trueにする
        isSettingsMenu = true;
    }

    public void Exit_Settings()
    {
        //設定メニューを非表示にする
        settingsMenu.SetActive(false);
        
        //ポーズメニューを表示する
        pauseMenu.SetActive(true);

        //falseにする
        isSettingsMenu = false;
    }

    public void Exit_Game()
    {
        //GameState.Endをセットする
        gm.SetGameState(GameState.End);
    }
}
