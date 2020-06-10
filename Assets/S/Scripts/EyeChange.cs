using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//壁君の目を変えます
public class EyeChange : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    // publicで宣言し、inspectorで設定可能にする
    public Sprite normalSprite;     //通常
    public Sprite damageSprite;     //ダメージ
    public Sprite tearsSprite;      //涙
    public Sprite unknownSprite;    //無い


    void Start()
    {
        // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Normal_eye()
    {
        //normalSpriteに変更
        MainSpriteRenderer.sprite = normalSprite;
    }

    public void Damage_eye()
    {
        // damageSpriteに変更
        MainSpriteRenderer.sprite = damageSprite;
    }

    public void Tears_eye()
    {
        // tearsSpriteに変更
        MainSpriteRenderer.sprite = tearsSprite;
    }
    public void Unknowm_eye()
    {
        // unknownSpriteに変更
        MainSpriteRenderer.sprite = unknownSprite;
    }
}