using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour {

    public Transform player;
    static Animator anim;
	public Collider sword;
	// Use this for initialization
	void Start () {
		//player = GameObject.FindWithTag ("Player").GetComponent<Transform>();
        anim = this.GetComponent<Animator>();
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("isDead", true);
            //  Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		anim = this.GetComponent<Animator>();
        if (anim.GetBool("isDead") == true)
        {
            return;
        }

        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if(Vector3.Distance(player.position, this.transform.position) < 75 && angle < 60)
        {
            //Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);


            anim.SetBool("isIdle", false);
            if (direction.magnitude > 15)
            {
                this.transform.Translate(0, 0, 0.05f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
				sword.enabled = false;
				sword.isTrigger = false;
            }
            else
            {
				
				sword.enabled = true;
				sword.isTrigger = true;
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
			sword.enabled = false;
			sword.isTrigger = false;
            anim.SetBool("isIdle",true);
            anim.SetBool("isWalking",false);
            anim.SetBool("isAttacking",false);
        }
	}
}
