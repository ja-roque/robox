using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocking : MonoBehaviour {

	static Animator anim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space))      	{
        		anim = GameObject.Find("blockingBox").GetComponent<Animator>();
        	 	block();

        	 	if (Input.GetKey(KeyCode.Space)){
        	 		anim.SetBool("isHolding", true);
        	 	} else {
        	 		anim.SetBool("isHolding",false);
        	 	}

        	}

        	if(Input.anyKey == false)
			{
				anim = GameObject.Find("blockingBox").GetComponent<Animator>();
        		anim.SetBool("isHolding",false);
			}
		
	}

	void block(){
		anim.Play("blockingBox",-1,0f);

	}
}
