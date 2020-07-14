using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

    Time myTime;
    Text timeText;
	// Use this for initialization
	void Start () {
        timeText = GetComponent<Text>();
        
	}
	
	// Update is called once per frame
	void Update () {
        string minutes = Mathf.Floor(Time.time / 60).ToString("00");
        string seconds = (Time.time % 60).ToString("00");
        timeText.text = string.Format("Time: {0}:{1}", minutes, seconds);
        
    }
}
