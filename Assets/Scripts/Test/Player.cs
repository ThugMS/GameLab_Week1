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
    private int m_dir = 1;
    private float m_speed = 5.0f;
    private float m_jumpPower = 5.0f;
    private float m_weakAttackCoolTime = 0.4f;
    private float m_strongAttackCoolTime = 0.7f;
    private float m_counterCoolTime = 0.7f;
    private float m_hitCoolTime = 0.5f;
    private float m_shieldTime = 1.0f;
    private Color m_playerColor = new Color(1f,1f,1f);

    private bool m_isGround = true;
    private bool m_canMove = true;
    private bool m_isCounter = false;
    private bool m_isShield = false;
    private bool m_isKnockBack = false;

    private Rigidbody2D m_rigidbody;
    private Collider2D m_collider;

    [SerializeField] PlayerSword m_sword;
    [SerializeField] Animator m_animator;
    [SerializeField] GameObject m_body;
    #endregion

    #region PublicMethod
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_collider = GetComponent<Collider2D>();
    }

    public void Move(int _dir)
    {
        if (m_canMove == false)
            return;

        transform.Translate(new Vector3(m_speed * _dir * Time.deltaTime, 0, 0));
        
        if(m_dir != _dir)
        {
            m_dir = _dir;
            transform.localScale = new Vector3(_dir, 1f, 1f);
        }
    }
    
    public void Jump()
    {
        if (m_canMove == false)
            return;

        if (m_isGround)
        {
            m_rigidbody.AddForce(Vector3.up * m_jumpPower, ForceMode2D.Impulse);

            m_isGround = false;
        }
    }

    public void WeakAttack()
    { 
        m_animator.SetTrigger("WeakAttack");

        m_sword.WeakAttack(m_weakAttackCoolTime);
    }

    public void StrongAttack()
    {
        if (m_canMove == false)
            return;

        m_canMove = false;
        //m_animator.SetBool("StrongAttack", true);
        m_animator.SetTrigger("StrongAttack");
        Invoke("SetMovable", m_strongAttackCoolTime);
        

        m_sword.StrongAttack(m_strongAttackCoolTime);
    }

    public void Counter()
    {
        if (m_canMove == false)
            return;

        m_canMove = false;
        m_isCounter = true;

        m_animator.SetTrigger("Counter");
        Invoke("SetMovable", m_counterCoolTime);
        Invoke("SetUncountable", m_counterCoolTime);
    }

    public void Hit()
    {
        if (m_isShield == true)
            return;

        m_canMove = false;
        m_isShield = true;

        m_animator.SetTrigger("Hit");

        StartCoroutine(HitChangeBodyColor());
        Invoke("SetMovable", m_hitCoolTime);
        Invoke("SetShieldFalse", m_shieldTime);

        m_sword.StopAttack();
        
    }

    public void CounterHit()
    {
        if (m_isShield == true)
            return;

        m_canMove = false;
        m_isShield = true;

        m_animator.SetTrigger("CounterHit");

        StartCoroutine(HitChangeBodyColor());
        Invoke("SetMovable", m_hitCoolTime);
        Invoke("SetShieldFalse", m_shieldTime);

        m_sword.StopAttack();
        
    }

    public int GetDirection()
    {
        return m_dir;
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

    private void SetMovable()
    {
        m_canMove = true;
    }

    private void SetUncountable()
    {
        m_isCounter = false;
    }

    private void ResetSwordTag()
    {
        m_sword.tag = "Normal";
    }

    private void SetShieldFalse()
    {
        m_isShield = false;
    }

    private void KnockBack(int _dir)
    {
        if (m_isKnockBack == true)
            return;

        m_isKnockBack = true;

        StartCoroutine(ShowWeakKnockBack(_dir));
        
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        

        if (collision.CompareTag("WeakAttack"))
        {
            GameObject hitplayer = collision.GetComponent<PlayerSword>().m_player;

            if (m_isCounter == true)
            {
                hitplayer.GetComponent<Player>().CounterHit();
            }
            else
            {
                Hit();
                KnockBack(hitplayer.GetComponent<Player>().GetDirection());
            }
            
        }

        if (collision.CompareTag("StrongAttack"))
        {
            GameObject hitplayer = collision.GetComponent<PlayerSword>().m_player;

            Hit();
        }
    }

    IEnumerator HitChangeBodyColor()
    {
        m_body.GetComponent<SpriteRenderer>().color = new Color(1f, 132f/255f, 132f/255f);
        m_playerColor = new Color(1f, 132f / 255f, 132f / 255f);
        yield return new WaitForSeconds(0.1f);

        m_body.GetComponent<SpriteRenderer>().color = Color.white;
        m_playerColor = Color.white;

        StartCoroutine(ShowBodyShield());
    }



    IEnumerator ShowBodyShield()
    {
        int cnt = 0;
        int limit = 6;
        float mul = -0.5f;

        while (cnt < limit)
        {
            m_playerColor.a += mul;
            mul *= -1;
            m_body.GetComponent<SpriteRenderer>().color = m_playerColor;
            cnt++;

            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator ShowWeakKnockBack(int _dir)
    {
        float knockBackSpeed = 15f;
        Debug.Log("Knockback yes");
        float timer = 0f;
        while (true)
        {
            transform.Translate(new Vector3(knockBackSpeed * _dir * Time.deltaTime, 0, 0));
            knockBackSpeed -= 0.1f;
            timer += Time.deltaTime;
            yield return null;

            

            if(timer > 0.3f)
            {
                break;
            }
        }
        m_isKnockBack = false;
    }

    IEnumerator ShowStrongKnockBack(int _dir)
    {
        yield return null;
    }

    
    #endregion
}
