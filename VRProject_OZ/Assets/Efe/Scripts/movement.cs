using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
        CharacterController characterController;

        public float speed = 26.0f;
        public float jumpSpeed = 8.0f;
        public float gravity = 20.0f;

        private Vector3 moveDirection = Vector3.zero;

        void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            //if (characterController.isGrounded)
            //{
                // We are grounded, so recalculate
                // move direction directly from axes

                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
                moveDirection *= speed;
        

                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                }
            //}

            // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
            // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
            // as an acceleration (ms^-2)
            //moveDirection.y -= gravity * Time.deltaTime;

            // Move the controller
            characterController.Move(moveDirection * Time.deltaTime);


        // rotate
        //// Rotation
        //float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = Input.GetAxis("Mouse Y");
        //Vector3 rotation = new Vector3(mouseX, 0, mouseY);
        //transform.RotateAround(Vector3.zero, transform.up, mouseX * 4);
        ////rigid.AddExplosionForce(5, torquePos.transform.position, 2);
        float h = 4 * Input.GetAxis("Mouse X");
        //float v = 4 * Input.GetAxis("Mouse Y");
        transform.Rotate(0, h, 0);
    }
}

