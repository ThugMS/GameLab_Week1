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

    [SerializeField] Transform m_camera;
    [SerializeField] Transform m_player1;
    [SerializeField] Transform m_player2;

    [SerializeField] GameObject m_indicator1;
    [SerializeField] GameObject m_indicator2;

    bool m_isActive;

    float m_posX;
    float m_posY;

    [SerializeField]
    float m_offset;

    float m_cameraBound = 0.5f;

    #endregion
    #region PublicMethod
    #endregion
    #region PrivateMethod

    private void Start()
    {
       
    }

    private void Update()
    {
        IndicatePlayer(m_player1, m_indicator1);
        IndicatePlayer(m_player2, m_indicator2);
    }

    private void IndicatePlayer(Transform _player, GameObject _indicator)
    {
        Vector3 targetPoint = Camera.main.WorldToViewportPoint(_player.position);
        Vector3 carmeraToTarget = targetPoint - Camera.main.WorldToViewportPoint(m_camera.position);


        #region 최신버전

        if (m_cameraBound <= carmeraToTarget.y)
        {
            //Debug.Log($"up {carmeraToTarget.y}");

            m_isActive = true;

            m_posY = m_cameraBound;
            m_posX = (carmeraToTarget.x * m_posY) / carmeraToTarget.y;

            //if (m_cameraBound <= carmeraToTarget.x)
            //{
            //    _indicator.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0));
            //    _indicator.transform.position += new Vector3(-1, -1, 0) * m_offset;
            //}
            //else if (-m_cameraBound >= carmeraToTarget.x)
            //{
            //    _indicator.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(-1f, 1f, 0));
            //    _indicator.transform.position += new Vector3(1, -1, 0) * m_offset;
            //}
            //else
            //{
                _indicator.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(m_posX + m_cameraBound, m_posY + m_cameraBound, 0));
                _indicator.transform.position += Vector3.down * m_offset;
            //}

            _indicator.transform.position = new Vector3(_indicator.transform.position.x, _indicator.transform.position.y, 0);
        }
        else if (-m_cameraBound >= carmeraToTarget.y)
        {
            // Debug.Log($"down {centerPoint.y}");

            m_isActive = true;

            m_posY = -m_cameraBound;
            m_posX = (carmeraToTarget.x * m_posY) / carmeraToTarget.y;

            _indicator.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(m_posX + m_cameraBound, m_posY + m_cameraBound, 0));
            _indicator.transform.position += Vector3.up * m_offset;
            _indicator.transform.position = new Vector3(_indicator.transform.position.x, _indicator.transform.position.y, 0);
        }
        else if (m_cameraBound <= carmeraToTarget.x)
        {
            //Debug.Log($"right {centerPoint.y}");

            m_isActive = true;

            m_posX = m_cameraBound;
            m_posY = (carmeraToTarget.y * m_posX) / carmeraToTarget.x;

            _indicator.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(m_posX + m_cameraBound, m_posY + m_cameraBound, 0));
            _indicator.transform.position += Vector3.left * m_offset;
            _indicator.transform.position = new Vector3(_indicator.transform.position.x, _indicator.transform.position.y, 0);
        }
        else if (-m_cameraBound >= carmeraToTarget.x)
        {
            //Debug.Log($"left {centerPoint.y}");

            m_isActive = true;

            m_posX = -m_cameraBound;
            m_posY = (carmeraToTarget.y * m_posX) / carmeraToTarget.x;

            _indicator.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(m_posX + m_cameraBound, m_posY + m_cameraBound, 0));
            _indicator.transform.position += Vector3. right * m_offset;
            _indicator.transform.position = new Vector3(_indicator.transform.position.x, _indicator.transform.position.y, 0);
        }
        else
            m_isActive = false;

		#endregion

        _indicator.SetActive(m_isActive);

        //Transform tran = _indicator.transform.Find("arrow");
        //tran.RotateAround(_indicator.transform.position, Vector3.forward, 10);
    }
    #endregion
}
