using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESCMenu : MonoBehaviour
{
    #region PublicVariables
    public static bool g_pause = false;
    #endregion

    #region PrivateVariables
    [SerializeField] private GameObject m_escPanel;
    [SerializeField] private GameObject m_stagePanel;

    #endregion

    #region PublicMethod
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            g_pause = !g_pause;
        }

        if(g_pause == true)
        {
            Time.timeScale = 0f;
            if (m_escPanel.activeSelf == false && m_stagePanel.activeSelf == false)
            {
                m_escPanel.SetActive(true);
            }

        }
        else
        {
            m_escPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void PressResumeButton()
    {
        g_pause = !g_pause;
    }

    public void PreesExitButton()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void StageButton()
    {
        m_escPanel.SetActive(false);

        m_stagePanel.SetActive(true);
    }
#endregion

    #region PrivateMethod
    #endregion
}
