using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialRoom : MonoBehaviour
{
	#region PublicVariables
	#endregion
	#region PrivateVariables

	[SerializeField] private FieldData m_field;
	[SerializeField] private GameObject m_floor;

	[SerializeField] private List<TutorialButton> m_buttons = new List<TutorialButton>();
	[SerializeField] private int m_count = 0;
	#endregion
	#region PublicMethod
	public void OnEnable()
	{
		Initialize();
	}
	public void Initialize()
	{
		m_floor.SetActive(true);
		m_count = 0;
		foreach(TutorialButton button in m_buttons)
		{
			button.Initialize();
		}
	}
	public void ButtonChecked()
	{
		++m_count;
		if(m_count >= m_buttons.Count)
		{
			Initialize();
			TutorialEnd();
		}
	}
	#endregion
	#region PrivateMethod
	private void TutorialEnd()
	{

		CameraController.instance.SetFieldData(m_field);
		m_floor.SetActive(false);
	}
	#endregion
}
