using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowProjectile : MonoBehaviour {
    public const float TOTAL_LIFETIME = 2.0f; // seconds
    private float timeToLive;
    private void Awake() {
        timeToLive = TOTAL_LIFETIME;
    }

    // Update is called once per frame
    void Update() {
        timeToLive -= Time.deltaTime;
        if (timeToLive < 0) {
            Destroy(gameObject);
        }
    }
}
