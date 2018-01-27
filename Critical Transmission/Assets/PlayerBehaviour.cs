using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBehaviour : NetworkBehaviour {

	public override void OnStartLocalPlayer()
	{

		transform.Find ("FirstPersonCharacter").gameObject.SetActive(true);
		transform.Find("Cube").GetComponent<MeshRenderer>().material.color = Color.red;
	}
}
