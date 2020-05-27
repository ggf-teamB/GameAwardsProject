using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Collider : MonoBehaviour
{
    BoxCollider box;
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = Wavex.timer;
        if (timer >= 75 && timer <= 850)
        {
            box.center = new Vector3(6, 0, 0);
            box.size = new Vector3(15, 2, 2);
        }
        else
        {
            box.center = new Vector3(0, 0, 0);
            box.size = new Vector3(2, 2, 2);
        }
    }
}
