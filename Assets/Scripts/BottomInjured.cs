using UnityEngine;
using System.Collections;

public class BottomInjured : MonoBehaviour 
{
 void Update()
 {
  if(transform.parent.gameObject.GetComponent<Samus>().isBall == true) 
  {
   BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
   boxCollider.enabled = false;
  } 
  else 
  {
   BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
   boxCollider.enabled = true;
  }
 }
	
 void OnTriggerEnter2D(Collider2D thing)
 {
  if(thing.tag == "Zoomer1") 
  {
   transform.parent.gameObject.GetComponent<SamusStats>().health -= 8;
  } 
 }
}
