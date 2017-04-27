using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_FX : StateMachineBehaviour {
	private GameObject player;
	private statManager script;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		player= GameObject.Find ("Footman_prefab");
		script = player.GetComponent<statManager>();
		script.playAttackSound ();
	}

	 //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//	script = player.GetComponent<statManager>();
	//	script.playAttackSound ();
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//	script = player.GetComponent<statManager>();
	//	script.playAttackSound ();
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//	script = player.GetComponent<statManager>();
	//	script.playAttackSound ();
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
