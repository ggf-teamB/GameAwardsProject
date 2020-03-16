using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{

    //X軸の角度を制限するための変数
    [SerializeField] public float angleUp;
    [SerializeField] public float angleDown;

    [SerializeField] public GameObject player;  //プレイヤー
    [SerializeField] public Camera camera;      //カメラ

    [SerializeField] public float rotateSpeed;  //カメラが回転する速度
    [SerializeField] public Vector3 axisPos;    //Axisの位置を指定する変数

    // Start is called before the first frame update
    void Start()
    {

        //CameraのAxisに相対的な位置を指定
        camera.transform.localPosition = new Vector3(0, 1, -3);

        //CameraとAxisの向きを最初だけそろえる
        camera.transform.localRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Axisの位置をプレイヤー + AxisPosで決める
        transform.position = player.transform.position + axisPos;

        //Cameraの角度にマウスからとった値を入れる
        transform.eulerAngles += new Vector3(
            Input.GetAxis("Mouse Y") * rotateSpeed,
            Input.GetAxis("Mouse X") * rotateSpeed, 0);

        //X軸の角度
        float angleX = transform.eulerAngles.x;

        if(angleX >= 180)
        {
            angleX -= 360;
        }

        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angleX, angleDown, angleUp),
            transform.eulerAngles.y,
            transform.eulerAngles.z);
    }
}
