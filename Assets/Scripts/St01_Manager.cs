using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class St01_Manager : MonoBehaviour
{

    private GameState stageState;

    [SerializeField] private GameObject systemObject;
    private Game game;

    // Start is called before the first frame update
    void Start()
    {
        stageState = GameState.Start;
        game = systemObject.GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ゲームオーバーした時に呼び出す処理
    public void GameOver()
    {
        game.GameOver();
    }

    //ステージをクリアした時に呼び出す処理
    private void GameClear()
    {
        game.GameClear();
    }
}
