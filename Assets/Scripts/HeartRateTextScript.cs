using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeartRateTextScript : MonoBehaviour {
	Text Field;

	void Start () {
		Field = GetComponent<Text>();
	}

	void Update () {
		int? hr = HRMScript.GetHeartRate();

		if(hr == null)
		{
			Field.text = "HR: No reading";
		}
		else
		{
			Field.text = "HR: " + hr + "BPM";
		}
	}
}
