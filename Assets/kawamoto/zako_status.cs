using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace CountDownHP
{
    public class zako_status : MonoBehaviour
    {

        //MAXHP
        [SerializeField]
        private int MAXHP = 100;

        //HP
        [SerializeField]
        public int HP;

        //HP表示テキスト/表示される値
        private Text hpText;

        //現在のダメージ量
        private int damage = 0;

        //プレイヤーの弾のダメージ
        public Player_Bullet player_Bullet;

        //HP表示用のUI
        [SerializeField]
        private GameObject HP_UI;

        //HP表示のスライダー
        public Slider hpSlider;

        void Start()
        {
   
            hpText = GetComponentInChildren<Text>();

            //HPに最大HPをセット
            HP = MAXHP;

            //HPバーのデータを取得
            hpSlider = HP_UI.transform.Find("HP_Bar").GetComponent<Slider>();
            hpSlider.value = 1f;
        }

        public void Set_HP()
        {

            //　HP表示用UIのアップデート
            UpdateHPValue();

            if (HP <= 0)
            {
                //　HP表示用UIを非表示にする
                HPUI_lost();
            }
        }

        void OnParticleCollision(GameObject col)
        {
            int bullet_pow = player_Bullet.PowerBullet();
            Debug.Log("bullet_chage");
            if (col.gameObject.tag == "bullet")
            {
                Debug.Log("Hiiiiit Player");
                HP -= bullet_pow;
                Set_HP();

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

        public int Get_hp()    //現在のHPをセット
        {
            return HP;
        }

        public int Get_Maxhp() //最大HPをセット
        {
            return MAXHP;
        }

        //　死んだらHPバーを非表示にする
        public void HPUI_lost()
        {
            HP_UI.SetActive(false);
        }

        public void UpdateHPValue()  //HPバーの値を更新
        {
            hpSlider.value = (float)Get_hp() / (float)Get_Maxhp();
        }

    }
}
