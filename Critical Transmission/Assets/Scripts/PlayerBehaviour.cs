using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBehaviour : NetworkBehaviour {

	public enum Role {unassigned, sailor, sabo};

	public static PlayerBehaviour singleton;

	private const float maxInteractDistance = 1f;

	private Transform currentInteractedObject;

	public Transform fpsCamera;

	private Role _role;

	public Role role {
		set {
			if (value == null) {
				_role = Role.unassigned;
				return;
			}
			_role = value;
			if (!isLocalPlayer) return;
			GetComponentInChildren<UIController> ().DisplayRole (_role);
		}
		get {return _role; }
	}

	public override void OnStartLocalPlayer()
	{
		singleton = this;
		role = Role.unassigned;
	}

	public void Update() {

		RaycastHit hit;
		int hitIndex;
		if (Physics.Raycast(fpsCamera.position, fpsCamera.forward, out hit, maxInteractDistance)) {

			hitIndex = hit.collider.GetComponent<Interactable> ().index;
			Transform root = hit.collider.GetComponent<Interactable> ().root;

			//Mouseover text

			//Left click
			if (Input.GetButtonDown("Fire1")) {
				root.SendMessage ("OnLeftClick", hitIndex);
			}

			//Left hold
			if (Input.GetButton("Fire1")) {
				root.SendMessage ("OnLeftClickHold", hitIndex);
			}

			//Right click
			if (Input.GetButtonDown ("Fire2")) {
				root.SendMessage ("OnRightClick", hitIndex);
			}

			//Right click
			if (Input.GetButton ("Fire2")) {
				root.SendMessage ("OnRightClickHold", hitIndex);
			}


		}

		//Left Click down

	}


}
