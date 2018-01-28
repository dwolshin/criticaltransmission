using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintMessage : MonoBehaviour {

	//just used to hold the specific instruction
	public string instructions;

	void Start()
	{
		gameObject.layer = 8; //set it to the interactive object layer
	}
}
