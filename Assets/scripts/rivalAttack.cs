using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rivalAttack : MonoBehaviour {

public GameObject rivalRightFist;
public GameObject rivalLeftFist;

public string Side;

public float preHealth = 200f;
public float speed = 15f;
public float step;

public Vector3 rivalRFInitialPos = new Vector3(-3, -3, 0);
public Vector3 rivalRFTarget = new Vector3(0, -1, 0);

public Vector3 rivalLFInitialPos = new Vector3(3, -3, 0);
public Vector3 rivalLFTarget = new Vector3(0, -1, 0);


public bool damageDone = false;
public bool startPlay = false;


//Instantiate Heanlth class to access the myHealth bar object and scale it.
public Health playerHealth = new Health();
public rivalAnimations animate = new rivalAnimations(); 

	// Use this for initialization

		public void rightPunch	() {

				if (rivalAnimations.flickerDone){
					step = speed * Time.deltaTime;
					resize("right",false,true);
				    rivalRightFist.transform.position = Vector3.MoveTowards(rivalRightFist.transform.position, rivalRFTarget, step);
								
				
				
				 	if (rivalRightFist.transform.position == rivalRFTarget){
						rivalRightFist.transform.localPosition = rivalRFInitialPos;
					}
				}
		}

		public void leftPunch	() {

				if (rivalAnimations.flickerDone){
					step = speed * Time.deltaTime;
					resize("left",false,true);
					   rivalLeftFist.transform.position = Vector3.MoveTowards(rivalLeftFist.transform.position, rivalLFTarget, step);
						
				
					if (rivalLeftFist.transform.position == rivalLFTarget){
						rivalLeftFist.transform.localPosition = rivalLFInitialPos;
					}
				}
		}

	    // resizing method is called when fist action is done to simulate a Z-axis movement.
		public void resize(string side, bool normal = false, bool isStraightPunch = false){


		
			//Var and condition determine how fast to resize in case is a straight punch (Little resize bugfix.)
			var resizeAmount = 0.015f;
			if(isStraightPunch){
				resizeAmount = 0.09f;
			}

			Side = side;


			if (Side == "right"){
				

				//This condition scales the fist when in action and doesnt let it get smaller than half its size.
				if (rivalRightFist.transform.localScale.x <= 2f){
				rivalRightFist.transform.localScale = new Vector3(rivalRightFist.transform.localScale.x + resizeAmount, rivalRightFist.transform.localScale.y + resizeAmount, 0);
				} 

				if(normal){
					//Back to normal size.
					rivalRightFist.transform.localScale = new Vector3(1f,1f,0);
				}
			}

			if (Side == "left"){
				

				//This condition scales the fist when in action and doesnt let it get smaller than half its size.
				if (rivalLeftFist.transform.localScale.x <= 2f){
				rivalLeftFist.transform.localScale = new Vector3(rivalLeftFist.transform.localScale.x + resizeAmount, rivalLeftFist.transform.localScale.y + resizeAmount, 0);
				} 

				if(normal){
					//Back to normal size.
					rivalLeftFist.transform.localScale = new Vector3(1f,1f,0);
				}
			}


			if (preHealth != Health.myHealth){
				var toReduce = Health.myHealth/Health.maxHealth; //This is how myhealth bar scaling is calculated.
				preHealth = Health.myHealth;
				playerHealth.myHealthBar.transform.localScale = new Vector3((14)*(toReduce),0.5f,0);

			}
		}


		public void checkDamage(){

			//Damage done condition created for controlling how much health to reduce since 
			//Damage application is done en a certain size is reached.
			if (damageDone == false){
				if (rivalRightFist.transform.localScale.x >= 2f){
					Health.myHealth = Health.myHealth - 10f;
					damageDone = true;
				}

				if (rivalLeftFist.transform.localScale.x >= 2f){
					Health.myHealth = Health.myHealth - 10f;
					damageDone = true;
				}
				
			}	
		}




}
