using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private List<UIHeartContainer> m_uiList = new List<UIHeartContainer>();
	#endregion

	#region PublicMethod
	public void DrawUI()
	{
		foreach (UIHeartContainer ui in m_uiList)
		{
			ui.gameObject.SetActive(true);
		}
	}
	public void HideUI()
	{
		foreach (UIHeartContainer ui in m_uiList)
		{
			ui.gameObject.SetActive(false);
		}
	}
	#endregion

	#region PrivateMethod
	#endregion
}
