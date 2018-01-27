using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UIController : NetworkBehaviour {
	
	public Text sinkTimerText;
	public GameObject saboRoleText;
	public GameObject sailorRoleText;
	public GameObject readyPanel;
	public Text playersConnectedText;
	public GameObject pressSpace;

	public GameObject waitingPanel;
	public Text waitingText;

	// Use this for initialization
	void Start () {
		if (NetworkServer.active) {
			//Show ready interface
			readyPanel.SetActive (true);
		} else {
			waitingPanel.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (SinkTimer.s.timerRunning)
			sinkTimerText.text = SinkTimer.s.GetRemainingTime ().ToString ("#.0");
		else
			//Remove text, replace with empty string
			sinkTimerText.text = "Timer on hold, complain to Greg.";

		if (NetworkServer.active && !GameController.singleton.gameRunning) {
				playersConnectedText.text = "" + NetworkManager.singleton.numPlayers + "/4 PLAYERS";
			if (NetworkManager.singleton.numPlayers == 4) {
				pressSpace.SetActive (true);
				if (Input.GetButtonDown ("Start")) {
					//Start the game
					Debug.Log("GAME STARRRRRRRRRRRRRRRRRRRT");
				}
			}
		}
	}

	public void DisplayRole(PlayerBehaviour.Role role) {
		if (role == PlayerBehaviour.Role.sabo)
			saboRoleText.SetActive (true);
		else
			saboRoleText.SetActive (false);
		if (role == PlayerBehaviour.Role.sailor)
			sailorRoleText.SetActive (true);
		else
			sailorRoleText.SetActive (false);
	}


}
