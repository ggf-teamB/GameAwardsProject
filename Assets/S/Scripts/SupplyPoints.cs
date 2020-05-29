using UnityEngine;

public class SupplyPoints : MonoBehaviour
{
    //補給フラグ
    public static bool SupplyFlg;

    // Start is called before the first frame update
    void Start()
    {
        SupplyFlg = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //触れ続けている間、行なわれる処理
    private void OnTriggerStay(Collider collision)
    {
        //タグがtestのオブジェクトに触れている間
        if (collision.gameObject.tag == "Player")
        {
            //補給フラグをtrueに
            SupplyFlg = true;
        }
    }

    //触れるのをやめた(離れた)とき、行なわれる処理
    private void OnTriggerExit(Collider collision)
    {
        //タグがtestのオブジェクトから離れたとき
        if (collision.gameObject.tag == "Player")
        {
            //補給フラグをfalseに
            SupplyFlg = false;
        }
    }
}
