using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //次のシーン
    private string NextScene;

    // Start is called before the first frame update
    void Start()
    {
        //次のシーンの名前をNextSceneに代入
        NextScene = SceneDate.Instance.referer;
        Debug.Log(NextScene);
    }

    // Update is called once per frame
    void Update()
    {
        //スペースボタンを押したら
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(NextScene);
        }
    }
}
