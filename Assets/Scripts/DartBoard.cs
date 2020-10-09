using UnityEngine;

public class DartBoard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dart"))
        {
            Debug.Log("Dart");
        }
    }
}
