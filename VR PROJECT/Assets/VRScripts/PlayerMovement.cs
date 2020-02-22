using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerMovement : MonoBehaviour
{
    public SteamVR_Action_Vector2 movement;
    public SteamVR_Action_Boolean jump = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Jump");
    public bool isJumping = false;
    public float speed = 2;
    public float jumpspeed = 0;
    [SerializeField]private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dirction = Player.instance.hmdTransform.TransformDirection(new Vector3(movement.axis.x, 0, movement.axis.y));
        characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(dirction, Vector3.up) - new Vector3(0, jumpspeed -9.81f, 0) * Time.deltaTime);
        Debug.Log(jump.state);

        if (jump.state == true & isJumping == false)
        {
            isJumping = true;
            Jumping();
        }
    }

    void Jumping()
    {
        while (characterController.isGrounded == false && jumpspeed <=  10f)
        {
            jumpspeed = 9.81f * Time.deltaTime + jumpspeed;
        }
        jumpspeed = 0;
    }


}
