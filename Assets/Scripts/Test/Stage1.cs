using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1 : MonoBehaviour
{
    #region PublicVariables
    #endregion
    #region PrivateVariables
    Vector3 m_center = Vector3.zero;

    enum Direct
    {
        right,
        left,
    }

    [SerializeField]
    float m_time;

    [SerializeField]
    float m_interval;

    [SerializeField]
    float m_size;

    [SerializeField]
    Vector3 m_platformSize;

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

        MakePlatform(Direct.right);
        MakePlatform(Direct.left);

    }

    void MakePlatform(Direct _direct)
    {
        Vector3 _center = m_center;
        float _time = m_time;

        for (int i = 0; i < m_size; i++)
        {

            GameObject prefab = Resources.Load<GameObject>("Prefabs/DropPlatform");
            GameObject go = Instantiate(prefab);

            go.GetComponent<Platform>().m_delay = _time;
            _time -= m_interval;
            if (_time < 0)
                return;

            go.GetComponent<Transform>().localScale = m_platformSize;

            go.GetComponent<Transform>().position = _center;
            if (_direct == Direct.right)
                _center.x += m_platformSize.x;
            else if (_direct == Direct.left)
                _center.x -= m_platformSize.x;

            go.GetComponent<Platform>().m_quakeRange = m_quakeRange;

            go.transform.SetParent(Paltforms.transform); 

        }
    }

    #endregion

}
