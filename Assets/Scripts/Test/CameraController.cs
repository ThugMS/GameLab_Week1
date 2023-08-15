using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region PublicVariables
    public Camera main;
    #endregion
    #region PrivateVariables
    [SerializeField] private float m_camSpeed;

    [SerializeField] private GameObject m_field;
    [SerializeField] private GameObject m_player1;
    [SerializeField] private GameObject m_player2;

	private const float ZOOM_MIN = 4f;
	private const float ZOOM_MAX = 10f;
    #endregion
    #region PublicMethod
    public void Update()
    {
        SetCameraState();
    }
    
    public void ShakeCamera()
    {
		
    }
    #endregion
    #region PrivateMethod
    private void SetCameraState()
    {
        transform.position = GetCameraPosition();
        main.orthographicSize = GetCameraZoomLevel();
    }
    private Vector3 GetCameraPosition()
    {
		Vector3 centerPosition = Vector3.Lerp(m_player1.transform.position, m_player2.transform.position, 0.5f);
		float clampX = Mathf.Clamp(centerPosition.x, 0, 100);
		float clampY = Mathf.Clamp(centerPosition.y, 0, 100);
		Vector3 result = new Vector3(clampX, clampY, -10);
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
