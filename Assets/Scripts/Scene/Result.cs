using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //シーンをタイトルへ変更する
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }

        //シーンをメニューへ変更する
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
