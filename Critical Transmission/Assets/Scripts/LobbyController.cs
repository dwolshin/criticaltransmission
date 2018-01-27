using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LobbyController : NetworkBehaviour {

	public static LobbyController singleton;

	[SyncVar]
	public bool gameRunning = false;

	public GameObject[] players;

	void Start() {

	}

	void StartGame() {
		AssignRoles ();
		MovePlayersToLevel ();
	}


	void AssignRoles() {
		if (players != null) {
			int saboIndex = Random.Range (0, players.Length);

			for (int i = 0; i < players.Length; i++) {
				if (i == saboIndex)
					players [i].GetComponent<PlayerBehaviour> ().role = PlayerBehaviour.Role.sabo;
				else
					players [i].GetComponent<PlayerBehaviour> ().role = PlayerBehaviour.Role.sailor;
			}
		} else {
			Debug.Log ("ERROR: Empty player array.");
		}
	}

	void MovePlayersToLevel() {

	}
}
