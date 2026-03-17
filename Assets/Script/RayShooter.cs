using UnityEngine;
using UnityEngine.InputSystem;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private Transform shootPos;
    [SerializeField] private float rayLength = 5.5f;
    [SerializeField] private GameObject shootVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private float damage = 10.0f;

    // Update is called once per frame
    void Update()
    {
        ShootRay();
    }

    void ShootRay()
    {
        RaycastHit hit;

        Debug.DrawRay(shootPos.position, transform.forward * rayLength, Color.green);

        if (Physics.Raycast(shootPos.position, transform.forward, out hit, rayLength))
        {
            Debug.DrawRay(shootPos.position, transform.forward * hit.distance, Color.red);
            Debug.Log($"Ray hits: {hit.collider.name}");
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            var shootVfx = Instantiate(shootVFX, shootPos.position, shootPos.rotation, shootPos);
            var hitVfx = Instantiate(hitVFX, hit.point, Quaternion.identity);

            if (hit.collider.CompareTag("Enemy"))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }

            if (hit.collider.CompareTag("Obstacle"))
            {
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddTorque(0, 100, 0);
                }
            }

            Destroy(shootVfx, 1.5f);
            Destroy(hitVfx, 2.5f);
        }

        
    }
}
