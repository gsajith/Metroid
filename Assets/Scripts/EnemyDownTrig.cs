using UnityEngine;
using System.Collections;

public class EnemyDownTrig : MonoBehaviour 
{
 void OnTriggerEnter2D(Collider2D thing)
 {
  if(thing.tag == "Wall") 
  {
   transform.parent.gameObject.GetComponent<EnemyMove>().downTouch = true;
  } 
 }
	
 void OnTriggerExit2D(Collider2D thing)
 {
  if(thing.tag == "Wall") 
  {
   transform.parent.gameObject.GetComponent<EnemyMove>().downTouch = false;
  } 
 }
}
