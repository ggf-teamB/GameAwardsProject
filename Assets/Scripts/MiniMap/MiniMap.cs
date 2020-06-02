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
    private const float miniMapX = 1565f;
    private const float miniMapY = 695f;

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

        isSecondFloor = false;

        //ステージステータスがStage_01のとき
        if (stManager.StageState == StagesState.Stage_01)
        {
            mapImage.sprite = st01;
        }

        //ステージステータスがStage_02のとき
        if (stManager.StageState == StagesState.Stage_02)
        {
            mapImage.sprite = st02_1;

            playerTag.position = new Vector2((player.transform.position.x * 2) + miniMapX,
                (player.transform.position.z * 2) + miniMapY);

            playerTag.rotation = Quaternion.Euler(0f, 0f, -(player.transform.localEulerAngles.y));
        }

        //ステージステータスがStage_03のとき
        if (stManager.StageState == StagesState.Stage_03) mapImage.sprite = st03;
    }

    // Update is called once per frame
    void Update()
    {

        //ステージ２の時
        if(stManager.StageState == StagesState.Stage_02)
        {
            //マップ上のプレイヤーの座標を計算
            mapPx = (player.transform.position.x * 2) + miniMapX;
            mapPy = (player.transform.position.z * 2) + miniMapY;

            //座標を適用
            playerTag.position = new Vector2(mapPx, mapPy);

            //回転を適用
            playerTag.rotation = Quaternion.Euler(0f, 0f, -(player.transform.localEulerAngles.y));

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
