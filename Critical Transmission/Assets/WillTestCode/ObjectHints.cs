using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectHints : MonoBehaviour { 

	public Transform raycaster;
	public int hitLayerNum;
	public float raycastDistance;
	public Text hintBox;

	private RaycastHit outputRay; 
	public LayerMask masker;

	void Update () {

		if (Physics.Raycast (raycaster.position, raycaster.forward, out outputRay, raycastDistance, masker))
			hintBox.text = outputRay.collider.GetComponent<HintMessage> ().instructions;		
	}
}
