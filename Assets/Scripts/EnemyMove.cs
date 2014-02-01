using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public Vector2 up;
	public Vector2 down;
	public Vector2 right;
	public Vector2 left;
	public Vector2 stop;

	/*public float speed = 1;

	public Vector2 movement;*/

	public bool upTouch = false;
	public bool downTouch = false;
	public bool leftTouch = false;
	public bool rightTouch = false;
	public bool upLeftTouch = false;
	public bool upRightTouch = false;
	public bool downLeftTouch = false;
	public bool downRightTouch = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		/*if (rightTouch == false && upRightTouch == false && downRightTouch == true) {
						movement = new Vector2 (speed * 1, 0);//right

				} else if (downRightTouch == false && downTouch == false && downLeftTouch == true) 
		{
			movement = new Vector2 (0, speed * -1);//down
		}


		else if (upLeftTouch == false && upTouch == false && upRightTouch == true) 
		{
			movement = new Vector2 (speed * -1, 0);//left
		}

		else if (upLeftTouch == false && upTouch == false && upRightTouch == true) 
		{
			movement = new Vector2 (speed * -1, 0);//left
		}*/

		if (rightTouch == true) {

						rigidbody2D.velocity = up;
				} else if (rightTouch == false && upRightTouch == false && downRightTouch == true) {
						rigidbody2D.velocity = right;	
				} else if (downRightTouch == false && downTouch == false && downLeftTouch == true) {
						rigidbody2D.velocity = down;
				} else if (downLeftTouch == false && leftTouch == false && upLeftTouch == true) {
			rigidbody2D.velocity = left;
		}

		else if (upLeftTouch == false && upTouch == false && upRightTouch == true) {
			rigidbody2D.velocity = up;
		}


	}


}
