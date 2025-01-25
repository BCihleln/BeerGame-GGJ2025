using UnityEngine;

public class BeerHandler : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 25f;
    public int playerID;
    public Transform stream;

    private float pourUpperLimit = 80f;
    private float pourLowerLimit = 180f;

    private float forwardSpeed = 1.6f;
    private float recoverSpeed = -0.8f;

    public Bottles chosenBottle;

    private void Start() {
        gameObject.GetComponent<SpriteRenderer>().sprite = chosenBottle.bottleSprite;
    }

    private void Update()
    {
        if(playerID == 1){
            P1InputUpdate();
        }
        else{
            P2InputUpdate();
        }
        stream.eulerAngles = new Vector3(0, 0, 0);
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
            verticalInput = forwardSpeed;
        }
        else
        {
            verticalInput = recoverSpeed;
        }

        transform.position += (new Vector3(1, 0, 0) * horizontalInput * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 1) * verticalInput * rotationSpeed * Time.deltaTime);
        float zRotation = transform.eulerAngles.z;
        if (zRotation < pourUpperLimit) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, pourUpperLimit);
        if (zRotation > pourLowerLimit) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, pourLowerLimit);
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
            verticalInput = forwardSpeed;
        } 
        else 
        {
            verticalInput = recoverSpeed;
        }

        transform.position += (new Vector3(1, 0, 0) * horizontalInput * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 1) * verticalInput * rotationSpeed * Time.deltaTime);
        float zRotation = transform.eulerAngles.z;
        if (zRotation < pourUpperLimit) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, pourUpperLimit);
        if (zRotation > pourLowerLimit) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, pourLowerLimit);
    }
}
