using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionObject : NetworkBehaviour {

	// Use this for initialization
	/*Here we will keep track of the kills and deaths*/
	void Start () {
		//find if this is my local player object
		if (isLocalPlayer == false) {
			//this object belongs to another player
			return;
		}



		//since the player object is invisible, and not part of 
		//the world, give me something that can move around

		Debug.Log ("PlayerConnectionObject::Start -- Spawning Tank Unit.");

		//instantaite only creates an object on the Local computer
		//even if it has a Newtwork is still will not exist on
		//the network (and therefore not on any other client)
		//UNLESS NertworkSever.Spawn() is called on this object

		//Instantiate(TankPrefab);

		//command the server to Spawn the unit
		CmdSpawnMyUnit();
	}

	/*Thing that moves around*/
	public GameObject TankPrefab;

	//SyncVar are variables where if the value changes on the server, all clients are automatically informed
	[SyncVar(hook="OnPlayerNameChanged")]
	public string PlayerName = "Anonymous";


	public Camera myCam;
	public AudioListener myAudioListener;

	// Update is called once per frame
	void Update () {
		//Remeber: Update runs on everyones computer. Even if they do
		//not own this player object
		if (isLocalPlayer == false) {
			return;
		}
//		if (Input.GetKey("w") || Input.GetKey("a")  || Input.GetKey("s") || Input.GetKey("d")){
//			CmdMoveUnit ();
//		}
		if(Input.GetKeyDown(KeyCode.N)){
			CmdSpawnMyUnit ();
		}

		if (Input.GetKeyDown(KeyCode.P)){
			string n = "Cole" + Random.Range(1,10);
			Debug.Log ("Sending the server a request to change our name to " + n);
			CmdChangePlayerName (n);
		}

//		//turn camera on
//		if (isLocalPlayer == true || TankPrefab != null) {
//			if (myCam.enabled == false) {
//				myCam.enabled = true;
//			}
//		}
////			if (myAudioListener.enabled == false) {
////				myAudioListener.enabled == true;
////			}
////		}

	}


	void OnPlayerNameChanged(string newName){
		Debug.Log ("OnPLayerNameChanged: Old name: " + PlayerName + " NewName: " + newName);
		PlayerName = newName;
		gameObject.name= "PlayerConnectionObject ["+newName+"]";
	}

	/******************COMMANDS*******************/
	//commands are special functions that only get executed on the server


	[Command]
	void CmdSpawnMyUnit(){
		//We are guaranteed to be on the server right now.
		GameObject go = Instantiate(TankPrefab);


		//link that belongs to our network behavoir 
		//go.GetComponent<NetworkIdentity> ().AssignClientAuthority (connectionToClient);

		//Object now exists on server, progate it to all
		//the clients and also wire up the NetworkIdentity 
		NetworkServer.SpawnWithClientAuthority(go, connectionToClient);//spawn Registered Spawnable Prefabs
	}
	[Command]
	void CmdChangePlayerName(string n){
		Debug.Log ("CmdPlayerName: " + n);
		PlayerName = n;
	}

}
