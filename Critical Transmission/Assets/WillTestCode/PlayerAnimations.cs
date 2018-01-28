using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

	public Animator yourPlayer;

	public string RunName;
	public string idleName;
	public string interactingName;
	public bool isMoving;
	public bool alreadyInteracting;


	public bool isInteracting;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!isInteracting) {
			
			if ((Input.GetKeyDown ("Horizontal") || Input.GetKeyDown ("Vertical") && !isMoving)) {
				isMoving = true;
				yourPlayer.SetTrigger (RunName);
			} else {

				if (isMoving) {
					isMoving = false;
					yourPlayer.SetTrigger (idleName);
				}
			}

			alreadyInteracting = false;

		} else {
			
			if (!alreadyInteracting) {
				alreadyInteracting = true;
				yourPlayer.SetTrigger (interactingName);
			}
		}
		
	}
}
