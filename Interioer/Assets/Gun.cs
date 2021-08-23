using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [SerializeField] private GameObject projectile;

    // Start is called before the first frame update
    void Start() {
        
    }

    void Shoot() {
        GameObject p = Instantiate(projectile, transform.position, transform.rotation);
        var rb = p.GetComponent<Rigidbody>();
        float speed = 20.0f;
        float x = Random.Range(-1.0f, 1.0f);
        float y = 0.0f;
        float z = Random.Range(-1.0f, 1.0f);
        rb.AddForce(x * speed, y * speed, z * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Jump")) {
            Shoot();
        }
    }
}
