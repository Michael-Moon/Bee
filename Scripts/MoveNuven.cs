﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNuven : MonoBehaviour {

	[SerializeField] private float vel;	
	// Update is called once per frame
	void Update () {

		transform.Translate (vel * Time.deltaTime, 0, 0);
	}
}
