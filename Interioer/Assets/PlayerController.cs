using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float speed = 12.0f;
    private Rigidbody rb;
    private float movementSmoothing = .01f;
    private float jumpHeight = 120.0f;
    private const float JUMP_EPSILON = 0.01f;
    
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
        var y = rb.velocity.y;
        var newVelocity = Vector3.SmoothDamp(
            rb.velocity, targetVelocity, ref zero, movementSmoothing
        );
        rb.velocity = new Vector3(
            newVelocity.x,
            y,
            newVelocity.z
        );



        UpdateRotation();
    }

    void Update() {
        //UpdateRotation();

        if (Input.GetButtonDown("Jump") && (Mathf.Abs(rb.velocity.y) < JUMP_EPSILON)) {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }

    }

    private void UpdateRotation() {
        Plane ground = new Plane(Vector3.down, transform.position.y);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (ground.Raycast(ray, out distance)) {
            var lookAtPosition = ray.GetPoint(distance);
            var relativePos = lookAtPosition - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos);
        }
    }
}
