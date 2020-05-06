using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField] GameObject shipExplosion;
    [SerializeField] float levelLoadDelay = 1f;

    private void OnTriggerEnter(Collider other) {
        DeathSequence();
        shipExplosion.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void DeathSequence() {
        SendMessage("OnPlayerDeath");
    }

    private void ReloadLevel() {
        SceneManager.LoadScene(1);
    }    
}
