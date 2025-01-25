using UnityEngine;

public class BeerHandler : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public int playerID;

    private void FixedUpdate()
    {
        if(playerID == 1){
            P1InputUpdate();
        }
        else{
            P2InputUpdate();
        }
    }

    private void P1InputUpdate()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1f;
        }

        transform.position += (new Vector3(1, 0, 0) * horizontalInput * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 1) * verticalInput * rotationSpeed * Time.deltaTime);
        float zRotation = transform.eulerAngles.z;
        if (zRotation < 90) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
        if (zRotation > 150) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 150);
    }

    private void P2InputUpdate()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput = -1f;
        }

        transform.position += (new Vector3(1, 0, 0) * horizontalInput * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 1) * verticalInput * rotationSpeed * Time.deltaTime);
        float zRotation = transform.eulerAngles.z;
        if (zRotation < 90) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
        if (zRotation > 150) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 150);
    }
}
