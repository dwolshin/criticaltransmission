using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBehaviour : NetworkBehaviour {

	public static PlayerBehaviour singleton;

	private const float maxInteractDistance = 1f;

	private Transform currentInteractedObject;

	private GameObject fpsCamera;

	public override void OnStartLocalPlayer()
	{
		singleton = this;
		transform.Find ("UI").gameObject.SetActive (true);
		fpsCamera = transform.Find ("FirstPersonCharacter").gameObject;
		fpsCamera.SetActive(true);
		transform.Find("Cube").GetComponent<MeshRenderer>().material.color = Color.red;
	}

	public void Update() {

		if (Input.GetButtonDown("Fire1")) {
			RaycastHit hit;
			if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, maxInteractDistance)) {

			}
		}

		if (Input.GetButton("Fire1")) {

		}
	}
}
