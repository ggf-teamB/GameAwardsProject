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

    private void Start()
    {
        //GameManagerタグのついたオブジェクトを代入する
        gmObject = GameObject.FindGameObjectWithTag("GameManager");

        //GameManagerスクリプトを代入する
        gm = gmObject.GetComponent<GameManager>();

        //tmpGameStateを初期化
        tmpGameState = GameState.None;
    }

    // Update is called once per frame
    void Update()
    {
        //ESCキーを入力したとき
        if (Input.GetKeyDown(KeyCode.Escape))
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
    }
}
