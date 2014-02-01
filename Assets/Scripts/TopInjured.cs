using UnityEngine;
using System.Collections;

public class TopInjured : MonoBehaviour {

	void Update()
	{
		if (transform.parent.gameObject.GetComponent<Samus> ().isBall == true) {
			
			BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
			
			boxCollider.enabled = false;
			
			
		} else {
			
			BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
			
			boxCollider.enabled = true;
			if(transform.parent.gameObject.GetComponent<Samus>().grounded == true) {
				boxCollider.center = new Vector2(0f,0f);
			} else {
				boxCollider.center = new Vector2(0f, -.6f);
			}
			
		}
		
	}
	
	
	
	
	
	void OnTriggerEnter2D(Collider2D thing)
	{
		if (thing.tag == "Zoomer1") 
		{
			transform.parent.gameObject.GetComponent<SamusStats>().health --;
			
		} 
	}
}
