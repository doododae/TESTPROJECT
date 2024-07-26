using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;

        if(Input.GetKey("w")) {
            pos.y += moveSpeed * Time.deltaTime;
        }

        if(Input.GetKey("a")) {
            pos.x -= moveSpeed * Time.deltaTime;
        }

        if(Input.GetKey("s")) {
            pos.y -= moveSpeed * Time.deltaTime;
        }

        if(Input.GetKey("d")) {
            pos.x += moveSpeed * Time.deltaTime;
        }
        
        this.transform.position = pos;
    }
}
