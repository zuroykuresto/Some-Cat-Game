using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public static int scoreValue = 0;
    Text scoreText;
	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + scoreValue.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + scoreValue.ToString();
    }
}
