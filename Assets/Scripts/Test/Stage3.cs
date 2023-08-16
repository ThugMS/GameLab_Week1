using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3 : BaseStage
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
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
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(true);
    }

    #endregion


}
