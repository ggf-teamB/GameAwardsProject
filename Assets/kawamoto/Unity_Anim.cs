using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unity_Anim : MonoBehaviour
{

    Animator animator;

    //Inspectorで変更できるようにpublicにした
    public float first;
    public int second;
    public float third;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //マウス左クリックで発動
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("ururururur");
            animator.CrossFade("Gun", first, second, third);
        }
    }
}