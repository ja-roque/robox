using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* CLASS IS MAINLY USED TO STORE HOOK PUNCH NECESSARY VALUES.	*/

public class Hook {


	public float StartPointX = 5f;
	public float StartPointY = -3f;
	public float ControlPointX = 2f;
	public float ControlPointY = -20f;
	public float EndPointX = .8f;
	public float EndPointY = 1;
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
