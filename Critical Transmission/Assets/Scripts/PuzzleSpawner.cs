using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PuzzleSpawner : NetworkBehaviour {

	public GameObject puzzlePrefab;

	void Start() {
		GameObject foo = Instantiate (puzzlePrefab, transform.position, transform.rotation) as GameObject;
		NetworkServer.Spawn (foo);

	}
}