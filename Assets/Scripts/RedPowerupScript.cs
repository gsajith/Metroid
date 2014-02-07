using UnityEngine;
using System.Collections;

public class RedPowerupScript : MonoBehaviour 
{
 void OnTriggerEnter2D(Collider2D other) 
 {
  Samus player = other.gameObject.GetComponent<Samus>();

  if(player != null) 
  {
   player.canBall = true;
   Destroy (this.gameObject);
  }
 }
}
