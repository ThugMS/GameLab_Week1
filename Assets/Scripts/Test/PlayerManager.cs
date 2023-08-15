using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region PublicVariables
    #endregion

    #region PrivateVariables
    [SerializeField] private GameObject m_player1;
    [SerializeField] private GameObject m_player2;

    private Player m_player1Controller;
    private Player m_player2Controller;
    #endregion

    #region PublicMethod
    void Start()
    {
        m_player1Controller = m_player1.GetComponent<Player>();
        m_player2Controller = m_player2.GetComponent<Player>();
    }
    void Update()
    {
        //Player1 Action
        if (Input.GetKey(KeyCode.A))
        {
            m_player1Controller.Move(-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_player1Controller.Move(1);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_player1Controller.Jump();
        }

        //Player2 Action
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_player2Controller.Move(-1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            m_player2Controller.Move(1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_player2Controller.Jump();
        }
    }
    #endregion

    #region PublicMethod

    #endregion
}
