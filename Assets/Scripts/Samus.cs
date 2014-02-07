using UnityEngine;
using System.Collections;

public class Samus : MonoBehaviour 
{
 public float speed = 8;
 public float jumpSpeed = 12;
 public float jumpAcc = 4;
	
 public bool grounded = true;
 public bool canBall = false;
 public bool isBall = false;
 public bool canShoot = true;
 public bool shootUp = false;

 public RuntimeAnimatorController samusRun;
 public RuntimeAnimatorController samusRoll;
 public RuntimeAnimatorController samusIdle;
 public RuntimeAnimatorController samusIdleUp;
 public RuntimeAnimatorController samusJumpNormal;
 public RuntimeAnimatorController samusJumpRoll;
 public RuntimeAnimatorController samusRunUp;

 public bool twirling = false;

 public GameObject camera;



 void Update () 
 {
  Vector2 vel = rigidbody2D.velocity;
  Quaternion rot = transform.rotation;



  if(!isBall) // Not Ball - Standing
  {
   if(grounded && !Input.GetKey(KeyCode.UpArrow) // Grounded - idle
			   && !Input.GetKey(KeyCode.LeftArrow)
			   && !Input.GetKey(KeyCode.RightArrow)) 
   {
	//Idle and non-moving shooting animation
	switchAnimation(samusIdle);
   } 
   else if(grounded && Input.GetKey(KeyCode.UpArrow) // Grounded - aiming up
			        && !Input.GetKey(KeyCode.RightArrow)
			        && !Input.GetKey(KeyCode.LeftArrow)) 
   {
	//Non-moving up animation
    switchAnimation(samusIdleUp);
   } 
   else if(grounded && !Input.GetKey(KeyCode.UpArrow) // Grounded - moving left & right - aiming straight
			        && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))) 
   {
	//Running left and right animation
	switchAnimation(samusRun);
   }
   else if(grounded && Input.GetKey(KeyCode.UpArrow) // Grounded - moving left & right - aiming up
			        && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))) 
   {
	switchAnimation(samusRunUp);
   }

   if(!grounded) // If in the air
   {		
				canShoot = true;
	if(twirling == false) // Regular jump & falling
	{
	 switchAnimation(samusJumpNormal);
	 twirling = false;
	}
    
	if(twirling == true && Input.GetKey(KeyCode.Z)) // Shooting straight in air 
	{
	 switchAnimation(samusJumpNormal); 
	 twirling = false;
	}			
   }
  }





		if(Input.GetKeyDown (KeyCode.RightArrow)) {
			vel.x = speed;
			rot.y = 0;
		}
		if(Input.GetKeyUp (KeyCode.RightArrow) && vel.x >= 0) {
			vel.x = 0;
		}

		if(Input.GetKeyDown (KeyCode.UpArrow)) {
			shootUp = true;
		}
		if(Input.GetKeyUp(KeyCode.UpArrow)) {
			shootUp = false;
		}

		if(!grounded && Input.GetKey (KeyCode.RightArrow) && Input.GetKey (KeyCode.LeftArrow)) {
			vel.x = 0;
		} else if(!grounded && Input.GetKey (KeyCode.RightArrow)) {
			vel.x = speed;
			rot.y = 0;
		} else if(!grounded && Input.GetKey (KeyCode.LeftArrow)) {
			vel.x = -speed;
			rot.y = -180;
		}


		if(Input.GetKeyDown (KeyCode.LeftArrow)) {
			vel.x = -speed;
			rot.y = -180;
		}
		if(Input.GetKeyUp (KeyCode.LeftArrow) && vel.x <= 0) {
			vel.x = 0;
		}

		if (Input.GetKeyDown(KeyCode.X)) {
			if (grounded && !isBall) {
				vel.y = jumpSpeed;
				grounded = false;
				if(Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) 
				{
					switchAnimation (samusJumpRoll);
					twirling = true;


				
				} else {
					switchAnimation (samusJumpNormal);
					twirling = false;
				}
			} else if(isBall && !Input.GetKey (KeyCode.DownArrow)) {
				BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
				Vector2 size = boxCollider.size;
				size.y = size.y / .49f;
				boxCollider.size = size;
				Vector2 center = boxCollider.center;
				center.y = center.y / .49f;
				boxCollider.center = center;
				isBall = false;
				canShoot = true;
			}
		}

		if (Input.GetKeyUp(KeyCode.X)) {
			if(vel.y > 0) vel.y = 0;
		} 

		bool shoot = Input.GetKey (KeyCode.Z) && canShoot;

		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				weapon.Attack(false);
			}
		}

		bool ball = Input.GetKey (KeyCode.DownArrow) && grounded;
		if(canBall && ball && !isBall) {
			BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
			Vector2 size = boxCollider.size;
			size.y = size.y * .49f;
			boxCollider.size = size;
			Vector2 center = boxCollider.center;
			center.y = center.y * .49f;
			boxCollider.center = center;
			gameObject.transform.Translate (0, .6f, 0);
			isBall = true;
			canShoot = false;
			switchAnimation (samusRoll);
		}

		
		rigidbody2D.velocity = vel;
		transform.rotation = rot;
		Vector3 thisPos = this.transform.position;
		thisPos.z = -10;
		thisPos.y += 4;
		camera.transform.position = thisPos;

	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.GetComponent<GroundScript> () != null)
			if(grounded == false) {
				grounded = true;
				if(!isBall) {
				BoxCollider2D coll = this.gameObject.GetComponent<BoxCollider2D> ();
				Vector2 collScale = coll.size;
				collScale.y = 1.9375f;
				coll.size = collScale;
				Vector2 collPos = coll.center;
				collPos.y = .96875f;
				coll.center = collPos;
			}
		}
	}
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.GetComponent<GroundScript> () != null) {
				grounded = false;
			if(!isBall) {
				BoxCollider2D coll = this.gameObject.GetComponent<BoxCollider2D> ();
				Vector2 collScale = coll.size;
				collScale.y = 1.9375f * .6f;
				coll.size = collScale;
				Vector2 collPos = coll.center;
				collPos.y = .56875f;
				coll.center = collPos;
			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.GetComponent<GroundScript> () != null)
			if(grounded != true) {
				grounded = true;	
			if(!isBall) {
				BoxCollider2D coll = this.gameObject.GetComponent<BoxCollider2D> ();
				Vector2 collScale = coll.size;
				collScale.y = 1.9375f;
				coll.size = collScale;
				Vector2 collPos = coll.center;
				collPos.y = .96875f;
				coll.center = collPos;
			}
		}
	}

	void switchAnimation(RuntimeAnimatorController anim) {
		Animator animator = gameObject.GetComponent<Animator> ();
		animator.runtimeAnimatorController = anim;
	}
}
