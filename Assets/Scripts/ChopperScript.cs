using UnityEngine;
using System.Collections;

public class ChopperScript : MonoBehaviour {
	public float HorizontalSpeed = 1;
	public float VerticalSpeed = 1;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Hazard"))
		{
			Debug.Log ("Crashed!");
		}
	}

	void Update()
	{
		double? hr = HRMScript.GetHeartRate();

		Vector3 position = this.gameObject.transform.position;
		position.z += Time.deltaTime * HorizontalSpeed;
		if(hr != null)
		{
			float allowed = Time.deltaTime * VerticalSpeed;

			if(Mathf.Abs(position.y - (float) hr) > allowed)
			{
				position.y += (position.y > hr ? -allowed : allowed);
			}
			else
			{
				position.y = (float) hr;
			}
		}

		this.gameObject.transform.position = position;
	}
}
