using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransmissionBar : MonoBehaviour {

	public Text systemsCount;
	public int totalSystemCount;
	public int fixedSystemCount;
	public Transform barToRaise;
	public float raiseRate;
	public float raiseCount;

	private int oldSystemCount = -1;
	public float winCount;

	private int counter;
	private bool haveWon;

	void Update () {

		if (oldSystemCount != fixedSystemCount) {
			systemsCount.text = "Active Systems: " + fixedSystemCount + " / " + totalSystemCount;
			oldSystemCount = fixedSystemCount;
		}

		if (!haveWon && totalSystemCount == fixedSystemCount)			
			RaiseBar ();
	}

	void RaiseBar()
	{
		barToRaise.localPosition+= new Vector3(0, Time.deltaTime * raiseRate ,0);
		raiseCount += Time.deltaTime * raiseRate;

		if (raiseCount >= winCount) {
			haveWon = true;
			WinFunction ();
		}
	}

	void WinFunction()
	{
		//call the code to bring up the lose or win screen, depending on which team you're on.
	}
}
