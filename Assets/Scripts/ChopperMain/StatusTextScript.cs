using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusTextScript : MonoBehaviour {
	public ChopperScript Chopper;
	public Text Message;

	void Start () {
		Message = GetComponent<Text>();
	}

	void Update () {
		if(Chopper.Crashed)
		{
			Message.text = "You crashed! Idiot!";
		}
		else if(Chopper.Won)
		{
			Message.text = "You win!";
		}
		else if(Chopper.TakeOffTriggered)
		{
			Message.text = "Pedal your way over the obstacles";
		}
		else
		{
			Message.text = "Get your heart rate over " + Chopper.TakeOffTriggerThreshold + "BPM to take off!";
		}
	}
}
