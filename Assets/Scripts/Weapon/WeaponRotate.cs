using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class WeaponRotate : MonoBehaviour
{

    public RotateVariables body;
    public RotateVariables weapon;


    public void OnMouseInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Vector2 mouseInput = context.ReadValue<Vector2>();

            body.rotateObject.Rotate(0, mouseInput.x * body.rotationSpeed * Time.deltaTime, 0); // body rotate alani

            //if (body.rotateObject.eulerAngles.y < body.rotateLimit.x && body.rotateObject.eulerAngles.y > 180)
            //    body.rotateObject.transform.eulerAngles = new Vector3(0, body.rotateLimit.x, 0);
            //else if (body.rotateObject.eulerAngles.y > body.rotateLimit.y && body.rotateObject.eulerAngles.y < 180)
            //    body.rotateObject.transform.eulerAngles = new Vector3(0, body.rotateLimit.y, 0);

            weapon.rotateObject.Rotate(-mouseInput.y * weapon.rotationSpeed * Time.deltaTime, 0, 0);// weapon rotate alani

            if (weapon.rotateObject.eulerAngles.x < weapon.rotateLimit.x && weapon.rotateObject.eulerAngles.x > 180)
                weapon.rotateObject.transform.eulerAngles = new Vector3(weapon.rotateLimit.x, weapon.rotateObject.transform.eulerAngles.y, weapon.rotateObject.transform.eulerAngles.z);
            else if(weapon.rotateObject.eulerAngles.x > weapon.rotateLimit.y && weapon.rotateObject.eulerAngles.x < 180)
                weapon.rotateObject.transform.eulerAngles = new Vector3(weapon.rotateLimit.y, weapon.rotateObject.transform.eulerAngles.y, weapon.rotateObject.transform.eulerAngles.z);

        }
    }
}

[Serializable]
public struct RotateVariables
{
    public Transform rotateObject;

    public Vector2 rotateLimit;// -30, 30

    public float rotationSpeed;
}

