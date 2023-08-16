using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
	#region PublicVariables
	public static GameManager instance;
	public UnityEvent onGameStart;
	public UnityEvent onGameEnd;
	#endregion

	#region PrivateVariables
	#endregion

	#region PublicMethod
	public void Awake()
	{
		if (instance == null)
			instance = this;
	}
	public void GameStart()
	{
		onGameStart.Invoke();
	}
	public void GameEnd()
	{
		onGameEnd.Invoke();
	}
	#endregion

	#region PrivateMethod
	#endregion
}
