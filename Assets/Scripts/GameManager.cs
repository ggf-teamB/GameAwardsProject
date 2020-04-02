using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Start,      //スタート時
    Playing,    //ゲーム中
    End         //終了時
}

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    //現在のステータス状態
    [SerializeField] private GameState gameState;

    private void Awake()
    {
        Instance = this;

        SetGameState(GameState.Start);

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
            case GameState.End:
                EndAction();
                break;
        }
    }

    void StartAction()
    {

    }

    void PlayingAction()
    {

    }

    void EndAction()
    {

    }
}
