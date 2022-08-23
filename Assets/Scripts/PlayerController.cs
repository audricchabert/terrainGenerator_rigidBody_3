using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 inputs;
    //ref https://www.youtube.com/watch?v=wlZUu-I05Bk

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        AddForce();
    }

    void GetInputs()
    {
        float x = Input.GetAxis("Vertical");

        float y = Input.GetAxis("Horizontal");
        float z = 0;
        if (Input.GetButton("Jump"))
        {
            z = 1;
        }
        else
        {
            z = 0;
        }

        //Create the direction vector using hard coded variables?
        inputs = new Vector3(x * 4, y * 5, z * 10);

    }

    void AddForce()
    {
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(inputs.y, inputs.z, inputs.x));
    }
}
