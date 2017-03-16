﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money_Controller : MonoBehaviour {
	public GameObject inventory;
	private Items otherScriptToAccess;
	// Use this for initialization
	void Start () {
		otherScriptToAccess = inventory.GetComponent<Items> ();
	}

	// Update is called once per frame
	void Update () {

	}
	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			otherScriptToAccess.addItem(0, 1);
			Destroy(gameObject);
		}
	}
}
