using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBLight : MonoBehaviour {

    private float hue = 0f;
    private float speed = 10.0f;
    new public Light light;

    // Start is called before the first frame update
    void Start() {
        hue = Random.Range(0.0f, 1.0f);
        speed += Random.Range(-2.0f, 2.0f);
    }

    private void FixedUpdate() {
        float hueDelta = Time.fixedDeltaTime / speed;
        hue = Mathf.Repeat(hue + hueDelta, 1);
        light.color = Color.HSVToRGB(hue, 1, 1);
    }

}
