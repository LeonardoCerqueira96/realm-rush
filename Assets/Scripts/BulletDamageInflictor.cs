using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageInflictor : MonoBehaviour {

    Tower tower;

    void Start()
    {
        tower = GetComponentInParent<Tower>();
    }

    private void OnParticleCollision(GameObject other)
    {
        EnemyHealthController enemy;
        if (enemy = other.GetComponentInParent<EnemyHealthController>())
        {
            enemy.InflictDamage(tower.GetDamageTreshhold());
        }
    }
}
