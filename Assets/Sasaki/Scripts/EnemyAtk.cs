using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtk : MonoBehaviour
{
    //生成する弾
    [SerializeField] public GameObject bullet;

    //
    private GameObject bullets;

    //弾の速度
    [SerializeField] public float speed = 1000;

    //時間判定用
    private float getTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        getTime -= Time.deltaTime;

        //1秒ごとに処理行う
        if(getTime <= 0.0)
        {
            getTime = 1.0f;

            Shot();
        }

    }

    public void Shot()
    {
        bullets = Instantiate(bullet) as GameObject;

        bullets.tag = "Enemy";

        bullets.transform.position = transform.position;

        Vector3 force;

        force = this.gameObject.transform.forward * speed;

        bullets.GetComponent<Rigidbody>().AddForce(force);

        Destroy(bullets, 3.0f);
    }
}
