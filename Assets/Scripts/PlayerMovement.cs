using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	float side;

	void Start () {
	}

	void Update () {
		side = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (this.gameObject.GetComponent<Transform>().position.x + side * speed * Time.deltaTime,
		                                this.gameObject.GetComponent<Transform>().position.y,
		                                this.gameObject.GetComponent<Transform>().position.z);

		this.gameObject.GetComponent<Transform> ().position = movement;


		Debug.Log (movement);
	}
}
