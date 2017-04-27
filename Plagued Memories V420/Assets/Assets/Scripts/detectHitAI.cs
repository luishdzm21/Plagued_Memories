using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class detectHitAI : MonoBehaviour
{
    public Transform player;


    [Header("Unity Stuff")]
    public Image healthbar;
    public Image background;
    public float enemyHP = 100;
    public float amount = 45;


    public Slider curHP;
    Animator animAI;
	public Collider sword;
	public AudioClip shootSound;
	public AudioClip shootSound1;

	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;



    //Vector3 direction = player.position - this.transform.position;
    //float angle = Vector3.Angle(direction, this.transform.forward);
    //    if(Vector3.Distance(player.position, this.transform.position) < 75 && angle< 60)
    //    {
    //        //Vector3 direction = player.position - this.transform.position;
    //        direction.y = 0;
    //        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);


    //        anim.SetBool("isIdle", false);
    //        if (direction.magnitude > 15)
    //        {
    //            this.transform.Translate(0, 0, speed);
    //            anim.SetBool("isWalking", true);
    //            anim.SetBool("isAttacking", false);
				//sword.enabled = false;
				//sword.isTrigger = false;
    //        }
void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sword")
        {
			float vol = Random.Range (volLowRange, volHighRange);
			source.PlayOneShot(shootSound,vol);
			source.PlayOneShot(shootSound1,vol);
                
            enemyHP -= amount;
            healthbar.fillAmount = enemyHP / 100f;
            if(enemyHP <= 0)
            {
                animAI.SetBool("isDead", true);
                healthbar.enabled = false;
                background.enabled = false;
                
            }
        }
    }
    // Use this for initialization
    void Start()
    {
        animAI = GetComponent<Animator>();
		source = GetComponent<AudioSource>();
        //this.enemyHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.enemyHP > 0)
        {


            Vector3 direction = player.position - this.transform.position;
            if (Vector3.Distance(player.position, this.transform.position) < 75)
            {
                healthbar.enabled = true;
                background.enabled = true;
            }
            else
            {
                healthbar.enabled = false;
                background.enabled = false;
            }

            if (animAI.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            {
                sword.enabled = false;
                sword.isTrigger = false;
            }
        }
    }
}
