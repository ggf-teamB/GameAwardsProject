using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUI : MonoBehaviour
{
    public GameObject Obstacles;   //HPバー

    public float x, y, z;

    [SerializeField] MovingObstacles flg;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mypos = new Vector3(0, 0, 0);
        Transform myTransform = this.transform;
        myTransform.position = mypos;  // 座標を設定
        Obstacles.gameObject.GetComponent<Transform>();
        Vector3 pos = Obstacles.transform.position;
        x = pos.x;
        y = pos.y;
        z = pos.z;
        if (flg.Flg == false) return;
        mypos = new Vector3(x-0.6f, y+1.25f, z + 0.4f);
        myTransform = this.transform;
        myTransform.position = mypos;  // 座標を設定
    }
}

