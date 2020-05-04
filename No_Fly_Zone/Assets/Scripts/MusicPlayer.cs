using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

    void Start() {
        Invoke("LoadFirstScene", 3f);
        DontDestroyOnLoad(this.gameObject);
    }

    void LoadFirstScene() {
        SceneManager.LoadScene(1);     
    }
}
