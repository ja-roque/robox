using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fistAnimations : MonoBehaviour {
	static Animator anim;
	static Animator anim2;
	// Use this for initialization
	void Start () {
		anim = GameObject.Find("fist").GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
		 if (Input.GetKeyDown(KeyCode.RightArrow)	) 	{
        		        	 
        		anim = GameObject.Find("fist").GetComponent<Animator>();
        	 	punch();
        	 	}
        	

			if (Input.GetKeyDown(KeyCode.LeftArrow))      	{
        		anim = GameObject.Find("fist2").GetComponent<Animator>();
        	 	punch();
        	}

        	if (Input.GetKeyDown(KeyCode.UpArrow))      	{
        		anim = GameObject.Find("fist2").GetComponent<Animator>();
        	 	curvePunch();	
        	}

        	if (Input.GetKeyDown(KeyCode.DownArrow))      	{
        	
        		anim = GameObject.Find("fist").GetComponent<Animator>();
        	 	curvePunch();
        	}

        	if (Input.GetKeyDown(KeyCode.Space))      	{
        		anim = GameObject.Find("fist").GetComponent<Animator>();
        		anim2 = GameObject.Find("fist2").GetComponent<Animator>();
        	 	shield();

        	 	if (Input.GetKey(KeyCode.Space)){
        	 		anim.SetBool("isHolding", true);
        	 		anim2.SetBool("isHolding", true);
        	 	} else {
        	 		anim.SetBool("isHolding",false);
        	 		anim2.SetBool("isHolding",false);
        	 	}

        	}

        	if(Input.anyKey == false)
			{
				anim = GameObject.Find("fist").GetComponent<Animator>();
        		anim2 = GameObject.Find("fist2").GetComponent<Animator>();
        		anim.SetBool("isHolding",false);
        		anim2.SetBool("isHolding",false);
			}

        	if (Input.GetKeyDown(KeyCode.Keypad1))      	{

        	}


	}

	public static void punch (){
		anim.Play("punchFist",-1,0f); //Last argument set to know in which point of the animation to start (helpful for difficulty purposes.) 
	}

	public static void curvePunch (){
		anim.Play("punchCurve",-1,0f); //Last argument set to know in which point of the animation to start (helpful for difficulty purposes.) 
	}

	public static void shield (){
		anim.Play("shield",-1,0f); //Last argument set to know in which point of the animation to start (helpful for difficulty purposes.) 
		anim2.Play("shieldLeft",-1,0f); //Last argument set to know in which point of the animation to start (helpful for difficulty purposes.) 
	}
}
