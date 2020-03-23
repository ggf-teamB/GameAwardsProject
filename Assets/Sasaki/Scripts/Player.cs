using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //characterController型の変数
    private CharacterController characterController;

    //Animator型の変数
    private Animator animator;

    //キャラクターコントローラーを動かす為のVector3型の変数
    [SerializeField] private Vector3 velocity;

    //ジャンプ力
    [SerializeField] public float jumpPower;

    //縦の視点移動の変数(カメラに合わせる)
    [SerializeField] public Transform verRot;

    //横の視点移動の変数(プレイヤーに合わせる)
    [SerializeField] public Transform horRot;

    //移動速度
    [SerializeField] public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //characterControllerを変数に代入
        characterController = GetComponent<CharacterController>();

        //Animatorを変数に代入
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //マウスのx軸の動きを代入する
        float x_Rotation = Input.GetAxis("Mouse X");

        //マウスのy座標の動きを代入する
        float y_Rotation = Input.GetAxis("Mouse Y");

        //プレイヤーのY軸の回転をx_Rotationに合わせる
        horRot.transform.Rotate(new Vector3(0, x_Rotation * 2, 0));

        //カメラのX軸の回転をy_Rotationに合わせる
        verRot.transform.Rotate(-(y_Rotation) * 2, 0, 0);

        //プレイヤーの移動
        Player_Move();
    }

    //プレイヤーの移動
    void Player_Move()
    {
        //wキーが押されたとき
        if (Input.GetKey(KeyCode.W))
        {
            //前方にmoveSpeed*Time.deltaTimeだけ動かす
            characterController.Move(
                this.gameObject.transform.forward * moveSpeed * Time.deltaTime);

            //isRunをtrueにする
            animator.SetBool("isRun", true);
        }

        //wキーがはなされたとき
        else if (Input.GetKeyUp(KeyCode.W))
        {
            //isRunをfalseにする
            animator.SetBool("isRun", false);
        }

        //sキーが押されたとき
        if (Input.GetKey(KeyCode.S))
        {
            //後方にmoveSpeed*Time.deltaTimeだけ動かす
            characterController.Move(
                this.gameObject.transform.forward * -1f * moveSpeed * Time.deltaTime);

            //isRunをtrueにする
            animator.SetBool("isRun", true);
        }

        //sキーがはなされたとき
        else if (Input.GetKeyUp(KeyCode.S))
        {
            //isRunをfalseにする
            animator.SetBool("isRun", false);
        }

        //aキーが押されたとき
        if (Input.GetKey(KeyCode.A))
        {
            //左にmoveSpeed*Time.deltaTimeだけ動かす
            characterController.Move(
                this.gameObject.transform.transform.right * -1 * moveSpeed * Time.deltaTime);

            //isRunをtrueにする
            animator.SetBool("isRun", true);
        }

        //aキーがはなされたとき
        else if (Input.GetKeyUp(KeyCode.A))
        {
            //isRunをfalseにする
            animator.SetBool("isRun", false);
        }

        //dキーが押されたとき
        if (Input.GetKey(KeyCode.D))
        {
            //右にmoveSpeed*Time.deltaTimeだけ動かす
            characterController.Move(
                this.gameObject.transform.right * moveSpeed * Time.deltaTime);

            //isRunをtrueにする
            animator.SetBool("isRun", true);
        }

        //dキーが押されたとき
        else if (Input.GetKeyUp(KeyCode.D))
        {
            //isRunをfalseにする
            animator.SetBool("isRun", false);
        }

        //キャラクターコントローラーをvelocityだけ動かし続ける
        characterController.Move(velocity);

        //velocityのy軸を重力*Time.deltaTime分だけ動かす
        velocity.y += Physics.gravity.y * Time.deltaTime;
    }
}