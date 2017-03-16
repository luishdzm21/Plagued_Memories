using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Potion_Controller : MonoBehaviour {
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
			otherScriptToAccess.addItem(1, 1);
			Destroy(gameObject);
		}
	}
}
