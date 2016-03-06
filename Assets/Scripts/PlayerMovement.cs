using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;
    public Camera cam;
	public float tiltAmount = 30f;
	public float tiltSpeed = 10f;

	float side;


	void Update () {
        
        Vector3 viewpos = cam.WorldToViewportPoint(transform.position);
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
        if (viewpos.x > 0.03 && side < 0)
        {
            this.gameObject.GetComponent<Transform> ().position = movement;
        }else if (viewpos.x < 0.97 && side > 0)
        {
            this.gameObject.GetComponent<Transform> ().position = movement;
        }
		
	}
}
