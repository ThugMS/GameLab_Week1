using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    #region PublicVariables
    public GameObject m_player;
    #endregion

    #region PrivateVariables
    private bool isHit = false;
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

    public void StopAttack()
    {
        SetSwordTagNormal();
        isHit = true;

        Invoke("ResetIsHit", 1f);
    }
    #endregion

    #region PrivateMethod
    private void SetSwordTagNormal()
    {
        transform.tag = "Normal";
    }

    private void SetSwordTagWeakAttack()
    {
        if (isHit == true)
        {
            isHit = false;
            return;
        }

        transform.tag = "WeakAttack";
    }

    private void SetSwordTagStrongAttack()
    {
        if (isHit == true)
        {
            isHit = false;
            return;
        }

        transform.tag = "StrongAttack";
    }

    private void ResetIsHit()
    {
        isHit = false;
    }
    #endregion
}
