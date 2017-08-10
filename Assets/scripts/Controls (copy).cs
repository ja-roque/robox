using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
public Vector3 rfInitialPos = new Vector3();
public Vector3 lfInitialPos = new Vector3();
public GameObject leftFist;
public GameObject rightFist;
public float speed = 10f;
public bool keyhit = false;
public bool Leftkeyhit = false;

 

	void Start () {
		
		rightFist = GameObject.Find("fist");
		rightFist.SetActive(true);
		rfInitialPos = rightFist.transform.position;

		leftFist = GameObject.Find("fist2");
		leftFist.SetActive(true);
		lfInitialPos = leftFist.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		    if (Input.GetKey(KeyCode.RightArrow) && !rightPunch.)
        	{
        	 print(Time.deltaTime);
        	 keyhit = true;
        	    
			}

			 if (Input.GetKey(KeyCode.LeftArrow))
        	{

        	 print(Time.deltaTime);	
        	 Leftkeyhit = true;

       
        	    
			}
			rightPunch();
			leftPunch();
		}

	public class fist {
		
	}	

	void rightPunch	() {
			if (keyhit){
			   rightFist.transform.Translate(new Vector2(-rightFist.transform.position.x * Time.deltaTime * speed, -rightFist.transform.position.y * Time.deltaTime * speed));
			 	
			 	if (rightFist.transform.position.x <= 1){
				print("xi xi xi i did it");
				keyhit = false;
				rightFist.transform.position = rfInitialPos;
				}
			}	
		}

	void leftPunch () {
				if (Leftkeyhit){
			   leftFist.transform.Translate(new Vector2(-leftFist.transform.position.x * Time.deltaTime * speed, -leftFist.transform.position.y * Time.deltaTime * speed));
			 	
			 	if (leftFist.transform.position.x >= -1){
			 	print("left keyhit is false");
				Leftkeyhit = false;
				leftFist.transform.position = lfInitialPos;
				}
			}	
	}

    }