using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEditorInternal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    //public CharacterController controller;

    //private Vector3 moveDirecriion;
    //public float gravityScale;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        //controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        //moveDirecriion = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);

        //if(Input.GetButtonDown("Jump"))
        //{
        //    moveDirecriion.y = jumpForce;
        //}

        //moveDirecriion.y = moveDirecriion.y + (Physics.gravity.y * gravityScale);
        //controller.Move(moveDirecriion * Time.deltaTime);


    }
}
