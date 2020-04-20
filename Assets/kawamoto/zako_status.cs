using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CountDownHP
{
    public class zako_status : MonoBehaviour
    {
        //HP
        [SerializeField]
        private int HP = 100;
        //HP表示テキスト/表示される値
        private Text hpText;
        //現在のダメージ量
        private int damage = 0;

        public Player_Bullet player_Bullet;
        void Start()
        {
   
            hpText = GetComponentInChildren<Text>();
            //hpText.text = HP.ToString();
        }

        void OnParticleCollision(GameObject col)
        {
            int bullet_pow = player_Bullet.PowerBullet();
            Debug.Log("bullet_chage");
            if (col.gameObject.tag == "bullet")
            {
                Debug.Log("Hiiiiit Player");
                HP -= bullet_pow;
            }
        }

        // Update is called once per frame
        void Update()
        {

            //HPが0以下になったら敵を削除
            if (HP <= 0)
            {
                Destroy(gameObject);
            }
        }
        //　ダメージ値を追加するメソッド
        public void SetDamage(int damage)
        {
            this.damage += damage;
            
        }

    }
}
