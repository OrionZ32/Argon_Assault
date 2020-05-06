using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField] GameObject deathFx;
    [SerializeField] float levelLoadDelay = 1f;

    private void OnTriggerEnter(Collider other) {
        DeathSequence();
    }

    private void DeathSequence() {
        SendMessage("OnPlayerDeath");
        deathFx.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel() {
        SceneManager.LoadScene(1);
    }    
}
