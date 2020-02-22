using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float Speed = 5.0F;
    float JHeight = 0.7f;
    public LayerMask PhysicalLayer;
    private Rigidbody rb;
    private bool grounded;
    public float timeVar;
    public CapsuleCollider col;

    //new bool check if mouse visible
    private bool mouseVisible = false;
    // Start is called before the first frame update
    void Start()
    {
        //hide the cursor on start
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        timeVar = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //get WASD/Arrow key movement inputs
        float translation = Input.GetAxis("Vertical") * Speed;
        float strafe = Input.GetAxis("Horizontal") * Speed;
        translation *= (Time.deltaTime * timeVar);
        strafe *= (Time.deltaTime * timeVar);

        //apply movements to the character
        transform.Translate(strafe, 0, translation);

        //jumping
        if (IsGrounded() && Input.GetKey(KeyCode.Space))
        {

            rb.AddForce(new Vector3(0, JHeight, 0), ForceMode.Impulse);

        }
        //make the mouse visible on pause
        if (Input.GetKeyDown("escape"))
        {
           
                Cursor.lockState = CursorLockMode.None;
                mouseVisible = true;
        }


    }




    //Check if the character is not in the air
    private bool IsGrounded()   
    {
       
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * 0.9f, PhysicalLayer);
    }
  

}
