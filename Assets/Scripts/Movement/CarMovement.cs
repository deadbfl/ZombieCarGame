using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float mass; // mass : kutle demek
    [SerializeField] private float speed;
    [SerializeField] private Vector3 force; // force : kuvvet demek

    private Vector3 acceleration;
    private Vector3 movementVector;
    private Vector3 rotateVector;

    private bool forward = true;
    private bool backward = true;
    private bool left = true;
    private bool right = true;

    public void OnForward(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            forward = true;
            StartCoroutine(AddForceForward());
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            forward = false;
        }
    }
    public void OnBackward(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            backward = true;
            StartCoroutine(AddForceBackward());
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            backward = false;
        }
    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            left = true;
            StartCoroutine(RotateLeft());
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            left = false;
        }
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            right = true;
            StartCoroutine(RotateRight());
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            right = false;
        }
    }

    private IEnumerator AddForceForward()
    {
        while (true)
        {
            if (!forward) yield break;

            AddForce(force);
            yield return null;
        }
    }

    private IEnumerator AddForceBackward()
    {
        while (true)
        {
            if (!backward) yield break;

            AddForce(-force * 2);
            yield return null;
        }
    }

    private IEnumerator RotateLeft()
    {
        while (true)
        {
            if (!left)
            {
                rotateVector = Vector3.zero; yield break;
            }

            rotateVector = new Vector3(0, -120, 0);

            yield return null;
        }
    }
    private IEnumerator RotateRight()
    {
        while (true)
        {
            if (!right)
            {
                rotateVector = Vector3.zero; yield break;
            }

            rotateVector = new Vector3(0, 120, 0);

            yield return null;
        }
    }
    public void AddForce(Vector3 m_forceVector)
    {
        acceleration = m_forceVector / mass;
        movementVector += acceleration;
        acceleration = Vector3.zero;
    }

    private void FixedUpdate()
    {
        transform.position += movementVector.z * speed * Time.deltaTime * transform.forward;

        transform.Rotate(rotateVector * Time.deltaTime);

        float moveZ = movementVector.z;

        moveZ = Mathf.Abs(moveZ);

        if(moveZ > 0)
        {
            float difference = movementVector.z - 0;

            movementVector.z -= difference*Time.deltaTime/3;
        }
    }
}
