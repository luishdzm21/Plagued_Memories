using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public float acc;
	bool open;
	public Transform player;
	public GameObject inventory;
	private Items otherScriptToAccess;

	void Start () {
		otherScriptToAccess = inventory.GetComponent<Items> ();
		speed = 5f;
		acc = 1f;
		open = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 direction = player.position - this.transform.position;
		if (Input.GetKeyDown (KeyCode.E) && direction.magnitude < 15 && otherScriptToAccess.removeItem(3, 1)) {
			
			open = true;
		}

		if (open) {
			transform.position += new Vector3 (0, speed * Time.deltaTime, 0);
			speed += acc;
		}
		if (transform.position.y > 300) {
			Destroy(gameObject);
		}
	}
}
