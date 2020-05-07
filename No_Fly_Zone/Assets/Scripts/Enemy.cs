using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject enemyExplosion;
    [SerializeField] Transform parent;

    void Start() {
    Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;    
    }

    void OnParticleCollision(GameObject other) {

        GameObject explosionFx = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
        explosionFx.transform.parent = parent;
        Destroy(gameObject);
    }
}
