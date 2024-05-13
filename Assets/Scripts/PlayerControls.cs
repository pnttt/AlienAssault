using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [Header("General Setup Settings")]

    [Tooltip("How fast ship moves up and down based upon player input")]
    [SerializeField] float controlSpeed = 30f;
    [Tooltip("How far player moves horizontally")][SerializeField] float xRange = 15f;
    [Tooltip("How far player moves vertically")][SerializeField] float yRange = 10f;
    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")][SerializeField] GameObject[] lasers;

    [Header("Screen position based tuning")]

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;

    [Header("Player input based tuning")]

    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        float rollDueToControl = xThrow * controlRollFactor;
        
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = yawDueToPosition;
        float roll = rollDueToControl;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessFiring() {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers) 
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
