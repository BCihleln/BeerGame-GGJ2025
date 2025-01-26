using UnityEngine;
using TMPro;

public class BeerHandler : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 25f;
    public int playerID;
    public Transform stream;

    private float pourUpperLimit = 80f;
    private float pourLowerLimit = 160f;

    private float forwardSpeed = 1.6f;
    private float recoverSpeed = -0.8f;

    public Bottles chosenBottle;

    public KeyCode LeftKey { get; set; }
    public KeyCode RightKey { get; set; }
    public KeyCode PourKey { get; set; }

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = chosenBottle.bottleSprite;
        if (playerID == 1)
        {
            LeftKey = KeyCode.A;
            RightKey = KeyCode.D;
            PourKey = KeyCode.W;
        }
        else
        {
            LeftKey = KeyCode.LeftArrow;
            RightKey = KeyCode.RightArrow;
            PourKey = KeyCode.UpArrow;
        }
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

        if (Input.GetKey(LeftKey))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(RightKey))
        {
            horizontalInput = 1f;
        }

        if (Input.GetKey(PourKey))
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

        if (Input.GetKey(LeftKey))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(RightKey))
        {
            horizontalInput = 1f;
        }

        if (Input.GetKey(PourKey))
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
