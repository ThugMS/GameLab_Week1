using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region PublicVariables

    #endregion

    #region PrivateVariables
    private float m_speed = 5.0f;
    private float m_jumpPower = 5.0f;

    private bool m_isGround = true;

    private Rigidbody2D m_rigidbody;
    #endregion

    #region PublicMethod
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(int _dir)
    {
        transform.Translate(new Vector3(m_speed * _dir * Time.deltaTime, 0, 0));
    }
    
    public void Jump()
    {
        if(m_isGround)
        {
            m_rigidbody.AddForce(Vector3.up * m_jumpPower, ForceMode2D.Impulse);

            m_isGround = false;
        }
    }

    public void WeakAttack()
    {
        
    }

    public void StrongAttack()
    {

    }
    #endregion

    #region PrivateMethod
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;
        }
    }
    #endregion
}
