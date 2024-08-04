using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.gameObject.name);
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Colliding with " + collision.gameObject.name);
    }

    // Gets called when the object exits the collision
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exited collision with " + collision.gameObject.name);
    }
}
