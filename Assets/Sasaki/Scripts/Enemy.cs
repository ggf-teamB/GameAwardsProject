using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //エネミーのステータス
    public enum EnemyState
    {
        Attack,
        None
    }

    //ステータス
    [SerializeField] private EnemyState state;

    public GameObject bullet;

    [SerializeField] private Vector3 mazuru;

    private float timeleft;

    // Start is called before the first frame update
    void Start()
    {
        state = EnemyState.None;
        mazuru = new Vector3(transform.position.x,
            transform.position.y + 1,
            transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        timeleft -= Time.deltaTime;

        if(timeleft <= 0.0)
        {
            if (state == EnemyState.Attack)
            {
                GameObject bullets = Instantiate(bullet) as GameObject;

                EnemyBullet e = bullets.GetComponent<EnemyBullet>();

                Vector3 force;

                force = this.gameObject.transform.forward * 30;

                //Rigidbodyに力を加えて発射
                bullets.GetComponent<Rigidbody>().AddForce(force);

                //弾丸の位置を調整
                bullets.transform.position = mazuru;
            }

            timeleft = 1.0f;
        }
    }

    //エネミーのステータスをセットする
    private void SetState(EnemyState nextState)
    {
        state = nextState;
    }

    //プレイヤーが攻撃範囲に入った時の処理
    public void AreaIntrusion_SetState()
    {
        SetState(EnemyState.Attack);
    }

    //プレイヤーが攻撃範囲からでた時の処理
    public void AreaLeaving_SetState()
    {
        SetState(EnemyState.None);
    }
}
