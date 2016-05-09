using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    //destroys obstacles that leave the trigger collider
    //no other objects should enter the collider, but it checks anyway :)
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "obstacle") {
            Destroy(collider.gameObject);
        }
    }
}
