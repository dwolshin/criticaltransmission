using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class Player_Network : NetworkBehaviour {
	public GameObject FirstPersonCharacter;
	public GameObject[] CharactersModel;

	public override void OnStartLocalPlayer ()
	{


		GetComponent<FirstPersonController> ().enabled = true;
		FirstPersonCharacter.SetActive (true);

		foreach (GameObject go in CharactersModel) {
			go.SetActive (false);
		}
	}
}
