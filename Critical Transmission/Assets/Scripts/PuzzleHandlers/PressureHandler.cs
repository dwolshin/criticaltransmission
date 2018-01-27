using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PressureHandler : NetworkBehaviour {

	public Valve[] valves;
	public Meter[] meters;
	public float[] valveTargets;
	public float forgivenessAmount = 0.1f;

	[HideInInspector]
	public bool puzzleComplete = false;

	public static bool Between(float num, float lower, float upper) {
		return lower <= num && num <= upper;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isServer) {
			puzzleComplete = true;
			for (int i = 0; i < valves.Length; i++) {
				if (i < meters.Length) {
					meters [i].value = valves [i].value;
				}
				if (!Between (valves [i].value, valveTargets [i] - forgivenessAmount, valveTargets [i] + forgivenessAmount)) {
					//valve is not ready
					puzzleComplete = false;

				}
			}

		}
	}
}
