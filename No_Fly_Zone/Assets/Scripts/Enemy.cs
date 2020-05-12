using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject enemyExplosion;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 10;


    ScoreBoard scoreBoard;

    void Start() {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider() {
        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;   
    }

    void OnParticleCollision(GameObject other) {
        scoreBoard.ScoreHit(scorePerHit);
        GameObject explosionFx = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
        explosionFx.transform.parent = parent;
        Destroy(gameObject);
    }
}
