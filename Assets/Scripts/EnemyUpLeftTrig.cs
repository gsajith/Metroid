using UnityEngine;
using System.Collections;

public class EnemyUpLeftTrig : MonoBehaviour 
{
 void OnTriggerEnter2D(Collider2D thing)
 {
  if(thing.tag == "Wall") 
  {
   transform.parent.gameObject.GetComponent<EnemyMove>().upLeftTouch = true;
  } 
 }
	
 void OnTriggerExit2D(Collider2D thing)
 {
  if(thing.tag == "Wall") 
  {
   transform.parent.gameObject.GetComponent<EnemyMove>().upLeftTouch = false;
  } 
 }
}
