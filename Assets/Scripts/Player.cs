using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public bool safeTouch;
    private float jumpSpeed = 600f;

    // Use this for initialization
    void Start () {
        safeTouch = true;
	}
	
	// Update is called once per frame
	void Update () {
        Jump();
    }
   

    private bool JumpDecision() {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
                return true;
            } else {
                return false;
            }
    }

    private void Jump() {
        if (JumpDecision() && safeTouch) {
            safeTouch = false;
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpSpeed);
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space)) {
            GetComponent<Rigidbody2D>().AddForce(Vector3.down * jumpSpeed);
        }
    }

    private void KillVelocity()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        KillVelocity();
        //if (coll.gameObject.tag == "safe")
            safeTouch = true;
    }

}
