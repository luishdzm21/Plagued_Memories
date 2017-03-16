using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CangFootmanAnimation : MonoBehaviour {

    // Use this for initialization
    Animator anim;
    public int velocity;
    public int rspeed;
    public AnimationClip attack;
    public AnimationClip idle;
    int hp;
    void Start()
    {
        hp = 20;
        velocity = 20;
        rspeed = 90;
    }

    // Update is called once per frame
    void Update()
    {
        //if hp = <0 die
        anim = GetComponent<Animator>();

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("walk", true);
            this.transform.position += this.transform.forward * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.rotation *= Quaternion.Euler(0, -rspeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.rotation *= Quaternion.Euler(0, rspeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("walk", true);
            this.transform.position += this.transform.forward * -velocity * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("attack", true);
        }

    }

    void takeDMG(int dmg)
    {
        hp = hp - dmg;

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "item")
            Destroy(other.gameObject);
    }
}
