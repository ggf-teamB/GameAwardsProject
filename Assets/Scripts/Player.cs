﻿using System.Collections;
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

    //移動速度
    [SerializeField] private float moveSpeed;

    //歩く速度
    [SerializeField] private float walkSpeed = 5;

    //走る速度
    [SerializeField] private float ranSpeed;

    //最大体力
    [SerializeField] public int maxHp;

    //体力
    [SerializeField] public int durability;

    //鍵を持っているかどうか
    [SerializeField] public bool isKey;

    [SerializeField] private GameObject stManager;

    private Game game;

    // Start is called before the first frame update
    void Start()
    {
        //characterControllerを変数に代入
        characterController = GetComponent<CharacterController>();

        //Animatorを変数に代入
        animator = GetComponent<Animator>();

        //現在の体力を最大体力に設定する
        durability = maxHp;

        ranSpeed = walkSpeed * 1.5f;

        isKey = false;

        game = stManager.GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーの移動
        Player_Move();

        //プレイヤーの生死
        Player_Dead();
    }

    //プレイヤーの移動
    void Player_Move()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = ranSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }


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

    //プレイヤーの生死
    void Player_Dead()
    {
        //体力がなくなった場合
        if(durability <= 0)
        {
            game.GameOver();
        }
    }

    //鍵の取得
    public void GetKey()
    {
        //鍵を所持してる状態にする
        isKey = true;
    }

    //当たり判定処理
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            durability -= 10;
        }
    }
}