using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float speed = 20.0f;
    private Rigidbody rb;
    private float movementSmoothing = .01f;
    
    void Start() {
        rb = GetComponent<Rigidbody>();        
    }


    void FixedUpdate() {
        Vector2 movementRaw = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );
        Vector2 movement =
            movementRaw
            * speed;
            //* Time.fixedDeltaTime;
        Vector3 targetVelocity = Quaternion.AngleAxis(45, Vector3.up) * new Vector3(
            movement.x,
            0,
            movement.y
        );
        var zero = Vector3.zero;
        rb.velocity = Vector3.SmoothDamp(
            rb.velocity, targetVelocity, ref zero, movementSmoothing
        );
        Debug.Log("???");
        Debug.Log(movementRaw);
        Debug.Log(movement);
    }
}
