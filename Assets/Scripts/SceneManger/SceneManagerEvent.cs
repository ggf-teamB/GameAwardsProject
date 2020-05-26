using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEvent : MonoBehaviour
{
    //ゲームマネージャーをオブジェクトを格納する変数
    [SerializeField] private GameObject GM;

    //ゲームマネージャークラスを格納する変数
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //シーンが切り替わる際に行われる処理の設定
        SceneManager.sceneLoaded += SceneLoaded;

        //gameManagerにGameManagerクラスを代入する
        gameManager = GM.GetComponent<GameManager>();
    }

    //シーンが切り替わる時に処理を行う
    void SceneLoaded(Scene nextScene,LoadSceneMode mode)
    {
        //ゲームマネージャーのゲームステータスをセットする
        gameManager.SceneChangeSetGameState();
    }
}
