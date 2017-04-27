using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class detectHit : MonoBehaviour {

    public Slider curHP;
    Animator anim;
	public AudioClip shootSound;

	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy_weapon")
        {

			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(shootSound,vol);

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
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
