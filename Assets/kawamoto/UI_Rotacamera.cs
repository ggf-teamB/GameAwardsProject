using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_Rotacamera : MonoBehaviour
{
    // public GameObject test_camera

    private void Update()
    {
        Loteupdate();
    }

    void Loteupdate()
    {
        transform.LookAt(Camera.main.transform);
        Debug.Log("urabe");
    }

}
