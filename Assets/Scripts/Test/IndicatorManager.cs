using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{
	#region PublicVariables
	#endregion
	#region PrivateVariables
	[SerializeField] private Camera m_camera;
	[SerializeField] List<GameObject> m_targets = new List<GameObject>();
	[SerializeField] List<Indicator> m_indicators = new List<Indicator>();

	private Vector2 m_cameraPos
	{
		get
		{
			return m_camera.transform.position;
		}
	}
	[SerializeField] private float m_borderYMin => m_cameraPos.y - m_camera.orthographicSize;
	[SerializeField] private float m_borderYMax => m_cameraPos.y + m_camera.orthographicSize;
	[SerializeField] private float m_borderXMin => m_cameraPos.x - m_camera.orthographicSize * (Screen.width / Screen.height);
	[SerializeField] private float m_borderXMax => m_cameraPos.x + m_camera.orthographicSize * (Screen.width / Screen.height);
	#endregion
	#region PublicMethod
	public void Update()
	{
		for(int i = 0; i < m_targets.Count; ++i)
		{
			if (IsObjectInScreen(m_targets[i]) == true)
			{
				//m_indicators[i].Deactivate();
			}
			else
			{
				//m_indicators[i].Activate();
			}
		}
	}
	#endregion
	#region PrivateMethod
	private bool IsObjectInScreen(GameObject target)
	{
		Vector2 targetPos = target.transform.position;
		if(targetPos.x > m_borderXMin && targetPos.x < m_borderXMax
			&& targetPos.y > m_borderYMin && targetPos.y < m_borderYMax)
		{
			return true;
		}
		return false;
	}
	#endregion
}
