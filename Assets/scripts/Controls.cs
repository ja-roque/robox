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
		
		
	}
	
	// Update is called once per frame
	public void Update () {
			
 
			//RIVAL Health Bar Shrinking condition.
			if (preHealth != Health.health){

				var toReduce = Health.health/Health.maxHealth; //This is how health bar scaling is calculated.
				preHealth = Health.health;
				onCollision.health.healthBar.transform.localScale = new Vector3((14)*(toReduce),0.5f,0);

			}
			

	}




}