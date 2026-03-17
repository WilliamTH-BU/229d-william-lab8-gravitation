using UnityEngine;

public class Spining : MonoBehaviour
{
    [SerializeField] private float tourque;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.AddTorque(new Vector3(0, tourque, 0));
    }
}
