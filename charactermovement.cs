using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        moveDirection = transform.TransformDirection(moveDirection);

        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.transform.position.y;

        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = targetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}



// yusufortacdeveloper