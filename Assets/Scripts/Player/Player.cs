using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //システムオブジェクト
    [SerializeField] private GameObject systemObj;

    //チュートリアルオブジェクト
    [SerializeField] private GameObject tutorialObj;

    //ステージマネージャーオブジェクト
    [SerializeField] private GameObject stManagerObj;

    //ゲームクラス
    [SerializeField] private Game game;

    //チュートリアルテキストクラス
    [SerializeField] private STText stText;

    //ステージ管理クラス
    [SerializeField] private StageManager stManager;

    //キャラクターコントローラーを動かす為のVector3型の変数
    [SerializeField] private Vector3 velocity;

    //移動速度
    [SerializeField] private float moveSpeed;

    //歩く速度
    [SerializeField] private float walkSpeed;

    //走る速度
    [SerializeField] private float ranSpeed;

    //最大体力
    [SerializeField] private int maxHp;

    //体力
    [SerializeField] private int durability;

    //鍵を持っているかどうか
    [SerializeField] private bool isKey;

    //characterController型の変数
    private CharacterController characterController;

    //Animator型の変数
    private Animator animator;

    //最大体力のプロパティ
    public int MaxHp
    {
        get { return this.maxHp; }
    }

    //体力のプロパティ
    public int Durability
    {
        get { return this.durability; }
    }

    //鍵所持フラグのプロパティ
    public bool IsKey
    {
        get { return this.isKey; }
    }

    // Start is called before the first frame update
    void Start()
    { 
        walkSpeed = 5f;

        ranSpeed = walkSpeed * 1.5f;

        //現在の体力を最大体力に設定する
        durability = maxHp;

        isKey = false;

        //ステージマネージャーオブジェクト
        stManagerObj = GameObject.FindGameObjectWithTag("StageManager");

        //ステージ管理クラス
        stManager = stManagerObj.GetComponent<StageManager>();

        //ゲームクラスを代入
        game = systemObj.GetComponent<Game>();

        stText = tutorialObj.GetComponent<STText>();

        //characterControllerを変数に代入
        characterController = GetComponent<CharacterController>();

        //Animatorを変数に代入
        animator = GetComponent<Animator>();

        Player_Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (stText.Flg == true) return;

        //プレイヤーの移動
        Player_Move();

        //プレイヤーの生死
        Player_Dead();
    }

    //プレイヤーのスポーンポイント
    private void Player_Spawn()
    {
        //StageStateがStage_01のとき
        if(stManager.StageState == StagesState.Stage_01)
        {
            this.transform.position = new Vector3(0f, 50f, 120f);
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        //StageStateがStage_02のとき
        if(stManager.StageState == StagesState.Stage_02)
        {
            this.transform.position = new Vector3(74.9f, 0.4f, 4f);
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        //StageStateがStage_03のとき
        if(stManager.StageState == StagesState.Stage_03)
        {
            this.transform.position = new Vector3(14.1f, 0.1f, 49.4f);
            this.transform.rotation = Quaternion.Euler(0f, 113.5f, 0f);
        }
    }

    //プレイヤーの移動
    void Player_Move()
    {
        //Shiftキーが入力されたとき
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

    //プレイヤーのダメージ処理
    public void Get_Damage(int damage)
    {
        durability -= damage;
    }

    //鍵の取得
    public void GetKey()
    {
        //鍵を所持してる状態にする
        isKey = true;
    }
}