using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEvent : MonoBehaviour
{
    //ゲームマネージャーをオブジェクトを格納する変数
    [SerializeField] private GameObject GM;

    [SerializeField] private GameObject sManager;

    //ゲームマネージャークラスを格納する変数
    private GameManager gameManager;

    private StageManager stageManager;

    // Start is called before the first frame update
    void Start()
    {
        //シーンが切り替わる際に行われる処理の設定
        SceneManager.sceneLoaded += SceneLoaded;

        //gameManagerにGameManagerクラスを代入する
        gameManager = GM.GetComponent<GameManager>();

        //
        stageManager = sManager.GetComponent<StageManager>();
    }

    //シーンが切り替わる時に処理を行う
    void SceneLoaded(Scene nextScene,LoadSceneMode mode)
    {
        //ゲームマネージャーのゲームステータスをセットする
        gameManager.SceneChangeSetGameState();

        //次のシーンがステージ01のとき
        if (nextScene.name == "Game_St01") stageManager.SetStage_01();

        //次のシーンがステージ02のとき
        if (nextScene.name == "Game_St02") stageManager.SetStage_02();

        //次のシーンがステージ03のとき
        if (nextScene.name == "Game_St03") stageManager.SetStage_03();
    }
}
