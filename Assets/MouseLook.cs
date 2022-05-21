using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GAMEZONE
{
    public class MouseLook : MonoBehaviour
    {
        private float mouseX;
        private float mouseY;

        public float mouseSensitivity = 100f;
        public Transform playerBody;



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}

