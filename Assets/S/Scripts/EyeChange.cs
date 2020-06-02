using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeChange : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    // publicで宣言し、inspectorで設定可能にする
    public Sprite StandbySprite;
    public Sprite HoldSprite;

    void Start()
    {
        // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // 何かしらのタイミングで呼ばれる
    public void ChangeStateToHold()
    {
        //呼ばれたら
        //HoldSpriteに変更
        MainSpriteRenderer.sprite = HoldSprite;
    }
    // 何かしらのタイミングで呼ばれる
    public void Hold()
    {
        // 呼ばれたら
        // HoldSpriteに変更
        MainSpriteRenderer.sprite = StandbySprite;
    }
}