﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBehaviour : NetworkBehaviour {

	public enum Role {unassigned, sailor, sabo};

	public static PlayerBehaviour singleton;

	private const float maxInteractDistance = 1f;

	private Transform currentInteractedObject;

	private GameObject fpsCamera;

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

		if (Input.GetButtonDown("Fire1")) {
			RaycastHit hit;
			//if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, maxInteractDistance)) {

			//}
		}

		if (Input.GetButton("Fire1")) {

		}
	}


}
