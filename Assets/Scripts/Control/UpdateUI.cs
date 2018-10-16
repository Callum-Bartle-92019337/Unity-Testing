using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UpdateUI : MonoBehaviour {

    [SerializeField]
    private Text timerLabel;

    [SerializeField]
    private Text scoreLable;
	
	// Update is called once per frame
	void Update () {
        timerLabel.text = "Time Remaining: " + FormatTime(GameControler.Instance.TimeRemaining);
        scoreLable.text = "Pickups Gathered: " + GameControler.Instance.PickupsGathered;
	}
    private string FormatTime(float timeInSeconds) {
        return string.Format("{0}:{1:00}",
            Mathf.FloorToInt(timeInSeconds / 60),
            Mathf.FloorToInt(timeInSeconds % 60));
    }
}
