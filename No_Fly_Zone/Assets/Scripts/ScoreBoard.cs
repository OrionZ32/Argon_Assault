using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    [SerializeField] int scorePerSecond = 5;

    int score;
    Text scoreText;

    void Start() {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    void Update() {
        for(int i = 0; i > 0; i++) {
            ScoreOverTime();
        }
    }

    public void ScoreHit(int scoreIncrease) {
        score = score + scoreIncrease;
        scoreText.text = score.ToString();
    }

    public void ScoreOverTime() {
        score = score + scorePerSecond;
        scoreText.text = score.ToString();
    }
    
}
