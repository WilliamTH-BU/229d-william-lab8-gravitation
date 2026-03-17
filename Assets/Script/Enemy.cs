using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private GameObject onDeath;

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"{name}: took {damage} damage!");

        if ( health <= 0)
        {
            var ondeath = Instantiate( onDeath, transform.position, Quaternion.identity);
            Destroy( ondeath, 1.5f);
            Destroy(gameObject, 0.5f);
        }
    }
}
