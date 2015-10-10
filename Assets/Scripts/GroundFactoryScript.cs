using UnityEngine;
using System.Collections;

public class GroundFactoryScript : MonoBehaviour {
	private const int ZONE_1 = 0;
	private const int ZONE_2 = 1;
	private const int ZONE_3 = 2;
	private const int ZONE_4 = 3;
	private const int ZONE_5 = 4;

	public int[] HeartRateZones = {0, 113, 150, 168, 187}; 
	public Transform Template;

	private int[] Level = {
		ZONE_1,
		ZONE_1,
		ZONE_1,
		ZONE_2,
		ZONE_2,
		ZONE_3,
		ZONE_3,
		ZONE_4,
		ZONE_4,
		ZONE_5,
		ZONE_5,
		ZONE_4,
		ZONE_4,
		ZONE_3,
		ZONE_3,
		ZONE_2,
		ZONE_2,
		ZONE_1,
		ZONE_1
	};
	
	void Start () {
		int z = 0;
		int? lastZone = null;

		foreach(int zone in Level)
		{
			int target = HeartRateZones[zone];

			if(lastZone == null || lastZone == zone)
			{
				Instantiate(Template, new Vector3(0, target, z), Quaternion.identity);
			}
			else
			{
				int previous = HeartRateZones[(int)lastZone];
				float vDiff = target - previous;
				float hDiff = 200f;
				Debug.Log ("vDiff: " + vDiff + ", hDiff: " + hDiff);
				float angle = (Mathf.Atan(-(target - previous) / 200f) / Mathf.PI) * 180f;
				Debug.Log ("Angle: " + angle);
				Transform clone = (Transform) Instantiate(Template, new Vector3(0, target - vDiff/2, z), Quaternion.Euler(angle, 0, 0));
				Vector3 scale = clone.localScale;
				scale.z = Mathf.Sqrt(hDiff*hDiff + vDiff*vDiff);
				clone.localScale = scale;
			}

			lastZone = zone;
			z += 200;
		}
	}
}
