using UnityEngine;

//Mobの状態管理スクリプト
public class zako_Status : MonoBehaviour
{

    //状態の定義
    protected enum StateEnum
    { 
        Normal,  //通常
        Attack,  //攻撃中
        Die      //死亡
    }

    //移動可能かどうか
    public bool IsMovable => StateEnum.Normal == _state;

    //攻撃可能
    public bool IsAttackable => StateEnum.Normal == _state;

    //ライフ最大値を返します
    public float LifeMax => LifeMax;
    public float Life => _life;

    [SerializeField] private float lifeMax = 10;  //ライフの最大値
    protected Animator _animator;
    protected StateEnum _state = StateEnum.Normal;  //Mob状態
    private float _life; //現在のライフ値（ヒットポイント）

    protected virtual void Start()
    {
        _life = lifeMax;   //初期状態はライフ満タン
        _animator = GetComponentInChildren<Animator>();
    }

    //キャラクターが倒れたときの処理を記述
    protected virtual void OnDie()
    {
    }

    //指定地のダメージを受ける
    /// <param name="damage"></param>
    public void Damage(int damage)
    {
        if (_state == StateEnum.Die) return;

        _life -= damage;
        if (_life > 0) return;

        _state = StateEnum.Die;
        _animator.SetTrigger("Die");

        OnDie();
    }

    //攻撃中の状態に偏移
    public void GoToAttackStateIfPossible()
    {
        if (!IsAttackable) return;

        _state = StateEnum.Attack;
        _animator.SetTrigger("Attack");
    }

    //Normalの状態に偏移
    public void GoToNormalStateIfPossible()
    {
    if(_state == StateEnum.Die) return;
        _state = StateEnum.Normal;
    }
}
