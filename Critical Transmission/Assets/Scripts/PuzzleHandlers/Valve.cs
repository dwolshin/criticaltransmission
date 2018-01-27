using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//Valve's pretty okay.
public class Valve : NetworkBehaviour {

	public const float maxValue = 1;
	public const float minValue = 0;
	public float value = 0;
	public float valuePerSecond = 0.2f;

	void Update() {
		TurnValve (true);
	}

	void TurnValve(bool isClockwise) {
		if (!isClockwise) {
			value -= valuePerSecond * Time.deltaTime;
			if (value <= minValue)
				value = minValue;
			else transform.Rotate (new Vector3 (0, -2f, 0), Space.Self);
		}
		if (isClockwise) {
			value += valuePerSecond * Time.deltaTime;
			if (value > maxValue)
				value = maxValue;
			else transform.Rotate (new Vector3 (0, 2f, 0), Space.Self);

		}
	}
}
