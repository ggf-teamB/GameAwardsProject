using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear_img : MonoBehaviour
{
   public bool imgActive = false;//クリアしたら画像を表示するためのフラグ

    [SerializeField] GameObject Clear;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void c_imgActive()
    {
        imgActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (imgActive == true)
        {
            Clear.SetActive(true);
        }//クリアフラグがtrueなら画像をアクティブにする
    }
}
