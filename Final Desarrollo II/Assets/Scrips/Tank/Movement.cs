using UnityEngine;

namespace Game
{

    public class Movement : MonoBehaviour
    {
        [SerializeField] float velocityY;
        [SerializeField] float velocityX;

        Rigidbody RB;

        void Awake()
        {
            RB = GetComponent<Rigidbody>();
        }


        void FixedUpdate()
        {

            if (Input.GetKey(KeyCode.W))
            {
                RB.AddForce(transform.forward * velocityY, ForceMode.Force);
            }

            if (Input.GetKey(KeyCode.S))
            {
                RB.AddForce(-transform.forward * velocityY);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.eulerAngles += Vector3.down * velocityX * Time.deltaTime;

                // RB.MoveRotation(transform.rotation * Quaternion.Euler(Vector3.down * velocityX));
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles += Vector3.up * velocityX * Time.deltaTime;

                // RB.MoveRotation(transform.rotation * Quaternion.Euler(Vector3.up * velocityX));
            }

        }
    }

}