using UnityEngine;

//Mobの状態管理スクリプト
public abstract class MobStatus : MonoBehaviour
{

    //状態の定義
    protected enum StateEnum
    {
        Normal,  //通常
        Attack,  //攻撃中
        Attack2,  //攻撃中
        Die,      //死亡
    }

    //移動可能かどうか
    public bool IsMovable => StateEnum.Normal == _state;

    //攻撃可能
    public bool IsAttackable => StateEnum.Normal == _state;

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

    /*_state = StateEnum.random;
                _animator.GetInteger(Random.Range(0, 1));
                Animator.StringToHash("random");*/
    //攻撃中の状態に偏移
    /*public void GoToAttackStateIfPossible()
    {
        int random = Animator.StringToHash("random");
          random = _animator.GetInteger(Random.Range(0, 1));
        switch (random)
        {
            case 0:
                if (!IsAttackable) return;
                
                _state = StateEnum.Attack;
                Animator.StringToHash("Attack");
                //_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack");
                _animator.SetTrigger("Attack");
        break;

        case 1:
            if (!IsAttackable) return;
            _state = StateEnum.Attack2;
            Animator.StringToHash("Attack2");
            _animator.SetTrigger("Attack2");
            break;
        }

    }*/

    public void GoToAttackStateIfPossible()
    {
        if (!IsAttackable) return;

         //_animator.GetInteger(Random.Range(0, 1));

        _state = StateEnum.Attack;
        _animator.SetTrigger("Attack");
        //Animator.StringToHash("Attack");
        //_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack");
        // _animator.SetInteger("random", (Random.Range(0, 1)));

        //Int
    }

        //Normalの状態に偏移
        public void GoToNormalStateIfPossible()
    {
        if (_state == StateEnum.Die) return;
        _state = StateEnum.Normal;
    }
}
