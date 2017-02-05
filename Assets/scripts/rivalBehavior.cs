using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rivalBehavior : MonoBehaviour {

//Instance of the curve class created for curve motion of the rival's idle stance

private rivalAttack attack = new rivalAttack();

public string side = "left";

public bool doIdle = true; //Boolean to determine when to play de idle movement of character
public bool isWaiting = true; //Boolean to determine when to play de idle movement of character

public float orientation;

public GameObject rival;

public bool sixKeyHit = false;
public bool sevenKeyHit = false;




	// Use this for initialization
	void Start () {

		rival = GameObject.Find("rival");
		attack.rivalRightFist = GameObject.Find("rivalRightFist");

		attack.rivalLeftFist = GameObject.Find("rivalLeftFist");

		attack.playerHealth.myHealthBar = GameObject.Find("myhealthBarBox"); 
		
		//Randomly determine where will rival start moving.
		
		orientation = Mathf.Round(Random.value);



	}
	
	// Update is called once per frame
	void Update () {
		////////////////////////////////////////////////////////////////////////////////////////////////////
		///////////////////////////////Actions to perform when punch lands./////////////////////////////////
		////////////////////////////////////////////////////////////////////////////////////////////////////
	
        attack.checkDamage();		



	}

	

	public void doAction(){
		punch();
	}

	public void punch(){

				if (sixKeyHit){
			 
				doIdle = false;
				attack.rightPunch();
									
				} 

				if (sevenKeyHit){
				attack.leftPunch();
				doIdle = false;
				} 
				
			
			
		}	



}
