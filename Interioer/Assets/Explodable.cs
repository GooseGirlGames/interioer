using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodable : MonoBehaviour {
    [SerializeField] private GameObject explodedPrefab;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void Explode(GameObject projectile = null) {
        //var parentscale = transform.localScale;
        //GameObject exploded = Instantiate(explodedPrefab, transform.position, transform.rotation);
        Instantiate(explodedPrefab, transform.position, transform.rotation, transform.parent);
        //exploded.transform.localScale = parentscale;
        Destroy(gameObject);
        if (projectile) {
            Destroy(projectile);
        }
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Projectile")) {
            Explode(col.gameObject);
            Debug.Log("Collision!");
        }
    }
}
