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
        if (Object.gameObject.tag == "Enemy")
        {
            Destroy(Object);
            Debug.Log("敵に当たったよ");
        }

        if (Object.gameObject.tag == "Field")
        {
            Destroy(gameObject,0.1f);
            Debug.Log("地面との濃厚接触");
        }
    }
}
