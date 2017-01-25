using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {


public float preHealth;
public string side;
private Fist fist = new Fist(); 
private	 colInstruction onCollision = new colInstruction();

	public void Start () {
		side = "none";
		preHealth = 200f;

		onCollision.health.healthBar = GameObject.Find("healthBar");
		onCollision.health.healthBar.SetActive(true);

		fist.rightFist = GameObject.Find("fist");
		fist.rightFist.SetActive(true);


		fist.leftFist = GameObject.Find("fist2");
		fist.leftFist.SetActive(true);

		
	}
	
	// Update is called once per frame
	public void Update () {
			/////////////////////////////////////////////////////////////
			//Conditions check when to stop the punching action movement/
			/////////////////////////////////////////////////////////////
			if (fist.rightFist.transform.position == fist.rfInitialPos && (fist.keyhit || fist.upKeyHit || fist.zeroKeyHit)){
				
				fist.resize("right",true);

				fist.keyhit = false;
				fist.upKeyHit = false;
				fist.zeroKeyHit = false;

				fist.Curve.resetValues();
				fist.Hook.resetValues();
				fist.rightIsActive = false;
			}

			if (fist.leftFist.transform.position == fist.lfInitialPos && (fist.Leftkeyhit || fist.downKeyHit || fist.oneKeyHit)){
				fist.resize("left",true);

				fist.Leftkeyhit = false;
				fist.downKeyHit = false;
				fist.oneKeyHit = false;

				fist.Curve.resetValues();
				fist.Hook.resetValues();
				fist.leftIsActive = false;
			}

			/////////////////////////////////////////////////////////////
			////////////////Controls action check conditions/////////////
			/////////////////////////////////////////////////////////////
		    if (Input.GetKey(KeyCode.RightArrow)	) 	{
        		        	 
        		if (!fist.rightIsActive) {
        	 	fist.keyhit = true;	
        	 	}
        	}

			if (Input.GetKey(KeyCode.LeftArrow))      	{
				print(Health.health);	
        		if(!fist.leftIsActive){
        	 	fist.Leftkeyhit = true;
        		}	
        	}

        	if (Input.GetKey(KeyCode.UpArrow))      	{
        		print(fist.upKeyHit);	
        		if(!fist.leftIsActive){
        	 	fist.upKeyHit = true;
        		}	
        	}

        	if (Input.GetKey(KeyCode.DownArrow))      	{
        	
        		if(!fist.leftIsActive){

        	 	fist.downKeyHit = true;
        		}	
        	}

        	if (Input.GetKey(KeyCode.Keypad0))      	{
        	
        		if(!fist.leftIsActive){

        	 	fist.zeroKeyHit = true;
        		}	
        	}

        	if (Input.GetKey(KeyCode.Keypad1))      	{
        	
        		if(!fist.leftIsActive){

        	 	fist.oneKeyHit = true;
        		}	
        	}


			/////////////////////////////////////////////////////////////
			///////////////////Function to execute continuosly///////////
			/////////////////////////////////////////////////////////////
			fist.punch();
			
			

			// Health Bar Shrinking condition.
			if (preHealth != Health.health){
				print("IM IN THE CONDITION");
				preHealth = Health.health;
				onCollision.health.healthBar.transform.localScale = new Vector3((onCollision.health.healthBar.transform.localScale.x)-(7*0.05f),0.5f,0);

			}
			

	}




}