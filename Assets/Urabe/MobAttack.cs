﻿using System.Collections;
using UnityEngine;

//攻撃制御クラス
[RequireComponent(typeof(MobStatus))]
public class MobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f;  //攻撃クールダウン
    [SerializeField] private Collider attackCollider;

    private MobStatus _status;

    // Start is called before the first frame update
    private void Start()
    {
        _status = GetComponent<MobStatus>();
    }

    public void AttackIfPossible()
    {
        if (!_status.IsAttackable) return;
        //ステータスを衝突したオブジェクトで攻撃可否を判断

        _status.GoToAttackStateIfPossible();
    }

    //攻撃対象が攻撃範囲に入ったときに呼ぶ
    /// <param name="collider"></param>
    public void OnAttackRangeEnter(Collider collider)
    {
        AttackIfPossible();
    }

    //攻撃開始時に呼ぶ
    public void OnAttackStart()
    {
        attackCollider.enabled = true;
    }

    //attackColliderが攻撃対象にHitしたときに呼ぶ
    /// <param name="collider"></param>
    public void OnHitAttack(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();
        if (null == targetMob) return;

        //プレイヤーにダメージを与える
        targetMob.Damage(1);
    }

    //攻撃の終了時に呼ばれます
    public void OnAttackFinished()
    {
        attackCollider.enabled = false;
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        _status.GoToNormalStateIfPossible();
    }
}
