using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour {

	public Transform yourPlayer;
	public Transform[] otherPlayers;
	public bool isTraitor;
	[Space(40)]
	public Transform yourDot;
	public Transform[] otherDots;
	public Sprite traitorTexture; 
	public Sprite arrowTexture;
	public float scaleFactor;

	void Start()
	{
		if (!isTraitor) {
			for (int x = 0; x < otherDots.Length; x++) {
				otherDots [x].gameObject.SetActive (false);
			}
		} else {
			yourDot.GetComponent<Image> ().sprite = traitorTexture;
			yourDot.transform.GetChild(0).GetComponent<Image> ().sprite = arrowTexture;
		}

	}

	// Update is called once per frame
	void Update () {

		yourDot.localPosition = new Vector3 (yourPlayer.transform.position.x, yourPlayer.transform.position.z,yourDot.localPosition.z) * scaleFactor;
		yourDot.localRotation = Quaternion.Euler (yourDot.localRotation.eulerAngles.x, yourDot.localRotation.eulerAngles.y, -yourPlayer.localRotation.eulerAngles.y);

		if (isTraitor) {
			for (int x = 0; x < otherDots.Length; x++) {
				otherDots[x].localPosition = new Vector3 (otherPlayers[x].transform.position.x, otherPlayers[x].transform.position.z,otherDots[x].localPosition.z) * scaleFactor;
			}
		}
	}
}
