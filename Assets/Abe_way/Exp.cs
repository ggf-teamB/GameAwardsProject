using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public GameObject Box;//爆発を呼び出す場所
    public GameObject Explosion;//呼び出す爆発

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))//Aキーがおされたら
        {
            Instantiate(Explosion.gameObject, Box.transform.position, Box.transform.rotation);//爆発をBoxの場所にBoxの向きで呼び出す
            
            Destroy(Box, 0.1f);//Boxを0.1秒後に消す
            //Destroy(Explosion, 3);//Explosionを3秒後に消す
            
        }
    }
}