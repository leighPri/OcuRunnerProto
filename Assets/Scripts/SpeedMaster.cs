using UnityEngine;
using System.Collections;

public class SpeedMaster : MonoBehaviour {
    
    public float obstacleSpeed;
    public int spawnSpeed;
    private int scoreMultiplier;
    private float maxSpeed = 12f;
    
    private Spawner spawner;

    void Start() {
        spawner = FindObjectOfType<Spawner>();
        scoreMultiplier = 1;
        obstacleSpeed = 2f;
        spawnSpeed = 80;
    }

    void Update() {
        if (DifficultyIncreaseCheck()) {
            spawner.SetSpawnSpeed();
            SetSpeed();
        }
    }

    void SetSpeed() {
        obstacleSpeed = obstacleSpeed * 1.5f;
        if (obstacleSpeed > maxSpeed) {
            obstacleSpeed = maxSpeed;
        }
    }

    bool DifficultyIncreaseCheck() {
        int scoreRate = 10000;
        if (ScoreTrigger.score > scoreRate * scoreMultiplier) {
            scoreMultiplier++;
            return true;
        } else {
            return false;
        }
    }
    

}

