using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldData : MonoBehaviour
{
	#region PublicVariables
	[HideInInspector] public float width;
	[HideInInspector] public float height;
	#endregion
	#region PrivateVariables
	#endregion
	#region PublicMethod
	public void Start()
	{
		width = transform.localScale.x;
		height = transform.localScale.y;
	}
	#endregion
	#region PublicMethod
	#endregion

}
