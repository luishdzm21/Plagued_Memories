using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class detectHitAI : MonoBehaviour
{

    public Slider curHP;
    Animator animAI;
	public Collider sword;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sword")
        {
                animAI.SetBool("isDead", true);
        }
    }
    // Use this for initialization
    void Start()
    {
        animAI = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

		if (animAI.GetCurrentAnimatorStateInfo(0).IsName("Death")) {
			sword.enabled = false;
			sword.isTrigger = false;
		} 
    }
}
