using UnityEngine;
using System.Collections;

public class ChopperScript : MonoBehaviour {
	public float HorizontalSpeed = 1;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Hazard"))
		{
			Debug.Log ("Crashed!");
		}
	}

	void Update()
	{
		Vector3 position = this.gameObject.transform.position;
		position.z += Time.deltaTime * HorizontalSpeed;
		this.gameObject.transform.position = position;
	}
}
