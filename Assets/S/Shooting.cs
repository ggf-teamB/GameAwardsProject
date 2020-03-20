using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    // bullet prefab
    public GameObject bullet;

    // 弾丸発射点
    public Transform muzzle;

    // 弾丸の速度
    public float speed = 1000;

    // 弾丸の速度
    public float power = 0;

    private int Charge = 0;
    private bool flg = false;

    float x = 0;
    float y = 0;
    float z = 0;


    // Use this for initialization
    void Start()
    {
        Vector3 chack = new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            bullet.transform.localScale += new Vector3(0.5f,0.5f,0.5f);
                /* Vector3 mousePosition = Input.mousePosition;//マウスを振れば弾が大きくなるようにしたい
                  flg = true;
                  if (flg == true)
                  {
                Vector3 chack = Input.mousePosition;//マウスを振れば弾が大きくなるようにしたい
                if (mousePosition.x == chack.x)
                      {

                      }
                  }*/
        }
        if (Input.GetKeyDown(KeyCode.A))//大きさを元に戻す(テスト用)
        {
            bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        // z キーが押された時
        if (Input.GetKeyDown(KeyCode.Z))
        {
                // 弾丸の複製
                GameObject bullets = Instantiate(bullet) as GameObject;

                Vector3 force;

                force = this.gameObject.transform.forward * speed;

                // Rigidbodyに力を加えて発射
                bullets.GetComponent<Rigidbody>().AddForce(force);

                // 弾丸の位置を調整
                bullets.transform.position = muzzle.position;

                Destroy(bullets, 3.0f); // 三秒後に削除
         }
    }
}