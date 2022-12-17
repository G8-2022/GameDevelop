using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float shiftSpeed;
    public float jumpForce;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

        //rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        //if (Input.GetButtonDown("Jump"))
        //{
        //    rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        //}

        // moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);



        //if (Input.GetButtonDown("left shift"))
        //{
        //    Debug.Log("Shift is pressed");
        //    float yStore = moveDirection.y;
        //    moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        //    //Фіксимо швидкість гравця, коли він рухається по діагоналі
        //    moveDirection = moveDirection.normalized * (moveSpeed + shiftSpeed);
        //    moveDirection.y = yStore;
        //}
        //else
        //{
            float yStore = moveDirection.y;
            moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
            //Фіксимо швидкість гравця, коли він рухається по діагоналі
            moveDirection = moveDirection.normalized * moveSpeed;
            moveDirection.y = yStore;
        //}


        if (controller.isGrounded)
        {
            moveDirection.y = 0f;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);


    }
}
