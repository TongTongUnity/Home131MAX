using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    //[RequireComponent(typeof(ThirdPersonCharacter))]
    public class EasyTouchControl : MonoBehaviour
    {
        private StarterAssetsInputs m_Inputs; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        //private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.


        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Inputs = GetComponent<StarterAssetsInputs>();
        }


        //private void Update()
        //{
        //    var x = ETCInput.GetAxis("Mouse X");
        //    var y = ETCInput.GetAxis("Mouse Y");
        //    if (x == 0 && y == 0)
        //    {
        //        return;
        //    }
        //    m_Inputs.look = new Vector2(x, y);
        //}


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            // read inputs
            float h = ETCInput.GetAxis("Horizontal");
            float v = ETCInput.GetAxis("Vertical");
            //bool crouch = Input.GetKey(KeyCode.C);

            // calculate move direction to pass to character


            // pass all parameters to the character control script
            m_Inputs.move = new Vector2(h, v); ;
            //m_Jump = false;
        }
    }
}

