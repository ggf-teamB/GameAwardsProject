using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //ステージ１にシーンを変更する
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Game_St01");
        }

        //ステージ２にシーンを変更する
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Game_St02");
        }

        //ステージ３にシーンを変更する
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Game_St03");
        }
    }
}
