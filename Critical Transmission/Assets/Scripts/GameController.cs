using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour {

	public static GameController singleton;

	[SyncVar]
	public bool gameRunning = false;

	// Use this for initialization
	void Start () {
		singleton = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
