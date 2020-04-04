using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEvent : MonoBehaviour
{
    [SerializeField] private GameObject GM;
    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
        gameManager = GM.GetComponent<GameManager>();
    }

    void SceneLoaded(Scene nextScene,LoadSceneMode mode)
    {
        Debug.Log(nextScene.name);
        gameManager.SceneChangeSetGameState();
    }
}
