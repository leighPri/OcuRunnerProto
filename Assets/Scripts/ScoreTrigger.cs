using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTrigger : MonoBehaviour {

    public static int score;
    //determines how much score goes up as time passes
    private float scoreRate = 300f;
    private Text scoreText;

    void Start() {
        scoreText = FindObjectOfType<Text>();
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("02_Game")) {
            score = 0; //resets score on load of new game only
        }
    }

    //captures score value of obstacle object
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "obstacle") {
            float tempScore = collider.gameObject.GetComponent<Obstacle>().score;
            AddScore(tempScore);
        }
    }

    void Update() {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("02_Game")) { 
            GradualScore();
        }
        UpdateScore();
    }
    

    //adds tempScore to the main score...eventually
    void AddScore(float plusScore) {
        score += (int) plusScore;
    }

    void GradualScore() {
        float tempScore = Time.frameCount / scoreRate;
        score += (int) tempScore;
    }

    private void UpdateScore() {
        scoreText.text = score.ToString();
    }

}
