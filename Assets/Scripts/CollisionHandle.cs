using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandle : MonoBehaviour
{
    float delayTime = 1f;
    MeshRenderer meshRenderer;
    PlayerControl playerControl;

    [SerializeField] ParticleSystem exploredSFX;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        playerControl = GetComponent<PlayerControl>();
    }
    private void OnTriggerEnter(Collider other)
    {
        CrashSequence();
    }

    void CrashSequence()
    {
        meshRenderer.enabled = false;
        playerControl.LaserActiveBehavior(false);
        playerControl.enabled = false;
        exploredSFX.Play();

        Invoke(nameof(ReloadLevel), delayTime);
    }

    void ReloadLevel()
    {
        int sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
