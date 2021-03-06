using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ValvePressureHandler : NetworkBehaviour
{

	public float[] valveTargets = new float[] { 0.2f, 0.5f, 0.7f };
	public float[] valveStartValues = new float[] { 0.3f, 0.6f, 0.8f };
	public float[] valveCurrentValues = new float[] { 0f, 0f, 0f };
	public float forgivenessAmount = 0.1f;
	public Meter[] meters = new Meter[3];
	public Valve[] valves = new Valve[3];
	GameObject myobj;

	public SyncListFloat valveValues = new SyncListFloat ();



	public static bool Between (float num, float lower, float upper)
	{
		return lower <= num && num <= upper;
	}


	public void Update ()
	{
			



			for (int i = 0; i < valveValues.Count; i++) {
				
				
				valveValues [i] = valveCurrentValues [i];

				meters [i].value = valveValues [i];

				Debug.Log ("valveValues " + i + " is : " + valveValues [i] + " on client " + netId);


			}


		if (isLocalPlayer) {

			if (isServer) {

				for (int i = 0; i < valveCurrentValues.Length; i++) {
				
					//valveValues [i] = valveCurrentValues [i];
					//meters[i].value = valveCurrentValues [i];

				}


				
			}
			if (isClient) {



			}
			

		}
	}

	public  void Start ()
	{
		
	}



	private void OnTurnValves (SyncListFloat.Operation op, int index)
	{



		if (isLocalPlayer) {
			Debug.Log ("CALLBACK LOCALPLAYER \n Turnvalve index is: " + index);
			Debug.Log ("   Setting synclist value: " + valveValues [index] + " to current value " + valveCurrentValues [index]);
			meters [index].value = valveValues [index];
			return;

		}

		if (isClient) {
			valveCurrentValues [index] = valveValues [index];

			Debug.Log ("CALLBACK CLIENT\n Turnvalve index is: " + index);
			Debug.Log ("   Sending CMD to set server Synclist  to: " + valveCurrentValues [index]);



			CmdServerSetValve (index, valveCurrentValues [index]);  // Tell the server to set the valve

		}
		//meters [index].value = valveValues [index];
	


	}



	public override void OnStartClient ()
	{
		//assign callback for when synclist updates

		valveValues.Callback = OnTurnValves;


//		for (int i = 0; i < valveStartValues.Length; i++) {
//			
//			CmdServerAddValve (valveStartValues [i]);  // Tell the server to set the valve
//		
//			valveCurrentValues [i] = valveStartValues [i];
//		}

	}

	public override void OnStartServer ()
	{
		
		Debug.Log ("Starting Server with netID: " + netId);

		for (int i = 0; i < valveStartValues.Length; i++) {

		
			Debug.Log ("Setting start values -> current values: " + valveStartValues [i] );
			valveCurrentValues [i] = valveStartValues [i];
			valveValues.Add (valveStartValues [i]);
			Debug.Log ("added synclist value at index: " + i + " to value: " + valveValues [i]);

		}
     

	}


	[Command]
	public void CmdServerSetValve (int i, float value)  // When the server is told to set the valves
	{
		
		Debug.Log ("CMD setting index  " + i + " to value:  " + value + "on client" + netId);
			meters [i].value = value;
			valveValues [i] = value;

	
	}


	public void SetValve (int i, float value)  // When the server is told to set the valves
	{

	//	Debug.Log ("CMD setting index  " + i + " to value:  " + value + "on client" + netId);
		meters [i].value = value;
		valveValues [i] = value;


	}


	//	[Command]
	//	public void CmdServerAddValve (float value)  // When the server is told to set the valves
	//	{
	//
	//		//meters [i].value = value;
	//
	//		Debug.Log ("Server adding value:  " + value + " via CMD");
	//		valveValues.Add (value);
	//
	//
	//
	//
	//
	//	}



}