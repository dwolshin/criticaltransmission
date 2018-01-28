using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerNetwork : NetworkBehaviour {
	public GameObject FirstPersonCharacter;
	public GameObject[] CharactersModel;
	public GameObject[] panels;

	public override void OnStartLocalPlayer ()
	{
		GetComponent<FirstPersonController> ().enabled = true;
		FirstPersonCharacter.SetActive (true);
		transform.Find ("UI").gameObject.SetActive (true);
		//FirstPersonCharacter.GetComponent<MeshRenderer>().material.color = Color.red;

		foreach (GameObject go in CharactersModel) {
			go.SetActive (false);
		}
	}
}