using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CountDownHP
{
    public class zako_status : MonoBehaviour
    {
        //HP
        [SerializeField]
        private int HP = 100000;
        //HP表示テキスト/表示される値
        private Text hpText;
        //現在のダメージ量
        private int damage = 0;
        //HPを一度減らしてからの経過時間
        [SerializeField]
        private float countTime = 0f;
        //次にHPを減らすまでの時間
        [SerializeField]
        private float nextCountTime = 1f;

        void Start()
        {
            hpText = GetComponentInChildren<Text>();
            hpText.text = HP.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            //ダメージがなければ何もしない
            if (damage == 0)
            {
                return;
            }
            //一気にHPが減らないように減らす間隔を開ける
            //次に減らす時間がきたら
            if (countTime >= nextCountTime)
            {
                //ダメージ量を10で割った商をHPから減らす
                //トータルダメージを一気に減らすとカウントダウンが出来ない
                //その為トータルダメージを10で割った商を１回で減らすようにする
                var tempDamage = damage / 10;
                //商が0になったら余りを減らす
                if (tempDamage == 0)
                {
                    tempDamage = damage % 10;
                }
                HP -= tempDamage;  //HPにダメージを与える
                countTime = 0f;
                hpText.text = HP.ToString();
                damage -= tempDamage;
        
              

                //HPが0以下になったら敵を削除
                if(HP <= 0)
                {
                    Destroy(gameObject);
                }
            }
            countTime += Time.deltaTime;
          
        }

        /***ダメージ値を追加するメソッド***
         ***ダメージを受けたら呼び出してダメージ値を保持する***/
        public void SetDamage(int damage)
        {
            this.damage = damage;
            countTime = 0f;
        }
    }
}
