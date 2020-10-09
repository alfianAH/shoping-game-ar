using UnityEngine;

public class Dart : MonoBehaviour
{
    private Rigidbody dartRigidbody;

    private void Start()
    {
        dartRigidbody = GetComponent<Rigidbody>();
    }
}
