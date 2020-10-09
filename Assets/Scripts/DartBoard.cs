using UnityEngine;

public class DartBoard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }
}
