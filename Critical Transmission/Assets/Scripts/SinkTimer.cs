using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SinkTimer : NetworkBehaviour {

	//Singleton
	public static SinkTimer s;

	//Bools
	public bool timerRunning = true;
	public bool timerAccelerated = false;

	//Timer
	public const float accelerationAmount = 0.5f;
	public const float maxTime = 120f;
	[SyncVar]
	private float remainingTime;

	void Start() {
		s = this;
		if (isServer) remainingTime = maxTime;
	}

	void Update() {
		if (!isServer)
			return;
		if (timerRunning) {
			remainingTime -= Time.deltaTime;
			if (timerAccelerated) {
				remainingTime -= Time.deltaTime * accelerationAmount;
			}
		}
	}

	public float GetRemainingTime() {
		return remainingTime;
	}
}
