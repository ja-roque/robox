using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rivalBehavior : MonoBehaviour {

//Instance of the curve class created for curve motion of the rival's idle stance
private idleCurve idleStance = new idleCurve();

public string side = "left";

public bool doIdle = true;
public float orientation;

public GameObject rival;




	// Use this for initialization
	void Start () {

		rival = GameObject.Find("rival");
		
		//Randomly determine where will rival start moving.
		
		orientation = Mathf.Round(Random.value);



	}
	
	// Update is called once per frame
	void Update () {
		
		if (orientation != 0) {
			side = "right";
		} else {
			side = "left";
		}

		
		if(doIdle){
			idleStance.BezierTime = idleStance.BezierTime + Time.deltaTime * 1.5f;

			if (idleStance.BezierTime >= 20f){
			    idleStance.BezierTime = 0;
			}
			
			idleStance.CurveX = xMovement(side);
			idleStance.CurveY = yMovement();
			rival.transform.position = new Vector3(idleStance.CurveX, idleStance.CurveY, 0);
		}


			



	}

	public float xMovement(string side){

		if (side == "right"){
			idleStance.sideSel = 1;	
		} else {
			idleStance.sideSel = -1;
		}

		if (rival.transform.position.y < 0.9f){

			var tmpEndX = idleStance.EndPointX;
			var tmpEndY = idleStance.EndPointY;

			var tmpStartX = idleStance.StartPointX;
			var tmpStartY = idleStance.StartPointY;

			idleStance.resetValues();

			idleStance.EndPointX = tmpStartX;
			idleStance.EndPointY = tmpStartY;

			idleStance.StartPointX = tmpEndX;
			idleStance.StartPointY = tmpEndY;

						
		}

		var result = ((((1-idleStance.BezierTime)*(1-idleStance.BezierTime)) * idleStance.StartPointX) + (2 * idleStance.BezierTime * (1 - idleStance.BezierTime) * idleStance.ControlPointX) + ((idleStance.BezierTime * idleStance.BezierTime) * idleStance.EndPointX)) * idleStance.sideSel;
		return result;
		}

	public float yMovement(){
		var result = (((1-idleStance.BezierTime)*(1-idleStance.BezierTime)) * idleStance.StartPointY) + (2 * idleStance.BezierTime * (1 - idleStance.BezierTime) * idleStance.ControlPointY) + ((idleStance.BezierTime * idleStance.BezierTime) * idleStance.EndPointY);
		return result;
	}

}
