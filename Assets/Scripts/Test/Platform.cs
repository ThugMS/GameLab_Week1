using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    #region PublicVariables
    #endregion
    #region PrivateVariables
    
    public enum PlatformType
    {
        Default,
        Drop,
        Shorten,
        Rotate,
    }

    [SerializeField]
    PlatformType m_platformType;

    [SerializeField]
    float m_lifeTime;

    [SerializeField]
    float m_shortenSpeed;

    [SerializeField]
    float m_shortenLimit;

    [SerializeField]
    float m_RotateLimit;

    [SerializeField]
    float m_RotateSpeed;

    int m_RotateToggle = 1;

    #endregion
    #region PublicMethod
    #endregion
    #region PrivateMethod

    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        switch (m_platformType)
        {
            case PlatformType.Drop:
                StartCoroutine(DropPaltform(m_lifeTime));
                break;
        }
    }

    private void LateUpdate()
    {

        switch (m_platformType)
        {
            case PlatformType.Shorten:
                {
                    if (transform.localScale.x > m_shortenLimit)
                        transform.localScale = new Vector2(transform.localScale.x - (Time.deltaTime * m_shortenSpeed), transform.localScale.y);
                }
                break;
            case PlatformType.Rotate:
                {

                    if (Mathf.Abs(Mathf.Abs(transform.eulerAngles.z) - 180) < 180 - m_RotateLimit)
                        m_RotateToggle = m_RotateToggle * -1;

                    transform.Rotate(Vector3.forward * Time.deltaTime * m_RotateSpeed * m_RotateToggle);
                }
                break;
        }
    }

    public IEnumerator DropPaltform(float _lifeTime = -1)
    {
        if (_lifeTime < 0)
            yield break;

        yield return new WaitForSeconds(_lifeTime);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Collider2D>().isTrigger = true;

    }


    #endregion
}
