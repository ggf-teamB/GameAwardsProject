using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //メニューデータクラス
    [SerializeField] MenuData menuData;

    //ステージ２のアンロックフラグ
    [SerializeField] private bool isUnLockSt02;

    //ステージ３のアンロックフラグ
    [SerializeField] private bool isUnLockSt03;

    //ステージ２のアンロックフラグのプロパティ
    public bool IsUnLockSt02
    {
        get { return this.isUnLockSt02; }
    }

    //ステージ３のアンロックフラグのプロパティ
    public bool IsUnLockSt03
    {
        get { return this.isUnLockSt03; }
    }

    // Start is called before the first frame update
    void Start()
    {
        menuData = GetComponent<MenuData>();

        //ClearSt01が1の場合true、0の時falseに
        if(menuData.ClearSt01 == 1)
        {
            isUnLockSt02 = true;
        }
        else
        {
            isUnLockSt02 = false;
        }

        //ClearSt02が1の場合true、0の時falseに
        if(menuData.ClearSt02 == 1)
        {
            isUnLockSt03 = true;
        }
        else
        {
            isUnLockSt03 = false;
        }
    }

    //シーンをステージ１に変更する
    public void First_Stage()
    {
        SceneManager.LoadScene("Game_St01");
    }

    //シーンをステージ２に変更する
    public void Second_Stage()
    {
        if (isUnLockSt02 == false) return;

        SceneManager.LoadScene("Game_St02");
    }

    //シーンをステージ3に変更する
    public void Third_Stage()
    {
        if (isUnLockSt03 == false) return;

        SceneManager.LoadScene("Game_St03");
    }
}
