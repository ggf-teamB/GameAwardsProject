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

    }

    //シーンをステージ１に変更する
    public void First_Stage()
    {
        SceneManager.LoadScene("Game_St01");
    }

    //シーンをステージ２に変更する
    public void Second_Stage()
    {
        SceneManager.LoadScene("Game_St02");
    }

    //シーンをステージ3に変更する
    public void Third_Stage()
    {
        SceneManager.LoadScene("Game_St03");
    }


}
