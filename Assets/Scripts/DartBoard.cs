using UnityEngine;

public class DartBoard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dart"))
        {
            Rigidbody dartRigidbody = other.GetComponent<Rigidbody>();
            Dart dart = other.GetComponent<Dart>();
            
            dartRigidbody.useGravity = false;
            dartRigidbody.isKinematic = true;
            dart.IsThrowing = false;
        }
    }
}
