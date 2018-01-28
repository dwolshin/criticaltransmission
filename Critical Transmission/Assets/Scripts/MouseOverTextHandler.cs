using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverTextHandler : MonoBehaviour {

	public string mouseOverText = "FooBar";

	public string OnLookAt() {
		return mouseOverText;
	}
}
