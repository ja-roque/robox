using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* CLASS IS MAINLY USED TO STORE CURVE RIVAL MOVEMENT NECESSARY VALUES.	*/

public class idleCurve {


	public float StartPointX = -1f;
	public float StartPointY = 1f;
	public float ControlPointX = 0f;
	public float ControlPointY = 1.7f;
	public float EndPointX = 1f;
	public float EndPointY = 1f;
	public float CurveX = 0;
	public float CurveY = 0;
	public float BezierTime = 0;

	public string Side;
	public float sideSel;
	public GameObject theFist;
	public Vector3 theInitialPos = new Vector3();

	public void resetValues(){
		CurveX = 0;
		CurveY = 0;
		BezierTime = 0;
	}

}
