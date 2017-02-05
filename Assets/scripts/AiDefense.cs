using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDefense : MonoBehaviour {

	public float randNum;
	public bool willDodge;

	public Animator anim;
	// Use this for initialization
	void Start () {
		
		anim = GameObject.Find("rival").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		

		// //Randomly determine if rival will dodge player's attack moving.
		randNum = Mathf.Round(Random.value);


		if(Input.GetKeyDown(KeyCode.RightArrow)){

		
		 	if (randNum == 1){
		 		willDodge = true;
		 	}

			if(willDodge){
				doDodge("left");
			}
		}
		willDodge = false;	


	}

	void doDodge(string side){
		anim.Play("Dodge",-1,0); //Last argument set to know in which point of the animation to start (helpful for difficulty purposes.)
	}
}
