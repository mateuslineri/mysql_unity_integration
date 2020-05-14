using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class TabBetween: MonoBehaviour 
{
	public InputField nextField;
	InputField actualField;

	void Start() 
	{
		if (nextField == null) {
			Destroy(this);
			return;
		}
		actualField = GetComponent < InputField > ();
	}

	void Update() 
	{
		if (actualField.isFocused && Input.GetKeyDown(KeyCode.Tab)) {
			nextField.ActivateInputField();
		}
	}
}