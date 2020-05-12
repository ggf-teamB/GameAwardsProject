using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_Rotacamera : MonoBehaviour
{
    public GameObject HP_bar;   //HPバー

    public Vector3 HP_bar_pos;  //HPバーの位置

    private void Update()
    {
        //Loteupdate();
    }

    void Loteupdate()
    {
        transform.LookAt(Camera.main.transform);
        //HP_bar = transform.Find("HP_bar").gameObject;
        //HP_bar_pos = HP_bar.transform.localPosition;
        Debug.Log("urabe");
    }

}
