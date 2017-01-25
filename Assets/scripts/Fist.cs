using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    	public class Fist  {

   		public GameObject rightFist;
   		public GameObject leftFist;

    	public Vector3 rfInitialPos = new Vector3(6, -5, 0);
    	public Vector3 rfTarget = new Vector3(1.76f, 0.73f, 0);
		public Vector3 lfInitialPos = new Vector3(-6, -5, 0);
		public Vector3 lfTarget = new Vector3(-1.76f, 0.73f, 0);

	

		//keyhit detections, will be changed later on to other touchscreen triggers.
    	public bool keyhit		= false;
    	public bool zeroKeyHit 	= false;
    	public bool upKeyHit		= false;
    	public bool rightIsActive 	= false;

  		public bool Leftkeyhit 	= false;
  		public bool oneKeyHit 	= false;
  		public bool downKeyHit		= false;
  		public bool leftIsActive 	= false;

  		public bool stopResize 	= false;
  		

    	public float speed = 20f;
		public float step;
    		
		public string Side = "none";

		/////////////////////////////////////////////
		/*Here is where you instantiate Punch types*/
		/////////////////////////////////////////////
		public Curve Curve = new Curve(); 
		public Hook Hook = new Hook(); 
		/////////////////////////////////////////////
		/////////////////////////////////////////////

		public void punch(){
			 step = speed * Time.deltaTime;
			 

				if (keyhit){
				rightPunch();
				} 
				
				if (Leftkeyhit){
				leftPunch();
				}

				if (upKeyHit){
				CurvePunch("right");
				}

				if (downKeyHit){
				
				CurvePunch("left");
				}

				if (zeroKeyHit){
				hookPunch("right");
				}

				if (oneKeyHit){
				
				hookPunch("left");
				}
			
			
		}

		public void rightPunch	() {
				rightIsActive = true;	
			    rightFist.transform.position = Vector3.MoveTowards(rightFist.transform.position, rfTarget, step);
			 	resize("right",false,true);

			 	if (rightFist.transform.position == rfTarget){
	
				rightFist.transform.position = rfInitialPos;
				}

		}

		public void leftPunch () {
				leftIsActive = true;
			    leftFist.transform.position = Vector3.MoveTowards(leftFist.transform.position, lfTarget, step);
			    resize("left",false,true);	

			 	if (leftFist.transform.position == lfTarget){

				leftFist.transform.position = lfInitialPos;
				}
		
		}

		public void CurvePunch(string side)
 		{

	 		Curve.Side = side;
	 		resize(Curve.Side,false);	
		     Curve.BezierTime = Curve.BezierTime + Time.deltaTime * 1.7f;
		 
		     if (Curve.BezierTime >= 20f)
		     {
		         Curve.BezierTime = 0;
		     }
		 	
		 	switch(Curve.Side){
		 		case "right":
		 		Curve.sideSel = 1;
		 		break;

		 		case "left":
		 		Curve.sideSel = -1;
		 		break;

		 	}

		     Curve.CurveX = ((((1-Curve.BezierTime)*(1-Curve.BezierTime)) * Curve.StartPointX) + (2 * Curve.BezierTime * (1 - Curve.BezierTime) * Curve.ControlPointX) + ((Curve.BezierTime * Curve.BezierTime) * Curve.EndPointX)) * Curve.sideSel;
		     Curve.CurveY = (((1-Curve.BezierTime)*(1-Curve.BezierTime)) * Curve.StartPointY) + (2 * Curve.BezierTime * (1 - Curve.BezierTime) * Curve.ControlPointY) + ((Curve.BezierTime * Curve.BezierTime) * Curve.EndPointY);
		     
		     if (Curve.Side == "right"){
		     rightFist.transform.position = new Vector3(Curve.CurveX, Curve.CurveY, 0);
	 		 if ( -1 >= Curve.CurveX){
	 		 	rightFist.transform.position = rfInitialPos;

	 		 }
	 		}

	 		 if (Curve.Side == "left"){
		     leftFist.transform.position = new Vector3(Curve.CurveX, Curve.CurveY, 0);
	 		 if ( 1 <= Curve.CurveX){
	 		 	leftFist.transform.position = lfInitialPos;

	 		 }
	 		}
		}

		public void hookPunch(string side)
 		{
	 		 Hook.Side = side;
	 		 resize(Hook.Side,false);	
		     Hook.BezierTime = Hook.BezierTime + Time.deltaTime * 1.7f;
		 
		     if (Hook.BezierTime >= 20f)
		     {
		         Hook.BezierTime = 0;
		     }
		 	
		 	switch(Hook.Side){
		 		case "right":
		 		Hook.sideSel = 1;
		 		break;

		 		case "left":
		 		Hook.sideSel = -1;
		 		break;

		 	}

		     Hook.CurveX = ((((1-Hook.BezierTime)*(1-Hook.BezierTime)) * Hook.StartPointX) + (2 * Hook.BezierTime * (1 - Hook.BezierTime) * Hook.ControlPointX) + ((Hook.BezierTime * Hook.BezierTime) * Hook.EndPointX)) * Hook.sideSel;
		     Hook.CurveY = (((1-Hook.BezierTime)*(1-Hook.BezierTime)) * Hook.StartPointY) + (2 * Hook.BezierTime * (1 - Hook.BezierTime) * Hook.ControlPointY) + ((Hook.BezierTime * Hook.BezierTime) * Hook.EndPointY);
		     
		     if (Hook.Side == "right"){
		     rightFist.transform.position = new Vector3(Hook.CurveX, Hook.CurveY, 0);
	 		 if ( 2 <= Hook.CurveY){
	 		 	rightFist.transform.position = rfInitialPos;

	 		 }
	 		}

	 		 if (Hook.Side == "left"){
		     leftFist.transform.position = new Vector3(Hook.CurveX, Hook.CurveY, 0);
	 		 if ( 2 <= Hook.CurveY){
	 		 	leftFist.transform.position = lfInitialPos;

	 		 }
	 		}
		}


		// resizing method is called when fist action is done to simulate a Z-axis movement.
		public void resize(string side, bool normal = false, bool isStraightPunch = false){

			//Var and condition determine how fast to resize in case is a straight punch (Little resize bugfix.)
			var resizeAmount = 0.015f;
			if(isStraightPunch){
				resizeAmount = 0.025f;
			}

			Side = side;


			if (Side == "right"){
				

				//This condition scales the fist when in action and doesnt let it get smaller than half its size.
				if (rightFist.transform.localScale.x >= 0.5f){
				rightFist.transform.localScale = new Vector3(rightFist.transform.localScale.x - resizeAmount, rightFist.transform.localScale.y - resizeAmount, 0);
				} 

				if(normal){
					//Back to normal size.
					rightFist.transform.localScale = new Vector3(1f,1f,0);
				}
			}

			if (Side == "left"){
				

				//This condition scales the fist when in action and doesnt let it get smaller than half its size.
				if (leftFist.transform.localScale.x >= 0.5f){
				leftFist.transform.localScale = new Vector3(leftFist.transform.localScale.x - resizeAmount, leftFist.transform.localScale.y - resizeAmount, 0);
				} 

				if(normal){
					//Back to normal size.
					leftFist.transform.localScale = new Vector3(1f,1f,0);
				}
			}
		}



	}	