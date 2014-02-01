using UnityEngine;
using System.Collections;

public class EnemyDownLeftTrig : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D thing)
	{
		if (thing.tag == "Wall") 
		{
			transform.parent.gameObject.GetComponent<EnemyMove>().downLeftTouch = true;
			
		} 
	}
	
	void OnTriggerExit2D(Collider2D thing)
	{
		if (thing.tag == "Wall") 
		{
			transform.parent.gameObject.GetComponent<EnemyMove>().downLeftTouch = false;
			
		} 
	
	}


}
