using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    #region PublicVariables
    #endregion
    #region PrivateVariables

    Vector2 m_screenDir;
    float m_defaultAngle;

    [SerializeField]
    Transform m_player1;

    [SerializeField]
    GameObject m_indicator1;

    bool m_isActive;

    float m_posX;
    float m_posY;

    [SerializeField]
    float m_offset;

    #endregion
    #region PublicMethod
    #endregion
    #region PrivateMethod

    private void Start()
    {
        m_screenDir = new Vector2(Screen.width, Screen.height);
        m_defaultAngle = Vector2.Angle(Vector2.up, m_screenDir);
    }

    private void Update()
    {
        float angle = Vector2.Angle(Vector2.up, transform.position - m_player1.position);
        int sign = m_player1.transform.position.x < 0 ? -1 : 1;
        angle *= sign;

        Vector3 targetPoint = Camera.main.WorldToViewportPoint(m_player1.position);
        Vector2 centerPoint = new Vector2(targetPoint.x - 0.5f, targetPoint.y - 0.5f);


        if (-m_defaultAngle <= angle && angle <= m_defaultAngle)
        {
            Debug.Log("down");

            m_isActive = centerPoint.y < -0.5f ? true : false;

            m_posY = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.5f, 0)).y;
            m_posX = (m_player1.transform.position.x * m_posY) / m_player1.transform.position.y;

            m_indicator1.transform.position = new Vector3(m_posX, m_posY + m_offset, -1);
        }
        else if (m_defaultAngle <= angle && angle <= 180 - m_defaultAngle)
        {
            Debug.Log("right");

            m_isActive = centerPoint.x > 0.5f ? true : false;

            m_posX = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height * 0.5f)).x * -1;
            m_posY = (m_player1.transform.position.y * m_posX) / m_player1.transform.position.x;

            m_indicator1.transform.position = new Vector3(m_posX - m_offset, m_posY, -1);
        }
        else if (-180 + m_defaultAngle <= angle && angle <= -m_defaultAngle)
        {
            Debug.Log("left");

            m_isActive = centerPoint.x < -0.5f ? true : false;

            m_posX = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height * 0.5f)).x;
            m_posY = (m_player1.transform.position.y * m_posX) / m_player1.transform.position.x;

            m_indicator1.transform.position = new Vector3(m_posX + m_offset, m_posY, -1);
        }
        else if (-180 <= angle && angle <= -180 + m_defaultAngle || 180 - m_defaultAngle <= angle && angle <= 180)
        {
            Debug.Log("up");

            m_isActive = centerPoint.y > 0.5f ? true : false;

            m_posY = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.5f, 0)).y * -1;
            m_posX = (m_player1.transform.position.x * m_posY) / m_player1.transform.position.y;

            m_indicator1.transform.position = new Vector3(m_posX, m_posY - m_offset, -1);
        }

        m_indicator1.SetActive(m_isActive);

        Transform tran = m_indicator1.transform.Find("arrow");
        tran.RotateAround(m_indicator1.transform.position, Vector3.forward, 10);
    }

    #endregion
}
