using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class zako_Controll : MonoBehaviour
{
    //zako_statusのデータを持ってくる
    private CountDownHP.zako_status status;
    void Start()
    {
        status = GetComponent<CountDownHP.zako_status>();
    }
    
    public void TakeDamage(int damage)
    {
        status.SetDamage(damage);
    }
  
}
