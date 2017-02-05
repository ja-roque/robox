using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoxBlock : MonoBehaviour {

	static Animator anim;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space))      	{
        		anim = GameObject.Find("playerBox").GetComponent<Animator>();
        	 	hide();

        	 	if (Input.GetKey(KeyCode.Space)){
        	 		anim.SetBool("isHolding", true);
        	 	} else {
        	 		anim.SetBool("isHolding",false);
        	 	}

        	}

        	if(Input.anyKey == false)
			{
        		anim.SetBool("isHolding",false);
			}
		
	}

	void hide(){
		anim.Play("hitBoxHide",-1,0f);

	}
}
