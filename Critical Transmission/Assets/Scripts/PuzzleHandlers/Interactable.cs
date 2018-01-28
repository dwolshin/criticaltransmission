using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public int index;
	public string mouseOverText;
	public Transform root;

	// Use this for initialization
	void Start () {
		root = transform.root;
	}
}
