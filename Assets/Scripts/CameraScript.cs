using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public GameObject Chopper;
	public Vector3 Distance;

	void Update () {
		this.gameObject.transform.position = (Chopper.transform.position + Distance);
	}
}
