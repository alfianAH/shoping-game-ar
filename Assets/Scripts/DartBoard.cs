using UnityEngine;

public class DartBoard : MonoBehaviour
{
    [SerializeField] private int additionalScore;
    [SerializeField] private DartManager dartManager;
    
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
            
            // Add score
            dartManager.AddScore(additionalScore);
            
            dart.IsNotUsed = true;
        }
    }
}
