using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float force;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.AddForce(new Vector3(force, 0, 0));
    }
}
