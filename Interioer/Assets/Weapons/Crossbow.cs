using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour {

    [SerializeField] private GameObject projectile;
    private Transform source;
    public const float SPEED = 0.25f;
    public const float FIRE_DELAY = .3f;  // seconds
    private float lastFire = 0f;

    private void Awake() {
        source = this.transform;
    }

    void Shoot() {
        GameObject p = Instantiate(projectile, source.transform.position, source.transform.rotation);
        var rb = p.GetComponent<Rigidbody>();
        rb.AddForce(p.transform.forward * SPEED, ForceMode.Impulse);
        lastFire = Time.fixedTime;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            if (Time.fixedTime - lastFire >= FIRE_DELAY) {
                Shoot();
            }
        }
    }
}
