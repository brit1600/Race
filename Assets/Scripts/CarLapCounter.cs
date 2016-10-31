using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CarLapCounter : MonoBehaviour {

	public TrackLapTrigger first;
    public Text P1Lap;
	TrackLapTrigger next;
    public Text P1Win;
    public Text P2Win;
	int lap;
   
	// Use this for initialization
	void Start () {
		lap = 0;
		SetNextTrigger(first);
		UpdateText();
    }

	// update lap counter text
	void UpdateText() {
		if (P1Lap)
        {
			P1Lap.text = string.Format("Lap {0}", lap);		
		}
        if (P1Win && lap == 3)
        {
            P1Win.text = string.Format("Player 1 Winner");
        }
        if (P2Win && lap ==3)
        {
            P2Win.text = string.Format("Player 2 Winner");
        }
	}
    public void Update()
    {
        if(lap == 3)
        {
            CarMovement.acceleration = 0f;

        }
    }
	// when lap trigger is entered
	public void OnLapTrigger(TrackLapTrigger trigger) {
		if (trigger == next) {
			if (first == next) {
				lap++;
				UpdateText();
			}
			SetNextTrigger(next);
		}
	}
	void SetNextTrigger(TrackLapTrigger trigger) {
		next = trigger.next;
		SendMessage("OnNextTrigger", next, SendMessageOptions.DontRequireReceiver);
	}
}
