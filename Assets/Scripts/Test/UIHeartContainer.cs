using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeartContainer : MonoBehaviour
{
	#region PublicVariables
	#endregion

	#region PrivateVariables
	[SerializeField] private List<UIHeart> m_hearts = new List<UIHeart>();
	private static WaitForSeconds m_heartsGenerateDelay = new WaitForSeconds(0.15f);
	private int index;
	#endregion

	#region PublicMethod
	public void Start()
	{
		Initialize();
	}
	public void Initialize()
	{
		index = 0;
		foreach (UIHeart heart in m_hearts)
		{
			heart.Initialize();
		}
	}
	public void Pop()
	{
		m_hearts[index].Pop();
		++index;
		if(index >= m_hearts.Count)
		{
			HeartCountOut();
		}
	}
	#endregion

	#region PrivateMethod
	private void HeartCountOut()
	{
		Debug.Log("Heart Out!");
	}
	#endregion
}
