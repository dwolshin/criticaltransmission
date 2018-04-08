using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ValveHandler : NetworkBehaviour
{
	public float meter1;
	public float valve1;
	public GameObject valvePanel;
	public Transform valvePanelSpawn;

	[SyncVar (hook = "OnValveChanged")]
	public float syncValve1;



	public void Start ()
	{
		
	}
	public override void OnStartLocalPlayer ()
	{
		

	}
	public void Update ()
	{


	
		Debug.Log ("syncValve1 : " + syncValve1 + " network id " + netId);

		if (valve1 != syncValve1){

			syncValve1 = valve1;
			CmdSendValve (valve1);
		}

	}



	[Command]
	void CmdSendValve (float value)
	{

		Debug.Log ("CMD \n value: " + value + " network id " + netId);
		meter1 = value;
		valve1 = value;
		RpcUpdateValve (value);

	}

	[ClientRpc]
	void RpcUpdateValve (float value)
	{
		meter1 = value;
		valve1 = value;
		Debug.Log ("RPC\n value: " + value + " network id " + netId);
	}



	public void OnValveChanged (float value)
	{
		if (isServer) {
			return;
		}

		Debug.Log ("Callback\n value: " + value + " network id " + netId);
		meter1 = value;
		valve1 = value;
		var slider = valvePanel.transform.Find ("Slider1");



	}
}
