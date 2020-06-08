using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    //ステージマネージャー関連
    private GameObject stManagerObj;
    private StageManager stManager;

    //マップ画像
    [SerializeField] private Sprite st01;
    [SerializeField] private Sprite st02_1;
    [SerializeField] private Sprite st02_2;
    [SerializeField] private Sprite st03;

    //現在のマップ画像
    private Image mapImage;

    //マップ上のプレイヤーの座標
    private float mapPx;
    private float mapPy;

    //マップの座標値
    private const float st01MapX = 1625f;
    private const float st01MapY = 785f;
    private const float st02MapX = 1565f;
    private const float st02MapY = 695f;
    private const float st03MapX = 1550f;
    private const float st03MapY = 690f;

    //2階の位置
    private const float secondFloorY = 8.0f;

    //プレイヤー関連
    [SerializeField] private GameObject palyerObj;
    [SerializeField] private RectTransform playerTag;
    private Player player;

    //2階であるかどうか
    [SerializeField] private bool isSecondFloor;

    // Start is called before the first frame update
    void Start()
    {
        stManagerObj = GameObject.FindGameObjectWithTag("StageManager");

        stManager = stManagerObj.GetComponent<StageManager>();

        mapImage = this.GetComponentInChildren<Image>();

        player = palyerObj.GetComponent<Player>();

        //初期化処理
        mapPx = 0;
        mapPy = 0;

        isSecondFloor = false;

        //ステージステータスがStage_01のとき
        if (stManager.StageState == StagesState.Stage_01)
        {
            mapImage.sprite = st01;

            playerTag.position = new Vector2((player.transform.position.x * 1.875f) + st01MapX,
                (player.transform.position.z * 1.845f) + st01MapY);
        }

        //ステージステータスがStage_02のとき
        if (stManager.StageState == StagesState.Stage_02)
        {
            mapImage.sprite = st02_1;

            playerTag.position = new Vector2((player.transform.position.x * 2) + st02MapX,
                (player.transform.position.z * 2) + st02MapY);
        }

        //ステージステータスがStage_03のとき
        if (stManager.StageState == StagesState.Stage_03)
        {
            mapImage.sprite = st03;

            playerTag.position = new Vector2((player.transform.position.x * 5.194f) + st03MapX,
                (player.transform.position.z * 5.49f) + st03MapY);
        }

        //プレイヤータグとプレイヤーの角度を同期
        playerTag.rotation = Quaternion.Euler(0f, 0f, -(player.transform.localEulerAngles.y));
    }

    // Update is called once per frame
    void Update()
    {
        //ステージ１の時
        if(stManager.StageState == StagesState.Stage_01)
        {
            //マップ上のプレイヤーの座標を計算
            mapPx = (player.transform.position.x * 1.875f) + st01MapX;
            mapPy = (player.transform.position.z * 1.845f) + st01MapY;
        }

        //ステージ２の時
        if(stManager.StageState == StagesState.Stage_02)
        {
            //マップ上のプレイヤーの座標を計算
            mapPx = (player.transform.position.x * 2) + st02MapX;
            mapPy = (player.transform.position.z * 2) + st02MapY;

            //2階の時
            if (player.transform.position.y >= secondFloorY)
            {
                isSecondFloor = true;
            }
            else
            {
                isSecondFloor = false;
            }

            //マップの反映
            Change_MiniMap();
        }

        //ステージ３の時
        if(stManager.StageState == StagesState.Stage_03)
        {
            //マップ上のプレイヤーの座標を計算
            mapPx = (player.transform.position.x * 5.192f) + st03MapX;
            mapPy = (player.transform.position.z * 5.49f) + st03MapY;
        }

        //座標を適用
        playerTag.position = new Vector2(mapPx, mapPy);

        //回転を適用
        playerTag.rotation = Quaternion.Euler(0f, 0f, -(player.transform.localEulerAngles.y));
    }

    //マップ切り替え
    private void Change_MiniMap()
    {
        if (isSecondFloor)
        {
            mapImage.sprite = st02_2;
        }
        else
        {
            mapImage.sprite = st02_1;
        }
    }
}
