using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform cam;
    CharacterController characterController;

    public Animator animator;
    public float speed; //speed set in inspector
    public float horizontalMovement; // float for horizontal Movement input (x axis)
    public float verticalMovement; // flaot for vertical movement input (z axis)
    public float smoothRotate = 0.1f;
    private float smoothTurnVelocity;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        characterController = GetComponent<CharacterController>(); // assigns the component for the character controller
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() 
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            //Debug.Log("Called");
            animator.SetBool("movementPressed", true);
        }
        else
        {
            animator.SetBool("movementPressed", false);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal"); // get raw horizontal movement between -1 and 1 for the x axis
        verticalMovement = Input.GetAxisRaw("Vertical"); // get raw vertical movement between -1 and 1 for the z axis
        Vector3 direction = new Vector3(horizontalMovement, 0.0f, verticalMovement).normalized; // create a vector 3 for this information

        if(direction.magnitude >= 0.1f)
        {
            float facingAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // determines the angle being face using unitys coordinate system (y axis is 0 rotating clockwise)
            float smoothedAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, facingAngle, ref smoothTurnVelocity, smoothRotate);
            transform.rotation = Quaternion.Euler(0f, smoothedAngle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, facingAngle, 0f) * Vector3.forward;
            if(characterController.enabled)
            {
                characterController.Move(moveDirection.normalized * speed * Time.deltaTime); // move the character
            }
        }
    }
}
