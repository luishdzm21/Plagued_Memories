using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeAnimationHandler : MonoBehaviour {

	// Use this for initialization
	private Vector3 _lastPlayerPosition;
	private float _playerIdleDelay;
	public AnimationClip walking;
	public AnimationClip idle;
	public AnimationClip attack;
	public float bound;
	public float currentmag;
	Animation anim;

	void Start () {
		bound = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 playerPosition = this.transform.position;

		currentmag = GetComponent<Rigidbody> ().velocity.magnitude;
		if (currentmag > bound) {
			anim = GetComponent<Animation> ();
			anim.CrossFade (idle.name);
		} else {
			anim = GetComponent<Animation> ();
			anim.CrossFade (walking.name);
		}

		_lastPlayerPosition = this.transform.position;


	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag=="Bip001")
			Destroy(gameObject);    
	}
}
