using UnityEngine;
using System.Collections;

public class HealthDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		GameObject go = GameObject.Find ("Player");
		guiText.text = (go.GetComponent<SamusStats> ().health).ToString("D2");
	}
}
