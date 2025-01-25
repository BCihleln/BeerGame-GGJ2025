using UnityEngine;

public class StreamHandler : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        // float verticalInput = Input.GetAxis("Vertical");
        // transform.Rotate(-1 * new Vector3(0, 0, 1) * verticalInput * rotationSpeed * Time.deltaTime);
        // float zRotation = transform.eulerAngles.z;
        // // Debug.Log(zRotation);
        // if (zRotation > -90 + 90) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -90 + 90);
        // if (zRotation < -150 + 90) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -150 + 90);
    }
}
