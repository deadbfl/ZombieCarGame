using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float gravity;

    private void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);

        transform.position -= new Vector3(0, gravity*Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
