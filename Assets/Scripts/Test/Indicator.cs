using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    #region PublicVariables
    #endregion
    #region PrivateVariables
    #endregion
    #region PublicMethod
    #endregion
    #region PrivateMethod
    #endregion

    Vector2 m_screenDir;
    float m_defaultAngle;

    [SerializeField]
    Transform m_player;

    [SerializeField]
    GameObject m_indicator1;

    bool isActive;

    float posX;
    float posY;

    private void Start()
    {
        m_screenDir = new Vector2(Screen.width, Screen.height);
        m_defaultAngle = Vector2.Angle(Vector2.up, m_screenDir);
    }

    private void Update()
    {
        float angle = Vector2.Angle(Vector2.up, transform.position - m_player.position);
        int sign = m_player.transform.position.x < 0 ? -1 : 1;
        angle *= sign;

        Vector3 targetPoint = Camera.main.WorldToViewportPoint(m_player.position);
        Vector2 centerPoint = new Vector2(targetPoint.x - 0.5f, targetPoint.y - 0.5f);


        if (-m_defaultAngle <= angle && angle <= m_defaultAngle)
        {
            Debug.Log("down");

            isActive = centerPoint.y < -0.5f ? true : false;

            posY = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.5f, 0)).y;
            posX = (m_player.transform.position.x * posY) / m_player.transform.position.y;
        }
        else if (m_defaultAngle <= angle && angle <= 180 - m_defaultAngle)
        {
            Debug.Log("right");

            isActive = centerPoint.x > 0.5f ? true : false;

            posX = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height * 0.5f)).x * -1;
            posY = (m_player.transform.position.y * posX) / m_player.transform.position.x;
        }
        else if (-180 + m_defaultAngle <= angle && angle <= -m_defaultAngle)
        {
            Debug.Log("left");

            isActive = centerPoint.x < -0.5f ? true : false;

            posX = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height * 0.5f)).x;
            posY = (m_player.transform.position.y * posX) / m_player.transform.position.x;
        }
        else if (-180 <= angle && angle <= -180 + m_defaultAngle || 180 - m_defaultAngle <= angle && angle <= 180)
        {
            Debug.Log("up");

            isActive = centerPoint.y > 0.5f ? true : false;

            posY = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.5f, 0)).y * -1;
            posX = (m_player.transform.position.x * posY) / m_player.transform.position.y;
        }

        m_indicator1.transform.position = new Vector3(posX, posY, -1);
        m_indicator1.SetActive(isActive);
    }

}
