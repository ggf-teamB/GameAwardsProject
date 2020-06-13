using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject tutorialObj;

    [SerializeField] private STText stText;

    Vector3 playerRot;

    // Start is called before the first frame update
    void Start()
    {
        playerRot = new Vector3(player.transform.localEulerAngles.x,
            player.transform.localEulerAngles.y,
            player.transform.localEulerAngles.z);

        stText = tutorialObj.GetComponent<STText>();

    }

    // Update is called once per frame
    void Update()
    {
        //timeScaleが0fの時は以下の処理を無視する
        if (Mathf.Approximately(Time.timeScale, 0f)) return;

        if (stText.Flg == true) return;

        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");

        playerRot = new Vector3(0f, playerRot.y + X_Rotation, 0f);

        player.transform.localEulerAngles = playerRot;
    }
}
