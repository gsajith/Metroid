using UnityEngine;
using System.Collections;

public class LeftInjuredScript : MonoBehaviour {


	void Update()
	{
		if (transform.parent.gameObject.GetComponent<Samus> ().isBall == true) {

						BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;

			boxCollider.size = new Vector2(0.35f, 1.0f);
			boxCollider.center = new Vector2(0f,-.5f);
						

				} else {
			
			BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
			if(transform.parent.gameObject.GetComponent<Samus>().grounded == true) {
				boxCollider.size = new Vector2(0.5f, 1.94f);
				boxCollider.center = new Vector2(0f,0f);
			} else {
				boxCollider.size = new Vector2(0.5f*.6f, 1.94f*.6f);
				boxCollider.center = new Vector2(0f, -.4f);
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
