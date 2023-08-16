using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMenu : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region PrivateVariables

    
    [SerializeField] Vector3 m_playerPos1 = new Vector3(-5f, 5f, 0);
    [SerializeField] Vector3 m_playerPos2 = new Vector3(5f, 5f, 0);

    [SerializeField] private GameObject m_stagePanel;
    [SerializeField] private GameObject m_stage1;
    [SerializeField] private GameObject m_stage2;
    [SerializeField] private GameObject m_stage3;

    #endregion

    #region PublicMethod
    #endregion

    #region PrivateMethod

    public void ChooseTutorial()
    {
        
    }

    public void ChooseStage1()
    {
        m_stage1.GetComponent<Stage1>().StageStart();
        SpawnPlayers();

        HideStagePanel();
    }

    public void ChooseStage2()
    {
        m_stage2.GetComponent<Stage2>().StageStart();
        SpawnPlayers();

        HideStagePanel();
    }

    public void ChooseStage3()
    {
        m_stage3.GetComponent<Stage3>().StageStart();
        SpawnPlayers();

        HideStagePanel();
    }

    private void SpawnPlayers()
    {
        PlayerManager.instance.m_player1.transform.position = m_playerPos1;
        PlayerManager.instance.m_player2.transform.position = m_playerPos2;
    }

    public void HideStagePanel()
    {
        m_stagePanel.SetActive(false);
    }

    #endregion


}
