using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesDestroy : MonoBehaviour
{
    [SerializeField] float delayTime = 1.0f;
    void Start()
    {
        Destroy(gameObject,delayTime);
    }
}
