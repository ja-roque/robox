using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class col2 : MonoBehaviour {

	private Health rivalHealth = new Health();
	public Health health = new Health();
	public bool Collided = false;

	void OnTriggerEnter (Collider other)
	    {
	    	if(Collided == false) {
	    	Collided = true;	
	    	Health.health = Health.health - 10f;
	    	print(	Health.health);
	        
	    }
	        
	    }

	void OnTriggerStay (Collider other)
	    {
	        Collided = true;

	    }

	void OnTriggerExit (Collider other)
	    {
	        Collided = false;

	    }

}