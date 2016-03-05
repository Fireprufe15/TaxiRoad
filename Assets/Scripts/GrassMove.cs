using UnityEngine;
using System.Collections;

public class GrassMove : MonoBehaviour {

	private float speed;

	void Start () {
        speed = RoadCreator.speed;
	}

	void Update () 
	{
        speed = RoadCreator.speed;
		if (this.gameObject.transform.position.z > 400f)
		{
			this.gameObject.transform.position = new Vector3(
				this.gameObject.transform.position.x,
				this.gameObject.transform.position.y,
				-580f);
		}

		this.gameObject.transform.position = new Vector3 (
			this.gameObject.transform.position.x,
			this.gameObject.transform.position.y,
			this.gameObject.transform.position.z + speed * Time.deltaTime);
	}
}
