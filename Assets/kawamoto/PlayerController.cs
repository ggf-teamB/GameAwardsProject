using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transformを取得
        Transform myTransform = this.transform;

        //座標を取得
        Vector3 pos = myTransform.position;

        //座標を設定
        myTransform.position = pos;  
    }
}
