using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unity_target : MonoBehaviour
{

    //カーソルの画像
    [SerializeField]
    private Texture2D cursor;


    void Start()
    {
        //カーソルを画像のカーソルに変更
        Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //カーソルの角度を取得
        transform.rotation = Quaternion.LookRotation(ray.direction);

        //　マウスの左クリックで光を撃つ
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    //　光を撃つ
    void Shot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Enemy")))
        {
            Destroy(hit.collider.gameObject);
        }
    }
}