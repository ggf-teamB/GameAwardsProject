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
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Result");
        }
    }

    //プレイヤーの体力が0になった時に呼ぶ
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
