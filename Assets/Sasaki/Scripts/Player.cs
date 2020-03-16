using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] public float moveSpeed;    //移動速度
    [SerializeField] public float runSpeed;     //走る速度
    [SerializeField] public float walkSpeed;    //歩く速度
    [SerializeField] public int durability;     //耐久性

    [SerializeField] float x;                   //x座標
    [SerializeField] float z;                   //z座標
    [SerializeField] public int aniNum;         //アニメーション用

    //Animatorを入れる
    private Animator animator;

    //Main Cameraを入れる
    [SerializeField] Transform cam;

    //Rigidbodyを入れる
    Rigidbody rb;

    //CapsuleColloderを入れる
    CapsuleCollider caps;

    // Start is called before the first frame update
    void Start()
    {
        //動く速度の初期値を歩く速度に設定する
        moveSpeed = walkSpeed;

        //Animatorコンポーネントを取得
        animator = GetComponent<Animator>();

        //Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();

        //勝手に回転しないように設定する
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        //CapsuleColliderコンポーネントを取得
        caps = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの移動
        Player_Move();
    }

    //プレイヤーの移動
    void Player_Move()
    {
        //左shiftキー入力状態の時moveSpeedを走る速度に変更する
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
        
        //A・Dキーで横移動
        x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        //W・Sキーで前後移動
        z = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;

        animator.SetFloat("X", x * aniNum);
        animator.SetFloat("Y", z * aniNum);

        //前移動の時だけ方向転換させる
        if(z > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x,
                cam.eulerAngles.y, transform.rotation.z));
        }

        //xとzの数値に基づいて移動
        transform.position += transform.forward * z + transform.right * x;
    }
}
