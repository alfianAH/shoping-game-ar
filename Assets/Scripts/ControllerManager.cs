using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    [SerializeField] private Dart dart;
    [SerializeField] private FixedButton downButton,
        upButton;

    [SerializeField] private float rotationSpeed;
    
    private void Update()
    {
        if (upButton.pressed)
        {
            UpButton();
        }

        if (downButton.pressed)
        {
            DownButton();
        }
    }

    private void UpButton()
    {
        dart.transform.Rotate(new Vector3(5f, 0f, 0f) * 
                             (rotationSpeed * Time.deltaTime));
        dart.CalculateV0();
    }

    private void DownButton()
    {
        dart.transform.Rotate(new Vector3(-5f, 0f, 0f) * 
                             (rotationSpeed * Time.deltaTime));
        dart.CalculateV0();
    }

    public void SetDart(Dart newDart)
    {
        dart = newDart;
    }
}
