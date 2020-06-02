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

    private Image mapImage;

    //プレイヤー関連
    [SerializeField] private GameObject palyerObj;
    private Player player;

    //フロアが変わるかどうか
    private bool isChangeFloor;

    //2階であるかどうか
    [SerializeField] private bool isSecondFloor;

    // Start is called before the first frame update
    void Start()
    {
        stManagerObj = GameObject.FindGameObjectWithTag("StageManager");

        stManager = stManagerObj.GetComponent<StageManager>();

        mapImage = this.GetComponentInChildren<Image>();

        player = palyerObj.GetComponent<Player>();

        isChangeFloor = false;
        isSecondFloor = false;

        //ステージステータスがStage_01のとき
        if (stManager.StageState == StagesState.Stage_01) mapImage.sprite = st01;

        //ステージステータスがStage_02のとき
        if (stManager.StageState == StagesState.Stage_02) mapImage.sprite = st02_1;

        //ステージステータスがStage_03のとき
        if (stManager.StageState == StagesState.Stage_03) mapImage.sprite = st03;
    }

    // Update is called once per frame
    void Update()
    {
        if(stManager.StageState == StagesState.Stage_02)
        {

            if (player.transform.position.y >= 8.0f)
            {
                isSecondFloor = true;
            }
            else
            {
                isSecondFloor = false;
            }

            Change_MiniMap();
        }
    }

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
