using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Position Attributes")]
    [SerializeField] float moveSpeed;
    [SerializeField] float xRange = 9f;
    [SerializeField] float yRange = 6f;

    [Header("LaserArray")]
    [SerializeField] GameObject[] lasers;

    [Header("Rotation Attributes")]
    [SerializeField] float pitchPostionFactor = -5f;
    [SerializeField] float yawPostionFactor = 3f;
    [SerializeField] float rollPostionFactor  = -6f;

    

    private void Update()
    {
        PositionControl();
        RotateControl();
        LaserShootingControl();
    }

    void PositionControl()
    {
        float xPos = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float yPos = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        float newPosX = transform.localPosition.x + xPos;
        float newPosY = transform.localPosition.y + yPos;

        float clampedXPos = Mathf.Clamp(newPosX, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(newPosY, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void RotateControl()
    {
        float pitch = transform.localPosition.y * pitchPostionFactor;
        float yaw = transform.localPosition.x * yawPostionFactor;
        float roll = transform.localPosition.x * rollPostionFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void LaserShootingControl()
    {
        if (Input.GetButton("Fire1"))
        {
            LaserActiveBehavior(true);
        }
        else
        {
            LaserActiveBehavior(false);
        }
    }

    public void LaserActiveBehavior(bool isActive)

    {
        foreach(GameObject laser in lasers)
        {
            var laserEmission = laser.GetComponent<ParticleSystem>().emission;
            laserEmission.enabled = isActive;
        }
    }

}
