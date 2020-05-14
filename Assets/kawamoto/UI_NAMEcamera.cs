using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_NAMEcamera : MonoBehaviour
{

    public GameObject Monster_name;


    // Start is called before the first frame update
    void Start()
    {
        Loteupdate();
    }

    // Update is called once per frame
    void Loteupdate()
    {
        transform.LookAt(Camera.main.transform);
        Monster_name = transform.Find("MS_NAME").gameObject;
        Debug.Log("urabename");
    }
}
