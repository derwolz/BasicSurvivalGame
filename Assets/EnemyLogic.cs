using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int health = 1;
    private void Update()
    {
        if (health <= 0)
        {
            Dead();
        }
        else
        {
            Alive();
        }
    }
    void ApplyDamage(int Damage)
    {
        health -= Damage;
    }
    void Dead()
    {
        Destroy(gameObject);
    }
    void Alive()
    {
        return;
    }
}
