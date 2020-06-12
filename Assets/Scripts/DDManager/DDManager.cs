﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDManager : MonoBehaviour
{
    //ゲームマネージャーを格納する変数
    public GameObject gameManager;

    //シーンマネージャーを格納する変数
    public GameObject sceneManager;

    public GameObject stageManager;

    public GameObject cursorManager;

    // Start is called before the first frame update
    void Start()
    {
        //gameManagerを削除しないように設定する
        DontDestroyOnLoad(gameManager);

        //sceneManagerを削除しないように設定する
        DontDestroyOnLoad(sceneManager);

        //stageMangerを削除しないように設定する
        DontDestroyOnLoad(stageManager);

        //cursorManagerを削除しないように設定する
        DontDestroyOnLoad(cursorManager);
    }
}
