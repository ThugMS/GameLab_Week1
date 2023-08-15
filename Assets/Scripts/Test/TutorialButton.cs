using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{
	#region PublicVariables
	#endregion
	#region PrivateVariables
	[SerializeField] KeyCode m_keycode;
	[SerializeField] Animator m_animator;
	#endregion
	#region PublicMethod
	public void Check()
	{
		m_animator.SetBool("check", true);
	}
	public void Initialize()
	{
		m_animator.SetBool("check", false);
	}
	#endregion
	#region PrivateMethod
	#endregion
}
