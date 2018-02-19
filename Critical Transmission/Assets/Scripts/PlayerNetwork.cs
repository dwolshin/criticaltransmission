using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerNetwork : NetworkBehaviour {
	public GameObject FirstPersonCharacter;
	public GameObject[] CharactersModel;
	//public GameObject VavlePanel;

	public override void OnStartLocalPlayer ()
	{
		GetComponent<FirstPersonController> ().enabled = true;
		FirstPersonCharacter.SetActive (true);
		transform.Find ("UI").gameObject.SetActive (true);
		//GetComponent<MeshRenderer>().material.color = Color.blue;
		//FirstPersonCharacter.GetComponent<MeshRenderer>().material.color = Color.red;

		foreach (GameObject go in CharactersModel) {
			go.SetActive (false);
		}

	}

	void Update()
	{

		//don't execute on the server
		if (!isLocalPlayer) {
			return;
		}
		Ray ray = FirstPersonCharacter.GetComponent<Camera>().ViewportPointToRay (new Vector3 (0.5F, 0.5F,0));

		RaycastHit hit;
		Debug.Log ("casting ray...");
		if (Physics.Raycast (ray, out hit))
			Debug.Log ("looking at " + hit.transform.name);

		{
			if(hit.collider.isTrigger)

				//hitIndex = hit.collider.GetComponent<Interactable> ().index;

				//Transform root = hit.collider.GetComponent<Interactable> ().root;


			if (hit.collider.isTrigger) {
				//Left click
				if (Input.GetButtonDown ("Fire1")) {
					//root.SendMessage ("OnLeftClick", hitIndex);
					Debug.Log ("Triggered " + hit.transform.name);

				}

				//Left hold
				if (Input.GetButton ("Fire1")) {
					Debug.Log ("Triggered " + hit.transform.name);
					//root.SendMessage ("OnLeftClickHold", hitIndex);
				}

				//Right click
				if (Input.GetButtonDown ("Fire2")) {
					Debug.Log ("Triggered " + hit.transform.name);
					//root.SendMessage ("OnRightClick", hitIndex);
				}

				//Right click
				if (Input.GetButton ("Fire2")) {
					Debug.Log ("Triggered " + hit.transform.name);
					//root.SendMessage ("OnRightClickHold", hitIndex);
				}
			}

		}

	}



}