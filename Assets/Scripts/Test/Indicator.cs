using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Indicator : MonoBehaviour
{
	#region PublicVariables
	public GameObject target;
	public string text;
	public bool isActivated;
	#endregion
	#region PrivateVariables
	[SerializeField] private TextMeshPro m_tmpro;
	[SerializeField] private GameObject m_arrow;
	[SerializeField] List<SpriteRenderer> m_spriteRenderers = new List<SpriteRenderer>();
	private static WaitForSeconds milliseconds100 = new WaitForSeconds(0.03f);
	#endregion
	#region PublicMethod
	public void Update()
	{
		if(isActivated == true)
		{
			ShowDirection();
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			FadeIn();
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			FadeOut();
		}
	}
	public void Activate()
	{
		if (isActivated == true)
			return;
		isActivated = true;
		FadeIn();
	}
	public void Deactivate()
	{
		if (isActivated == false)
			return;
		isActivated = false;
		FadeOut();
	}
	#endregion
	#region PrivatecMethod
	private void FadeIn()
	{
		StartCoroutine(IE_TextFadeIn());
		foreach(SpriteRenderer sr in m_spriteRenderers)
		{
			StartCoroutine(IE_FadeIn(sr));
		}
	}
	private void FadeOut()
	{
		StartCoroutine(IE_TextFadeOut());
		foreach (SpriteRenderer sr in m_spriteRenderers)
		{
			StartCoroutine(IE_FadeOut(sr));
		}
	}
	private IEnumerator IE_FadeIn(SpriteRenderer sr)
	{
		sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
		for (int i = 0; i < 10; ++i)
		{
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.1f * (i + 1));
			yield return milliseconds100;
		}
	}
	private IEnumerator IE_TextFadeIn()
	{
		m_tmpro.color = new Color(m_tmpro.color.r, m_tmpro.color.g, m_tmpro.color.b, 0);
		for (int i = 0; i < 10; ++i)
		{
			m_tmpro.color = new Color(m_tmpro.color.r, m_tmpro.color.g, m_tmpro.color.b, 0.1f * (i + 1));
			yield return milliseconds100;
		}
	}
	private IEnumerator IE_FadeOut(SpriteRenderer sr)
	{
		sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
		for (int i = 0; i < 10; ++i)
		{
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f - 0.1f * (i + 1));
			yield return milliseconds100;
		}
	}
	private IEnumerator IE_TextFadeOut()
	{
		m_tmpro.color = new Color(m_tmpro.color.r, m_tmpro.color.g, m_tmpro.color.b, 0);
		for (int i = 0; i < 10; ++i)
		{
			m_tmpro.color = new Color(m_tmpro.color.r, m_tmpro.color.g, m_tmpro.color.b, 1 - 0.1f * (i + 1));
			yield return milliseconds100;
		}
	}
	private void ShowDirection()
	{

	}
	#endregion
}
