using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    [SerializeField]
    private int powerBullet = 10; //プレイヤーの弾の攻撃力

    public int PowerBullet()
    {
        return powerBullet;
    }
}
