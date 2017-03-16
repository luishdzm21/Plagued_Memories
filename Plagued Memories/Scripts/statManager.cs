//using System.Collections;
using UnityEngine;
using System.Collections;


public class statManager : MonoBehaviour
{
    static Animator anim;
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
	public Collider sword;
	static int attackState = Animator.StringToHash("Base.Footman_Attack");
    void Start()
    {
		
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("isDead", true);
          //  Destroy(gameObject);
			if (other.gameObject.tag == "item")
				Destroy (other.gameObject); 
        }
    }

    private void Update()
    {
        if (anim.GetBool("isDead") == true)
        {
            return;
        }

        float translation = Input.GetAxis("Vertical") * speed;
        float straffle = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffle *= Time.deltaTime;

        transform.Translate(straffle, 0, translation);

		//currentBaseState = anim.GetCurrentAnimatorClipInfo (0);
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Footman_Attack")) {
			sword.enabled = true;
			sword.isTrigger = true;
		} else {
			sword.enabled = false;
			sword.isTrigger = false;
		}

		if (Input.GetMouseButton(0))
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }


        if(translation != 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

}



//public class statManager : MonoBehaviour {

//	// Use this for initialization
//	Animator anim;
//	public int velocity;
//	public int rspeed;
//	public AnimationClip attack;
//	public AnimationClip idle;
//	int hp;
//	void Start () {
//		hp = 20;
//		velocity = 20;
//		rspeed = 90;
//	}
	
//	// Update is called once per frame
//	void Update () {
//		//if hp = <0 die
//		anim = GetComponent<Animator> ();
	
//		if (Input.GetKey (KeyCode.W)) {
//			anim.SetBool("walk", true);
//			this.transform.position += this.transform.forward * velocity *Time.deltaTime;
//		}
//		if (Input.GetKey (KeyCode.A)) {
//			this.transform.rotation *= Quaternion.Euler (0, -rspeed * Time.deltaTime, 0);
//		}
//		if (Input.GetKey (KeyCode.D)) {
//			this.transform.rotation *= Quaternion.Euler (0, rspeed * Time.deltaTime, 0);
//		}
//		if (Input.GetKey (KeyCode.S)) {
//			anim.SetBool("walk", true);
//			this.transform.position += this.transform.forward * -velocity *Time.deltaTime;
//		}
//		if (Input.GetKeyDown(KeyCode.Space)) {
//			anim.SetBool("attack", true);
//		} 
			
//	}

//	void takeDMG(int dmg){
//		hp = hp - dmg;
	
//	}

//	void OnCollisionEnter(Collision other)
//	{
//		if (other.gameObject.tag == "item")
//			Destroy (other.gameObject); 
//	}
//}
