using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PressurePuzzle : NetworkBehaviour {

	public Transform[] valves;

	public float[] valveValues;
	public Meter[] meters;
	public float valveTarget = 0.5f;
	public float forgiveness = 0.05f;
	public float valuePerSecond = 0.2f;
	public float minValue = 0;
	public float maxValue = 1f;

	[HideInInspector]
	public bool puzzleComplete = false;
/*
	void Start() {
		if (!isServer) {
			NetworkServer.Spawn (gameObject);
		}
	}
	*/
		
	void Update () {
		if (isServer) {
			puzzleComplete = true;
			for (int i = 0; i < valves.Length; i++) {
				if (i < meters.Length) {
					meters [i].value = valveValues[i];
				}
				if (!Between (valveValues[i], valveTarget - forgiveness, valveTarget + forgiveness)) {
					//valve is not ready
					puzzleComplete = false;

				}
			}

		}
	}

	[ClientRpc]
	void RpcTurnValve(int valveIndex, bool isClockwise) {
		if (!isClockwise) {
			valveValues[valveIndex] -= valuePerSecond * Time.deltaTime;
			if (valveValues[valveIndex] <= minValue)
				valveValues[valveIndex] = minValue;
			else valves[valveIndex].Rotate (new Vector3 (0, -2f, 0), Space.Self);
		}
		if (isClockwise) {
			valveValues[valveIndex] += valuePerSecond * Time.deltaTime;
			if (valveValues[valveIndex] > maxValue)
				valveValues[valveIndex] = maxValue;
			else valves[valveIndex].Rotate (new Vector3 (0, 2f, 0), Space.Self);

		}
	}

	[Command]
	void CmdTurnValve(int index, bool isClockwise) {
		//RpcTurnValve (index, isClockwise);
		if (!isClockwise) {
			valveValues[index] -= valuePerSecond * Time.deltaTime;
			if (valveValues[index] <= minValue)
				valveValues[index] = minValue;
			else valves[index].Rotate (new Vector3 (0, -2f, 0), Space.Self);
		}
		if (isClockwise) {
			valveValues[index] += valuePerSecond * Time.deltaTime;
			if (valveValues[index] > maxValue)
				valveValues[index] = maxValue;
			else valves[index].Rotate (new Vector3 (0, 2f, 0), Space.Self);

		}
	}

	void OnLeftClickHold(int index) {
		
		CmdTurnValve (index, false);
	}

	void OnRightClickHold(int index) {
		CmdTurnValve (index, true);
	}

	public static bool Between(float num, float lower, float upper) {
		return lower <= num && num <= upper;
	}
}