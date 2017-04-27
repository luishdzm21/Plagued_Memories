using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_door : MonoBehaviour {

	// Use this for initialization
	float rot;
	bool twist;
	void Start () {
		rot = 90;
		twist = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		//this.transform.rotation *= Quaternion.Euler(0, rot *Time.deltaTime, 0);
		if(twist)
		transform.RotateAround(transform.position, transform.up, Time.deltaTime * rot);

	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Collision Detected");
		if (other.gameObject.tag == "Player")
		{
			twist = true;
		}
	}
}
