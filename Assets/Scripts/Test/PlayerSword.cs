using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    #region PublicVariables
    public GameObject m_player;
    #endregion

    #region PrivateVariables
    #endregion

    #region PublicMethod
    public void WeakAttack(float _weakAttackCoolTime)
    {
        Invoke("SetSwordTagWeakAttack", _weakAttackCoolTime / 3);
        Invoke("SetSwordTagNormal", _weakAttackCoolTime / 3 * 2);
    }

    public void StrongAttack(float _strongAttackCoolTime)
    {
        Invoke("SetSwordTagStrongAttack", _strongAttackCoolTime / 3 * 2);
        Invoke("SetSwordTagNormal", _strongAttackCoolTime);
    }
    #endregion

    #region PrivateMethod
    private void SetSwordTagNormal()
    {
        transform.tag = "Normal";
    }

    private void SetSwordTagWeakAttack()
    {
        transform.tag = "WeakAttack";
    }

    private void SetSwordTagStrongAttack()
    {
        transform.tag = "StrongAttack";
    }
    #endregion
}
