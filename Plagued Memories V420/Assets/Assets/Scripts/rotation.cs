using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

	// Use this for initialization
	float rot;
	void Start () {
		rot = 90;
	}
	
	// Update is called once per frame
	void Update () {
		
		this.transform.rotation *= Quaternion.Euler(0, rot *Time.deltaTime, 0);
	}
}
