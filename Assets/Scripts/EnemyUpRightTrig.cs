﻿using UnityEngine;
using System.Collections;

public class EnemyUpRightTrig : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D thing)
	{
		if (thing.tag == "Wall") 
		{
			transform.parent.gameObject.GetComponent<EnemyMove>().upRightTouch = true;
			
		} 
	}
	
	void OnTriggerExit2D(Collider2D thing)
	{
		if (thing.tag == "Wall") 
		{
			transform.parent.gameObject.GetComponent<EnemyMove>().upRightTouch = false;
			
		} 
	}


}
