using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

	//public Rigidbody projectile;
	//public float speed = 100;

	public Rigidbody prefabBullet;
	public float shootForce = 1000f;
	public Transform shootPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//Transform shootPosition;
		if(Input.GetMouseButtonDown(0)) {
			Rigidbody instanceBullet = Instantiate (prefabBullet, transform.position, shootPosition.rotation);
			instanceBullet.GetComponent<Rigidbody>().AddForce (shootPosition.forward * shootForce);
		}
	}
	/*void Update () {
		
		//Transform shootPosition;
		if(Input.GetMouseButtonDown(0)) {
			Rigidbody instanceProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
			instanceProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
		}
	}*/
}
