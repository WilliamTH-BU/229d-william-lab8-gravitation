using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.InputSystem;

public class AirPlane : MonoBehaviour
{
    public float enginePower = 20.0f;
    public float liftBooster = 0.5f;
    public float drag = 0.01f;
    public float angularDrag = 0.01f;

    public float yawPower = 50f;
    public float pitchPower = 50f;
    public float rollPower = 30f;

    public float sensitivy = 3f;
    public float gravity = 3f;

    private Rigidbody rb;
    public GameObject vfxPlane;
    public GameObject vfxPos;

    private float currentYaw;
    private float currentPitch;
    private float currentRoll;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            rb.AddForce(transform.forward *  enginePower);
        }

        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude);

        rb.linearDamping = rb.linearVelocity.magnitude * drag;
        rb.angularDamping = rb.linearVelocity.magnitude * angularDrag;

        float targetYaw = (Keyboard.current.eKey.isPressed ? 1f : 0f) - (Keyboard.current.qKey.isPressed ? 1f : 0f);
        currentYaw = Mathf.MoveTowards(currentYaw, targetYaw, (targetYaw == 0 ? gravity : sensitivy) * Time.deltaTime);

        float targetPitch = (Keyboard.current.wKey.isPressed ? 1f : 0f) - (Keyboard.current.sKey.isPressed ? 1f : 0f);
        currentPitch = Mathf.MoveTowards(currentPitch, targetPitch, (targetPitch == 0 ? gravity : sensitivy) * Time.deltaTime);

        float targetRoll = (Keyboard.current.aKey.isPressed ? 1f : 0f) - (Keyboard.current.dKey.isPressed ? 1f : 0f);
        currentRoll = Mathf.MoveTowards(currentRoll, targetRoll, (targetRoll == 0 ? gravity : sensitivy) * Time.deltaTime);

        rb.AddTorque(transform.up * (currentYaw * yawPower));
        rb.AddTorque(transform.right * (currentPitch * pitchPower));
        rb.AddTorque(transform.forward * (currentRoll * rollPower));
    }
}
