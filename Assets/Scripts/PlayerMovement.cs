using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody>().velocity = new Vector3(inputX * speed, 0, 0);
    }
}
