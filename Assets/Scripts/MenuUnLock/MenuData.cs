using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuData : MonoBehaviour
{
    //ステージ1のクリア状況
    [SerializeField] private int clearSt01;

    //ステージ2のクリア状況
    [SerializeField] private int clearSt02;

    //ステージ1のクリア条件のプロパティ
    public int ClearSt01
    {
        get { return this.clearSt01; }
    }

    //ステージ2のクリア条件のプロパティ
    public int ClearSt02
    {
        get { return this.clearSt02; }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        //データのセット
        if (PlayerPrefs.HasKey("StData01") == true)
        {
            clearSt01 = PlayerPrefs.GetInt("StData01");
        }
        else
        {
            clearSt01 = 0;
            PlayerPrefs.SetInt("StData01", clearSt01);
        }

        if (PlayerPrefs.HasKey("StData02") == true)
        {
            clearSt02 = PlayerPrefs.GetInt("StData02");
        }
        else
        {
            clearSt02 = 0;
            PlayerPrefs.SetInt("StData02", clearSt02);
        }

        PlayerPrefs.Save();

    }

    //ステージ１をクリアしたときに切り替える
    public void SetStData01()
    {
        clearSt01 = 1;
        PlayerPrefs.SetInt("StData01", clearSt01);
        PlayerPrefs.Save();
    }

    //ステージ２をクリアしたときに切り替える
    public void SetStData02()
    {
        clearSt02 = 1;
        PlayerPrefs.SetInt("StData02", clearSt02);
        PlayerPrefs.Save();
    }
}
