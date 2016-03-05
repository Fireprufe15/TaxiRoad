using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float tiltAmount = 30f;
	public float tiltSpeed = 10f;

	float side;


	void Update () {
		side = Input.GetAxis ("Horizontal");


		Vector3 movement = new Vector3 (this.gameObject.GetComponent<Transform>().position.x + side * speed * Time.deltaTime,
		                                this.gameObject.GetComponent<Transform>().position.y,
		                                this.gameObject.GetComponent<Transform>().position.z);

		if (side > 0 && GetComponent<Transform> ().rotation.x < Quaternion.Euler (tiltAmount, 0f, 0f).x) {
			GetComponent<Transform> ().rotation = Quaternion.RotateTowards (GetComponent<Transform> ().rotation, 
			                                                              Quaternion.Euler (tiltAmount, 90f, 0f),
			                                                              tiltSpeed);
		} else if (side < 0 && GetComponent<Transform> ().rotation.x > Quaternion.Euler (-tiltAmount, 0f, 0f).x) {
			GetComponent<Transform> ().rotation = Quaternion.RotateTowards (GetComponent<Transform> ().rotation, 
			                                                              Quaternion.Euler (-tiltAmount, 90f, 0f),
			                                                              tiltSpeed);
		}
		else
		{
			GetComponent<Transform> ().rotation = Quaternion.RotateTowards (GetComponent<Transform> ().rotation, 
			                                                                Quaternion.Euler (0f, 90f, 0f),
			                                                                tiltSpeed);
		}

		this.gameObject.GetComponent<Transform> ().position = movement;
	}
}
