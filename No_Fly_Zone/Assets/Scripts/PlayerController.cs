using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 2f;
    [Tooltip("In m")] [SerializeField] float yRange = 2f;
    [SerializeField] GameObject[] guns;

    [Header("Screen Position Control")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;
    
    float xThrow, yThrow;
    bool isControlEnabled = true;

    void Update() {
        if (isControlEnabled) {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    private void ProcessTranslation() {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;
        
        float clampedXPos = Mathf.Clamp(rawXPos ,-xRange, xRange);
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation() {
        float pitchDueToPos = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPos + pitchDueToControl;

        float yaw = transform.localPosition.x * positionYawFactor;
        
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    private void ProcessFiring() {
        if (CrossPlatformInputManager.GetButton("Fire")) {
            ActivateBullets();
        }
        else {
            DeactivateBullets();
        }
    }

    private void ActivateBullets() {
        foreach (GameObject gun in guns) {
            gun.SetActive(true);
        }
    }

    private void DeactivateBullets() {
        foreach (GameObject gun in guns) {
            gun.SetActive(false);
        }
    }

    //called by string reference in CollisionHandler.cs
    private void OnPlayerDeath() {
        // print ("player died");
        isControlEnabled = false;
    
    }
}
