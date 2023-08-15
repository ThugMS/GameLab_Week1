using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region PublicVariables
    public Camera main;
	public CameraShaker shaker;
    #endregion
    #region PrivateVariables
    [SerializeField] private float m_camSpeed;

    [SerializeField] private GameObject m_player1;
    [SerializeField] private GameObject m_player2;

	private const float ZOOM_MIN = 4f;
	private const float ZOOM_MAX = 10f;
	#endregion
	#region PublicMethod
	public void Start()
	{
		shaker.main = this.main;
	}
	public void Update()
    {
        SetCameraState();
    }

	public void AttackShake()
	{
		shaker.AttackShake();
	}
	public void SmashShake()
	{
		shaker.SmashShake();
	}
    #endregion
    #region PrivateMethod
    private void SetCameraState()
    {
		Vector2 destination = GetCameraDestination();
		main.orthographicSize = GetCameraZoomLevel();
		transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * m_camSpeed);
	}
    private Vector3 GetCameraDestination()
    {
		Vector3 centerPosition = Vector3.Lerp(m_player1.transform.position, m_player2.transform.position, 0.5f);
		Vector3 result = new Vector3(centerPosition.x, centerPosition.y, -10);
		return result;
    }
    private float GetCameraZoomLevel()
    {
		float distance = Vector2.Distance(m_player1.transform.position, m_player2.transform.position);
		float result = Mathf.Clamp(ZOOM_MIN + distance / 4, ZOOM_MIN, ZOOM_MAX);
		return result;
	}
    #endregion
}
