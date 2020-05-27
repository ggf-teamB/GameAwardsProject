using UnityEngine;
using System.Collections;

public class FireDamage : MonoBehaviour
{
    [SerializeField] private GameObject playerObj;
    private Player player;
    void Start()
    {
        player = playerObj.GetComponent<Player>();
    }
    private void OnTriggerStay(Collider collision)
    {
        // 物体がトリガーに接触している間、常に呼ばれる
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("もっと燃えるがいいや!");
            player.Get_Damage(1);
        }
    }
}
