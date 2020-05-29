using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject tutorialObj;

    [SerializeField] private TutorialText tutorial;

    Vector3 roteuler;

    Vector3 playerRot;

    // Start is called before the first frame update
    void Start()
    {
        roteuler = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0f);

        playerRot = new Vector3(player.transform.localEulerAngles.x,
            player.transform.localEulerAngles.y,
            player.transform.localEulerAngles.z);

        tutorial = tutorialObj.GetComponent<TutorialText>();

    }

    // Update is called once per frame
    void Update()
    {
        //timeScaleが0fの時は以下の処理を無視する
        if (Mathf.Approximately(Time.timeScale, 0f)) return;

        if (tutorial.Flg == true) return;

        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");

        roteuler = new Vector3(Mathf.Clamp(roteuler.x - Y_Rotation, -20, 30), 
            0f, 0f);

        playerRot = new Vector3(0f, playerRot.y + X_Rotation, 0f);

        transform.localEulerAngles = roteuler;



        player.transform.localEulerAngles = playerRot;
    }
}
