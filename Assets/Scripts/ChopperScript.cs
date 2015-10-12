using UnityEngine;
using System.Collections;

public class ChopperScript : MonoBehaviour {
	public float HorizontalSpeed = 1;
	public float VerticalSpeed = 1;
	public int TakeOffTriggerThreshold = 100;
	public bool TakeOffTriggered = false;
	public bool Paused = false;

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Hazard"))
		{
			Debug.Log ("Crashed!");
			Paused = true;
		}
	}

	void Update()
	{
		int? hr = HRMScript.GetHeartRate();

		if(hr > TakeOffTriggerThreshold) TakeOffTriggered = true;

		if(hr != null && TakeOffTriggered && !Paused)
		{
			Vector3 position = this.gameObject.transform.position;
			position.z += Time.deltaTime * HorizontalSpeed;

			float allowed = Time.deltaTime * VerticalSpeed;

			if(Mathf.Abs(position.y - (float) hr) > allowed)
			{
				position.y += (position.y > hr ? -allowed : allowed);
			}
			else
			{
				position.y = (float) hr;
			}
			
			this.gameObject.transform.position = position;
		}
	}
}
