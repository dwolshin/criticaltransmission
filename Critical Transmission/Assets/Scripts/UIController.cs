﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public Text sinkTimerText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		sinkTimerText.text = SinkTimer.s.GetRemainingTime ().ToString("#.00");
	}

	public void ChangeTimer() {
		
	}
}
