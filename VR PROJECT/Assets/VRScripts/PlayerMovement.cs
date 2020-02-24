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
    public float gravity = -9.81f;
    [SerializeField]private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dirction = Player.instance.hmdTransform.TransformDirection(new Vector3(movement.axis.x, 0, movement.axis.y));
        characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(dirction, Vector3.up) + new Vector3(0, gravity, 0) * Time.deltaTime);

        if (jump.state == true && isJumping == false)
        {
            isJumping = true;
            gravity = -gravity;
            StartCoroutine(Jumping());
        }
    }

    IEnumerator Jumping()
    {
        yield return new WaitForSeconds(0.3f);
        gravity = -gravity;
    }


}
