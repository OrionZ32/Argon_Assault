using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShip : MonoBehaviour {

    [Tooltip("In ms^-1")] [SerializeField] float speed = 4f;

    [Tooltip("In m")] [SerializeField] float xRange = 2f;
    [Tooltip("In m")] [SerializeField] float yRange = 2f;

    float xThrow, yThrow;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    void Start() {
        
    }

    void Update() {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation() {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;
        
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
}
