using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
	#region PublicVariables
	public static GameManager instance;
	public UnityEvent onGameTutorial;
	public UnityEvent onGameStart;
	public UnityEvent onGameEnd;
	public UnityEvent onMainScreen;
    public UnityEvent offMainScreen;
	#endregion

	#region PrivateVariables
	#endregion

	#region PublicMethod
	public void Awake()
	{
		if (instance == null)
			instance = this;
	}
	public void TutorialStart()
	{
		onGameTutorial.Invoke();
	}
	public void GameStart()
	{
		onGameStart.Invoke();
	}
	public void GameEnd()
	{
		onGameEnd.Invoke();
        onMainScreen.Invoke();
    }

	public void OnMainScreen()
	{
		onMainScreen.Invoke();
	}

    public void OffMainScreen()
    {
        offMainScreen.Invoke();
    }
    #endregion

    #region PrivateMethod
    #endregion
}
