using UnityEngine;

public class WeaponScript : MonoBehaviour
{
 public Transform shotPrefab;
 public float shootingRate = 0.25f;
 private float shootCooldown;

 void Start()
 {
  shootCooldown = 0f;
 }
	
 void Update()
 {
  if(shootCooldown > 0)
  {
   shootCooldown -= Time.deltaTime;
  }
 }
	
 public void Attack(bool isEnemy)
 {
  if(CanAttack)
  {
   shootCooldown = shootingRate;
   Vector3 otherTrans = transform.position;
   Transform otherRot = transform;
   Samus samus = transform.gameObject.GetComponent<Samus>();
   
   if(samus!= null) 
   {
	if(samus.shootUp == false) 
	{
	 otherTrans.y += 1.2f;
	 if(transform.rotation.y > 0) 
	 {
	  otherTrans.x -= .6f;
	 } 
	 else 
	 {
	  otherTrans.x += .6f;
	 }
	} 
	else 
	{
	 otherTrans.y += 2.5f;
	 if(transform.rotation.y > 0) 
	 {
	  otherTrans.x -= .3f;
	 }
	 else 
	 {
	  otherTrans.x += .3f;
	 }
	 otherRot.Rotate (0, 0, 90);
	}
   }

   // Create a new shot
   var shotTransform = Instantiate(shotPrefab, otherTrans, otherRot.rotation) as Transform;

   // The is enemy property
   ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
   if(shot != null)
   {
	shot.isEnemyShot = isEnemy;
   }

   // Make the weapon shot always towards it
   MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
   if(move != null)
   {
	move.direction = this.transform.right; // towards in 2D space is the right of the sprite
   }
  }
 }
	
 public bool CanAttack
 {
  get
  {
   return shootCooldown <= 0f;
  }
 }
}