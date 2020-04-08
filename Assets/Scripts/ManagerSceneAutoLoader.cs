using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/************************************************************************
    参考サイト→　https://qiita.com/tsuzuki817/items/1d8a9fce4465c688c78a
************************************************************************/


public class ManagerSceneAutoLoader : MonoBehaviour
{

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadManagerScene()
    {
        string managerScene = "ManagerScene";

        //ManagerSceneが有効ではないときに追加ロード
        if (!SceneManager.GetSceneByName(managerScene).IsValid())
        {
            SceneManager.LoadScene(managerScene, LoadSceneMode.Additive);
        }
    }
}
