using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController characterController;

    public float speed;
    public float mouseSpeed = 1;
    public float gravity;
    public float jumpSpeed;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
    characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * mouseSpeed);
    }
}
