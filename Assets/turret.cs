using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//left
		if(Input.GetKey("q")){//left
			transform.Rotate(0, -3, 0);
		}
		//right
		if (Input.GetKey("e")){
			transform.Rotate (0, 3, 0);
		}
		//up
		if (Input.GetKey("r")){//up
			transform.Rotate(-3, 0, 0);
		}
		//down
		if (Input.GetKey("f")){
			transform.Rotate (3, 0, 0);
		}
	}
}
