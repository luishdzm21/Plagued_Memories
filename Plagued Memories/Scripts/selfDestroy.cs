﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestroy : MonoBehaviour {

    static Animator anim;
	// Use this for initialization
	void Start () {
        //anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other)
	{
        if (other.gameObject.tag == "Player")
        {
            //anim.SetBool("isDead", true);
            Destroy(gameObject);
        }
	}
}