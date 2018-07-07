using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private float maxHealth = 20f;
    [SerializeField] private GameObject deathParticles;

    public float health;

    void Start()
    {
        health = maxHealth;    
    }

    public void InflictDamage(float damage)
    {
        health -= damage;
        CheckIfStillAlive();
    }

    private void CheckIfStillAlive()
    {
        if (health < 0f)
        {
            GameObject deathPs = Instantiate(deathParticles, transform.position + (Vector3.up * 4.5f), transform.rotation);
            Destroy(deathPs, deathPs.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
        }
    }
}
