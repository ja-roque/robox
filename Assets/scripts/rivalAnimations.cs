using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rivalAnimations : MonoBehaviour {

	public static bool flickerDone = true;

	static Animator anim;

	// Use this for initialization
	void Start () {
		//set anim initially just to avoid error when game starts.
		anim = GameObject.Find("rivalLeftFist").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		//Start the flicker when the rival left punch is triggered.
		if(Input.GetKeyDown(KeyCode.Keypad7)){
			anim = GameObject.Find("rivalLeftFist").GetComponent<Animator>();
			flicker();
		}



		if(Input.GetKeyDown(KeyCode.Keypad6)){
			anim = GameObject.Find("rivalRightFist").GetComponent<Animator>();
			flicker();
		}


		//With this codeblock Game verifies if animation is still playing or not
		//This way, when its done, the rival punch may start.
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Flicker") == false){
			flickerDone = true;
		} else {
			flickerDone = false;
		}
	

	}

	public static void flicker (){
		anim.Play("Flicker",-1,0.5f); //Last argument set to know in which point of the animation to start (helpful for difficulty purposes.) 
	}


}
