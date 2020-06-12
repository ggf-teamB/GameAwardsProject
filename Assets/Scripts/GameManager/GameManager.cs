using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Start,      //スタート時
    Playing,    //ゲーム中
    Pause,      //中断中
    End,        //終了時
    None        //無し
}

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    //現在のステータス状態
    [SerializeField] public GameState gameState;

    [SerializeField] private GameObject cursorManagerObj;

    [SerializeField] private CursorManager cursorManager;

    private void Awake()
    {
        Instance = this;

        cursorManager = cursorManagerObj.GetComponent<CursorManager>();

        SetGameState(GameState.None);
    }

    private void Update()
    {
        //timeScaleが０でgameStateがPause以外の時
        if(Time.timeScale == 0f && gameState != GameState.Pause)
        {
            Time.timeScale = 1f;
        }
    }

    //ステータス状態をセットする
    public void SetGameState(GameState state)
    {
        gameState = state;

        OnGameStateChanged(gameState);
    }

    //ステータスの状態が変化した場合に処理する
    public void OnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                StartAction();
                break;
            case GameState.Playing:
                PlayingAction();
                break;
            case GameState.Pause:
                PauseAction();
                break;
            case GameState.End:
                EndAction();
                break;
            case GameState.None:
                NoneAction();
                break;
        }
    }

    void StartAction()
    {
        cursorManager.SetCursor(false);

        SetGameState(GameState.Playing);
    }

    void PlayingAction()
    {
        cursorManager.SetCursor(false);
    }

    void PauseAction()
    {
        cursorManager.SetCursor(true);
        Time.timeScale = 0f;
    }

    void EndAction()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
        #endif
    }

    void NoneAction()
    {
        cursorManager.SetCursor(true);
    }

    //シーンのロードが完了時ゲームステータスを変更する
    public void SceneChangeSetGameState()
    {
        //ゲームシーンの時行う処理
        if (SceneManager.GetActiveScene().name == "Game_St01"
            || SceneManager.GetActiveScene().name == "Game_St02"
            || SceneManager.GetActiveScene().name == "Game_St03")
        {
            SetGameState(GameState.Start);
        }
        else
        {
            SetGameState(GameState.None);
        }
    }
}
