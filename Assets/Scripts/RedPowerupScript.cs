using UnityEngine;
using System.Collections;

public class RedPowerupScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Samus player = other.gameObject.GetComponent<Samus> ();
		if(player != null) {
			player.canBall = true;
			Destroy (this.gameObject);
		}
	}
}
