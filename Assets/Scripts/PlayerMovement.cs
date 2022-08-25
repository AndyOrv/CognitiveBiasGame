using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GAMEZONE
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;
        public Transform groundCheck;
        public float groundDis = 0.4f;
        public float speed = 12f;
        public LayerMask groundMask;
        public float jumpHeight = 3f;

        private float x;
        private float z;
        private Vector3 move;
        private bool isGrounded;


        private Vector3 velocity;
        public float gravity = -9.81f;


        // Update is called once per frame
        void Update()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDis, groundMask);

            if(isGrounded && velocity.y < 0){velocity.y = -2f;}

            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);


           if(Input.GetButtonDown("Jump") && isGrounded){
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
           }

            velocity.y += gravity;

            controller.Move(velocity * Time.deltaTime);
        }
    
    }
}

