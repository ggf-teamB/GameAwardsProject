using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeEndRoll(7.19f));
    }

    // Update is called once per frame
    void Update()
    {
        //スペースキーを入力
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("EndRoll");
        }
    }

    private IEnumerator ChangeEndRoll(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene("EndRoll");
    }
}
