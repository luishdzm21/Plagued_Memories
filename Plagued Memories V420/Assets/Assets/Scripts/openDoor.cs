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
	public AudioClip shootSound;

	private Items otherScriptToAccess;
	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;
    private ActivateTextAtLine accessText;

	void Start () {
		otherScriptToAccess = inventory.GetComponent<Items> ();
		speed = 5f;
		acc = 1f;
		open = false;
		source = GetComponent<AudioSource>();
        accessText = GetComponent<ActivateTextAtLine>();
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 direction = player.position - this.transform.position;
        if (direction.magnitude < 15 && otherScriptToAccess.items[3] > 0) {
            accessText.requireButtonPress = true;
        }
        if (Input.GetKeyDown (KeyCode.E) && direction.magnitude < 15 && otherScriptToAccess.removeItem(3, 1)) {
			float vol = Random.Range (volLowRange, volHighRange);
			//source.Play(shootSound);
			source.loop = true;
			source.clip = shootSound;
			source.Play ();
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
