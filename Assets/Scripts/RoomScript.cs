using UnityEngine;

public class RoomScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dart"))
        {
            Rigidbody dartRigidbody = other.GetComponent<Rigidbody>();
            Dart dart = other.GetComponent<Dart>();
            
            // Stop dart
            dartRigidbody.useGravity = false;
            dartRigidbody.isKinematic = true;
            dart.IsThrowing = false;
            dart.IsNotUsed = true;
        }
    }
}
