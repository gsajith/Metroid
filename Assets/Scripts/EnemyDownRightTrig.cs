using UnityEngine;
using System.Collections;

public class EnemyDownRightTrig : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D thing)
	{
		if (thing.tag == "Wall") 
		{
			transform.parent.gameObject.GetComponent<EnemyMove>().downRightTouch = true;
			
		} 
	}
	
	void OnTriggerExit2D(Collider2D thing)
	{
		if (thing.tag == "Wall") 
		{
			transform.parent.gameObject.GetComponent<EnemyMove>().downRightTouch = false;
			
		} 
	}

}
