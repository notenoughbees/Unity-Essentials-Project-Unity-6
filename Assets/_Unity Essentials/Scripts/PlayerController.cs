using UnityEngine;

// Controls player movement and rotation.
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Set player's movement speed.
    public float rotationSpeed = 120.0f; // Set player's rotation speed.
    public float jumpForce = 0.5f;

    private Rigidbody rb; // Reference to player's Rigidbody.

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("hello1");
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
    }

    // Update is called once per frame
    void Update()
    {
        // Jump is configured in Unity's Input Manager to correspond to Spacebar by default
        if (Input.GetButtonDown("Jump"))
        {
            // apply an upward force (Vector3.up) to the rigidbody (rb),
            //   and use VelocityChange to change the velocity directly, making the jump instant.
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }


    // Handle physics-based movement and rotation.
    private void FixedUpdate()
    {
        // Move player based on vertical input.
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // Rotate player based on horizontal input.
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}