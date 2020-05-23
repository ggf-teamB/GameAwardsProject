using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    void Start()
    {
        SceneDate.Instance.referer = SceneManager.GetActiveScene().name;
        Debug.Log(SceneDate.Instance.referer);
    }

    // Update is called once per frame
    void Update()
    {

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
    }
}
