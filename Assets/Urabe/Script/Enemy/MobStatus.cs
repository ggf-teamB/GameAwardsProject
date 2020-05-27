﻿using UnityEngine;

//Mobの状態管理スクリプト
public abstract class MobStatus : MonoBehaviour
{

    //状態の定義
    protected enum StateEnum
    {
        Normal,  //通常
        Attack,  //攻撃中 
        Die,      //死亡
        //BasicAttack
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

    //攻撃中の状態に偏移
    public void GoToAttackStateIfPossible()
    {
        if (!IsAttackable) return;

        _state = StateEnum.Attack;
        _animator.SetTrigger("Attack");
        //_state = StateEnum.BasicAttack;
        //_animator.SetTrigger("BasicAttack");
        //_animator.SetTrigger("TailAttack");
    }

    //Normalの状態に偏移
    public void GoToNormalStateIfPossible()
    {
        if (_state == StateEnum.Die) return;
        _state = StateEnum.Normal;
    }
}
