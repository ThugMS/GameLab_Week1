using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    #region PublicVariables
    #endregion
    #region PrivateVariables

    [SerializeField]
    Vector3 m_startPoint;

    [SerializeField]
    Vector3 m_platformSize;

    enum Direct
    {
        Right,
        Left,
        Center,
    }

    [SerializeField]
    float m_time;

    [SerializeField]
    float m_interval;

    [SerializeField]
    float m_size;
    
    [SerializeField]
    float m_quakeRange;

    GameObject Paltforms;

    #endregion
    #region PublicMethod
    #endregion
    #region PrivateMethod

    private void Start()
    {
        Paltforms = new GameObject { name = "Platforms" };

        MakePlatform(Direct.Center, m_startPoint);
        MakePlatform(Direct.Right, m_startPoint);
        MakePlatform(Direct.Left, m_startPoint);

    }

    void MakePlatform(Direct _direct, Vector3 _startPoint)
    {
        float _time = m_time;

        if (_direct == Direct.Left)
            _startPoint *= -1f;

        if (_direct == Direct.Center)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/DefaultPlatform");
            GameObject go = Instantiate(prefab);

            go.GetComponent<Transform>().localScale = new Vector3(m_startPoint.x * 2, m_platformSize.y, m_platformSize.z);
            return;
        }
                    
        for (int i = 0; i < m_size; i++)
        {

            GameObject prefab = Resources.Load<GameObject>("Prefabs/DropPlatform");
            GameObject go = Instantiate(prefab);

            go.GetComponent<Platform>().m_delay = _time;
            _time -= m_interval;
            if (_time < 0)
                return;

            go.GetComponent<Transform>().localScale = m_platformSize;

            if (_direct == Direct.Right)
            {
                go.GetComponent<Transform>().position = _startPoint;
                _startPoint.x += m_platformSize.x;
            }
            else if (_direct == Direct.Left)
            {
                go.GetComponent<Transform>().position = _startPoint;
                _startPoint.x -= m_platformSize.x;
            }

            go.GetComponent<Platform>().m_quakeRange = m_quakeRange;

            go.transform.SetParent(Paltforms.transform); 

        }
    }

    #endregion

}
