using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ステージのステータス
public enum StagesState
{
    Stage_01,
    Stage_02,
    Stage_03,
    None
}

public class StageManager : MonoBehaviour
{
    [SerializeField] private StagesState stageState;

    public StagesState StageState
    {
        get { return this.stageState; }
    }

    private void Start()
    {
        stageState = StagesState.None;
    }

    public void SetStage_01()
    {
        stageState = StagesState.Stage_01;
    }

    public void SetStage_02()
    {
        stageState = StagesState.Stage_02;
    }

    public void SetStage_03()
    {
        stageState = StagesState.Stage_03;
    }
}
