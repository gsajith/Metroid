using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour 
{
 public Vector2 up;
 public Vector2 down;
 public Vector2 right;
 public Vector2 left;
 public Vector2 stop;

 public bool upTouch = false;
 public bool downTouch = false;
 public bool leftTouch = false;
 public bool rightTouch = false;
 public bool upLeftTouch = false;
 public bool upRightTouch = false;
 public bool downLeftTouch = false;
 public bool downRightTouch = false;

 void Update() 
 {
  if(rightTouch == false && upRightTouch == false && downRightTouch == true) 
  {
   rigidbody2D.velocity = right;	
  } 
  else if(downRightTouch == false && downTouch == false && downLeftTouch == true) 
  {
   rigidbody2D.velocity = down;
  } 
  else if(downLeftTouch == false && leftTouch == false && upLeftTouch == true) 
  {
   rigidbody2D.velocity = left;
  }
  else if(upLeftTouch == false && upTouch == false && upRightTouch == true) 
  {
   rigidbody2D.velocity = up;
  }
 }
}
