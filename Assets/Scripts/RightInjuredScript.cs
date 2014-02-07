using UnityEngine;
using System.Collections;

public class RightInjuredScript : MonoBehaviour 
{
 void Update()
 {
  if(transform.parent.gameObject.GetComponent<Samus>().isBall == true) 
  {
   BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
   boxCollider.size = new Vector2(0.35f, 1.0f);
   boxCollider.center = new Vector2(-0.6f,-1.2f);
  } 
  else 
  {
   BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
   boxCollider.size = new Vector2(0.5688653f, 2.058692f);
   boxCollider.center = new Vector2(-0.7009125f,-0.6555939f);
  }

  if(transform.parent.gameObject.GetComponent<SamusStats>().health == 0) 
  {
   Destroy (transform.parent.gameObject);
  }
 }

 void OnTriggerEnter2D(Collider2D thing)
 {
  if(thing.tag == "Zoomer1") 
  {
   transform.parent.gameObject.GetComponent<SamusStats>().health -= 8;
  } 

  if(transform.parent.gameObject.GetComponent<SamusStats> ().health <= 0) 
  {
   transform.parent.gameObject.GetComponent<SamusStats> ().health = 0;
  }
 }
}
