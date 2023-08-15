using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{
	#region PublicVariables
	#endregion
	#region PrivateVariables
	[SerializeField] TutorialRoom m_room;

	[SerializeField] Animator m_animator;

	#endregion
	#region PublicMethod
	public void OnEnable()
	{
		Initialize();
	}
	public void Check()
	{
		m_animator.SetBool("check", true);
		m_room.ButtonChecked();
	}
	public void Initialize()
	{
		m_animator.SetBool("check", false);
	}
	#endregion
	#region PrivateMethod
	#endregion
}
