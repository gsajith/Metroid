using UnityEngine;
using System.Collections;

public class HealthDisplay : MonoBehaviour 
{
 void Update() 
 {
  GameObject go = GameObject.Find ("Player");
  guiText.text = (go.GetComponent<SamusStats> ().health).ToString("D2");
 }
}
