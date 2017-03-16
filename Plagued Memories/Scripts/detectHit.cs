using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class detectHit : MonoBehaviour {

    public Slider curHP;
    Animator anim;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy_weapon")
        {


            curHP.value -= 4;

            if (curHP.value <= 0)
            {
                anim.SetBool("isDead", true);
            }
        }
    }
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
