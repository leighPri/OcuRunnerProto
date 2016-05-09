using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour {

    public float score;
    private SpeedMaster speedMaster;

    void Start() {
        speedMaster = FindObjectOfType<SpeedMaster>();
    }

    void Update() {
        MoveLeft(speedMaster.obstacleSpeed);
    }
   

    void MoveLeft(float speed) {
        transform.position += new Vector3(-speed * Time.deltaTime, 0);
    }

    //captures collisions and ends game if comes in contact with player
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "player")
        {
            //Debug.Log("player hit, game over");
            //replace with move to 03_GameOver:
            SceneManager.LoadScene("03_GameOver");
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "safe") {
            this.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }


}
