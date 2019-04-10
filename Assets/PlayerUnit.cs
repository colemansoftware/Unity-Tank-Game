using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerUnit : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	//FOR BULLET
	public GameObject prefabBullet;
	public float shootForce = 1000f;
	public Transform shootPosition;

	
	// Update is called once per frame
	void Update () {
		//true if This is on my computer
		if (hasAuthority == false) {
			return;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			this.transform.Translate (0, 1, 0);
		}

		if (Input.GetKeyDown (KeyCode.M)) {
			Destroy (gameObject);
		}

		/*move target*/
		float forwardRate = 3.0f;
		float turnRate = 2.0f;
		//tanks forward speed action
		float forwardMoveAmount = Input.GetAxis("Vertical") * forwardRate;
		//force of the tanks turn
		float turnForce = Input.GetAxis("Horizontal") * turnRate;
		//rotate tank in action
		transform.Rotate(0, turnForce, 0);
		transform.position += transform.forward * forwardMoveAmount * Time.deltaTime;


		/**************TURRET CONTROLS*************/
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

		//call to fire
		if (Input.GetMouseButtonDown (0)) {
			CmdFire ();
		}

	}

	[Command]
	void CmdFire(){
		//Transform shootPosition;

		GameObject bullet =Instantiate (prefabBullet, transform.position, shootPosition.rotation);
		bullet.GetComponent<Rigidbody>().AddForce (shootPosition.forward * shootForce);

		NetworkServer.Spawn (bullet);
	}
}
