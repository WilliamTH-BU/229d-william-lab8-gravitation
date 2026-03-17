using UnityEngine;

public class ChangeObjecrColor : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        GetComponent<Renderer>().material.color = Color.cyan;

        other.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().material.color = Color.violet;

        other.gameObject.GetComponent<Renderer>().material.color = Color.darkBlue;
    }
}
