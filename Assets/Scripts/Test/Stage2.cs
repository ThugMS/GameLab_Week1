using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : BaseStage
{
    #region PublicVariables
    #endregion

    #region PrivateVariables

     [SerializeField] GameObject[] m_platforms;

    #endregion

    #region PublicMethod
    #endregion

    #region PrivateMethod

    public override void StageStart()
    {

        MakePlatform();
    }

    void MakePlatform()
    {
        foreach (GameObject platform in m_platforms)
        {
            platform.SetActive(true);
        }
    }

    #endregion


}
