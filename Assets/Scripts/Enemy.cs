using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyFX;
    [SerializeField] GameObject getHitVFX;
    [SerializeField] int enemyHitPoint = 15;
    [SerializeField] int enemyKillPoint;
    [SerializeField] int hitPoint;

    GameManager gameManager;
    GameObject parentForParticles;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        parentForParticles = GameObject.FindWithTag("Parent");
    }

    private void OnParticleCollision(GameObject other)
    {
        LaserHitProcess();
        EnemyDeathSequence();
    }

    void EnemyDeathSequence()
    {
        if (hitPoint > 0) { return; }
        gameManager.IncreasetScore(enemyKillPoint);
        GameObject enemyExplored = Instantiate(enemyFX, transform.position, Quaternion.identity);
        enemyExplored.transform.parent = parentForParticles.transform;
        Destroy(gameObject);
    }

    void LaserHitProcess()
    {
        hitPoint--;
        gameManager.IncreasetScore(enemyHitPoint);
        if(hitPoint < 1) {  return; }
        GameObject enemyGetHit = Instantiate(getHitVFX, transform.position, Quaternion.identity);
        enemyGetHit.transform.parent = parentForParticles.transform;
    }


}
