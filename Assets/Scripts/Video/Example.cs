using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Example : MonoBehaviour
{

    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private float waitTimer;

    private void Start()
    {
        waitTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        waitTimer += Time.deltaTime;

        if (waitTimer <= 1.0f) return;

        if(videoPlayer.isPlaying == false)
        {

            Debug.Log("珍天丸");

            SceneManager.LoadScene("Menu");
        }
    }
}
