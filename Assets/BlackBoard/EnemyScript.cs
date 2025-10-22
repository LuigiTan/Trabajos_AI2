using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0) Destroy(gameObject);
    }
}