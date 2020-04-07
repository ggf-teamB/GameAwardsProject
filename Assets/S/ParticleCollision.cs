using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnParticleCollision(GameObject Object)
    {
        //処理内容

        //例）衝突したオブジェクトタグがEnemyだった場合、オブジェクトを破壊する

        if (Object.gameObject.tag == "Enemy")
        {
            Destroy(Object);
            Debug.Log("敵に当たったよ");
        }
    }
}
