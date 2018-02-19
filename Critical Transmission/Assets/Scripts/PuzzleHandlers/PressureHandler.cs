using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PressureHandler : NetworkBehaviour
{

	public float[] valveTargets = new float[] { 0.2f, 0.5f, 0.7f };
	public float[] valveStartValues = new float[] { 0.3f, 0.6f, 0.8f };
	public float[] valveCurrentValues = new float[] { 0f, 0f, 0f };
	public float forgivenessAmount = 0.1f;
	public Meter[] meters = new Meter[3];
	public Valve[] valves = new Valve[3];

	public SyncListFloat valveValues;



	public static bool Between (float num, float lower, float upper)
	{
		return lower <= num && num <= upper;
	}

	// Use this for initialization
	void Update ()
	{
		if (isServer) {
			return;
		}

	

			
	}

	public  void Start ()
	{
		if (isServer) {
			for (int i = 0; i < valveStartValues.Length; i++) {
				valveValues.Add (valveStartValues [i]);

			}
		}
	}


	public void OnTurnValves (SyncListFloat.Operation op, int index)
	{
		Debug.Log ("valve " + index + " operation " + op);

		Debug.Log ("current value at that index is" + valveCurrentValues [index]);

		valveCurrentValues [index] = valveValues [index];
		valves [index].value = valveValues [index];



	}

	public override void OnStartClient ()
	{
		//assign callback for when synclist updates
		valveValues.Callback = OnTurnValves;

			
	}




}