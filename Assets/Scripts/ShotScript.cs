using UnityEngine;

public class ShotScript : MonoBehaviour
{
 public int damage = 1;
 public bool isEnemyShot = false;
 public float timeToLive = .25f;

 void Start()
 {
  Destroy(gameObject, timeToLive);
 }
}