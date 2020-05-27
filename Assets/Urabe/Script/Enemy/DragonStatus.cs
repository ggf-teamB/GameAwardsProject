using UnityEngine;

//Mobの状態管理スクリプト
public abstract class DragonStatus : MonoBehaviour
{

    //状態の定義
    protected enum StateEnum
    {
        Normal,  //通常
        BasicAttack,  //攻撃中 
        Die,      //死亡
        //BasicBasicAttack
    }

    //移動可能かどうか
    public bool IsMovable => StateEnum.Normal == _state;

    //攻撃可能
    public bool IsBasicAttackable => StateEnum.Normal == _state;



    protected Animator _animator;
    protected StateEnum _state = StateEnum.Normal;  //Mob状態

    protected virtual void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    //キャラクターが倒れたときの処理を記述
    protected virtual void OnDie()
    {
    }

    //攻撃中の状態に偏移
    public void GoToBasicAttackStateIfPossible()
    {
        if (!IsBasicAttackable) return;

        _state = StateEnum.BasicAttack;
        _animator.SetTrigger("BasicAttack");
        //_state = StateEnum.BasicBasicAttack;
        //_animator.SetTrigger("BasicBasicAttack");
        //_animator.SetTrigger("TailBasicAttack");
    }

    //Normalの状態に偏移
    public void GoToNormalStateIfPossible()
    {
        if (_state == StateEnum.Die) return;
        _state = StateEnum.Normal;
    }
}
