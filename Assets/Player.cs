using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public Vector3 point;

    //private Matrix4x4 local;
    //private Vector3 global;
    //private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0, 0, 0);
        //rigidBody = GetComponent<Rigidbody>();
        //local = Matrix4x4.Scale(rigidBody.inertiaTensor);
        //global = local * rigidBody.angularVelocity * 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        CalculateRotate();

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * Time.deltaTime * 5f);

    }

    void CalculateRotate()
    {
        point = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(point, new Vector3(0, 0, 1), 20 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(point, new Vector3(0, 0, -1), 20 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(point, new Vector3(1, 0, 0), 20 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(point, new Vector3(-1, 0, 0), 20 * Time.deltaTime);
        }

    }


}
