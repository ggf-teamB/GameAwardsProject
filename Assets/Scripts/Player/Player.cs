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

    //射撃クラス
    [SerializeField] private Shooting shooting;

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

    //歩き・走りのSE
    private AudioSource[] Run_Walk;

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

        shooting = this.GetComponent<Shooting>();

        //characterControllerを変数に代入
        characterController = GetComponent<CharacterController>();

        //Animatorを変数に代入
        animator = GetComponent<Animator>();

        //AudioSourceを代入
        Run_Walk = gameObject.GetComponents<AudioSource>();

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
        //特殊アニメーションが発生するとき移動させない
        if (shooting.AnimeFlg == true) return;

        //Shiftキーが入力されたとき
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = ranSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }

        //すべての移動キーが押されたとき
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) &&
            Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRun", false);
        }

        //移動しない場合isRunをfalseにする
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            //AキーとDキー入力の時は処理を切り上げる
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) return;

            //isRunをfalseにする
            animator.SetBool("isRun", false);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            //WキーとSキー入力の時は処理を切り上げる
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) return;

            //isRunをfalseにする
            animator.SetBool("isRun", false);
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
        if (Input.GetKeyDown(KeyCode.W))
        {
            Run_Walk[1].Play();
        }

        //wキーがはなされたとき
        else if (Input.GetKeyUp(KeyCode.W))
        {
            //他のキーを入力されてるとき処理を切り上げる
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) return;

            //isRunをfalseにする
            animator.SetBool("isRun", false);

            Run_Walk[1].Stop();
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
        if (Input.GetKeyDown(KeyCode.S))
        {
            Run_Walk[1].Play();
        }
        //sキーがはなされたとき
        else if (Input.GetKeyUp(KeyCode.S))
        {
            //他のキーを入力されてるとき処理を切り上げる
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) return;

            //isRunをfalseにする
            animator.SetBool("isRun", false);

            Run_Walk[1].Stop();
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            Run_Walk[1].Play();
        }

        //aキーがはなされたとき
        else if (Input.GetKeyUp(KeyCode.A))
        {
            //他のキーを入力されてるとき処理を切り上げる
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) return;

            //isRunをfalseにする
            animator.SetBool("isRun", false);

            Run_Walk[1].Stop();
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
        if (Input.GetKeyDown(KeyCode.D))
        {
            Run_Walk[1].Play();
        }

        //dキーが離されたとき
        else if (Input.GetKeyUp(KeyCode.D))
        {
            Run_Walk[1].Stop();
            //他のキー入力されてるとき処理を切り上げる
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A)) return;

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