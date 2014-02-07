using UnityEngine;
using System.Collections;

public class EnemyRightTrig : MonoBehaviour 
{
 void OnTriggerEnter2D(Collider2D thing)
 {
  if(thing.tag == "Wall") 
  {
   transform.parent.gameObject.GetComponent<EnemyMove>().rightTouch = true;
  } 
 }

 void OnTriggerExit2D(Collider2D thing)
 {
  if(thing.tag == "Wall") 
  {
   transform.parent.gameObject.GetComponent<EnemyMove>().rightTouch = false;
  } 
 }
}
