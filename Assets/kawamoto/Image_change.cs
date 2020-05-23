using UnityEngine;
using System.Collections.Generic;

using UnityEngine.UI;

public class Image_change : MonoBehaviour
{
    Sprite sprite;
    Image  Dush_image;
    Image Nomal_image;

    void Start()
    {
        sprite = Resources.Load<Sprite>("Unity02");//ダッシュ画像を読み込み
        Nomal_image = GetComponent<Image>();
    }

    
    void Update()
    {    //SpriteRenderのspriteを設定済みの他のspriteに変更

        //timeScaleが0fの時は以下の処理を無視する
        if (Mathf.Approximately(Time.timeScale, 0f)) return;

        Debug.Log("aaaaaaaa");
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) )
        {
            sprite = Resources.Load<Sprite>("Unity02");//ダッシュ画像を読み込み
            Dush_image = GetComponent<Image>();
            Dush_image.sprite = sprite; //ダッシュ画像に変更
        }
        else
        {
            sprite = Resources.Load<Sprite>("Unity01");//通常画像を読み込み
            Nomal_image = GetComponent<Image>();
            Nomal_image.sprite = sprite; //通常画像に変更
        }
  
    }
}
