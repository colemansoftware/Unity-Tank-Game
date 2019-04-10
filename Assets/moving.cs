using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class moving : NetworkBehaviour {

	// Use this for initialization
	/*void Start () {
		
	}*/
	
	// Update is called once per frame
	void Update () {
		/*This function runs ALL PLayerUNIT Tanks-- not just mine*/

		//lets check if this is our object
		/*if (isLocalPlayer == false) {
			return;
		}*/

		/*
		float forwardRate = 3.0f;
		float turnRate = 2.0f;
		//tanks forward speed action
		float forwardMoveAmount = Input.GetAxis("Vertical") * forwardRate;
		//force of the tanks turn
		float turnForce = Input.GetAxis("Horizontal") * turnRate;
		//rotate tank in action
		transform.Rotate(0, turnForce, 0);
		transform.position += transform.forward * forwardMoveAmount * Time.deltaTime;
		*/
	}
}
