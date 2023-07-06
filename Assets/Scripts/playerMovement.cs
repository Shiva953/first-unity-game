using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed=5f;
    [SerializeField] float jumpForce=7f;
    // Start is called before the first frame update
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource js;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("HELLO GAME DEV WORLD"); //logs before start of initial frame
    }

    // Update is called once per frame
    void Update()
    {
        float horzInput = Input.GetAxisRaw("Horizontal");
        float verInput = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(horzInput * movementSpeed,rb.velocity.y,verInput * movementSpeed); //takes care of up,down,left,right

        if(Input.GetButtonDown("Jump") && IsGrounded()){
            Jump();
        }
    }

    void Jump(){
        rb.velocity = new Vector3(rb.velocity.x,jumpForce,rb.velocity.z);
        js.Play();
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Enemy Head")){
            Destroy(collision.transform.parent.gameObject); //destroying the enemy object[parent of child EnemyHead]
        }
    }

    bool IsGrounded(){
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground); //checking for overlaps with the ground
        // if it collides with ground, true is returned
    } 
}