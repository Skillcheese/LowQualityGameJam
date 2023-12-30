using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1;
    [SerializeField]
    private float damping = .05f;
    private Vector3 Velocity;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        Vector3 vec = Vector3.zero;
        bool w = Input.GetKey(KeyCode.W);
        bool s = Input.GetKey(KeyCode.S);
        bool a = Input.GetKey(KeyCode.A);
        bool d = Input.GetKey(KeyCode.D);
        bool space = Input.GetKey(KeyCode.Space);
        bool shift = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.C);
        if (w)
        {
            vec += transform.forward * movementSpeed;
        }
        if(s)
        {
            vec -= transform.forward * movementSpeed;
        }
        if(d)
        {
            vec += transform.right * movementSpeed;
        }
        if(a)
        {
            vec -= transform.right * movementSpeed;
        }
        if (space)
        {
            vec += transform.up * movementSpeed;
        }
        if (shift)
        {
            vec -= transform.up * movementSpeed;
        }
        if(Input.GetKeyDown(KeyCode.F1))
        {
            if(!Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState &= ~CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        Vector3 damp = damping * Time.deltaTime * Velocity; //Damping
        if (damp.magnitude >= Velocity.magnitude) Velocity = Vector3.zero;
        else Velocity -= damp;
        Velocity += vec * Time.deltaTime; //Acceleration
        transform.position += Velocity * Time.deltaTime; //Velocity
    }
}
