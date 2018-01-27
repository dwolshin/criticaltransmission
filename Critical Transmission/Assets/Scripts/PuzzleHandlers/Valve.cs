using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Valve's pretty okay.
public class Valve : MonoBehaviour {

	public const float maxValue = 1;
	public const float minValue = 0;
	public float value = 0;
	public float valuePerSecond;

	void Update() {
		TurnValve (false);
	}

	void TurnValve(bool isClockwise) {
		if (!isClockwise) {
			value -= valuePerSecond * Time.deltaTime;
			if (value < minValue)
				value = minValue;
			transform.Rotate (new Vector3 (0, 0, -5f), Space.Self);
		}
		if (isClockwise) {
			value += valuePerSecond * Time.deltaTime;
			if (value > maxValue)
				value = maxValue;
			transform.Rotate (new Vector3 (0, 0, 5f), Space.Self);

		}
	}
}
