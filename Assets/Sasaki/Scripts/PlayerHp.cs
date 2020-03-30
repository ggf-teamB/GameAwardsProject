using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{

    [SerializeField] public int maxHp;      //最大体力
    [SerializeField] public int hp;         //体力
    int cnt;

    // Start is called before the first frame update
    void Start()
    {

        //現在の体力を最大体力に設定する
        hp = maxHp;
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (hp <= 0)
        {
            Debug.Log("死亡しました");
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");

            hp -= 10;
        }
    }
}
