using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private float maxHealth = 20f;
    [SerializeField] private GameObject deathParticles;
    [SerializeField] private GameObject explodeParticles;

    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioClip deathClip;

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


    public void Explode()
    {
        PlayDeathClip();

        GameObject explodePs = Instantiate(explodeParticles, transform.position + (Vector3.up * 4.5f), transform.rotation);
        Destroy(explodePs, explodePs.GetComponent<ParticleSystem>().main.duration);
        Destroy(gameObject);
    }

    private void PlayHitClip()
    {
        AudioSource.PlayClipAtPoint(hitClip, Camera.main.transform.position, 1f);
    }

    private void PlayDeathClip()
    {
        AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position, 1f);
    }

    private void CheckIfStillAlive()
    {
        if (health < 0f)
        {
            GameObject deathPs = Instantiate(deathParticles, transform.position + (Vector3.up * 4.5f), transform.rotation);
            Destroy(deathPs, deathPs.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
        }
        else
        {
            PlayHitClip();
        }
    }
}
