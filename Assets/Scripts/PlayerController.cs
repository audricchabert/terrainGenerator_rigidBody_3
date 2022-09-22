using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 inputs;
    //ref https://www.youtube.com/watch?v=wlZUu-I05Bk


    float terrainBoundaryMinXFloat = 20;
    float terrainBoundaryMaxXFloat = 230;
    float terrainBoundaryMinYFloat = 0;
    float terrainBoundaryMaxYFloat = 100;
    float terrainBoundaryMinZFloat = 20;
    float terrainBoundaryMaxZFloat = 230;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        AddForce();
        CheckBoundaries();
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

    void CheckBoundaries()
    {
        float xPosition = Mathf.Clamp(transform.position.x, terrainBoundaryMinXFloat, terrainBoundaryMaxXFloat);
        float yPosition = Mathf.Clamp(transform.position.y, terrainBoundaryMinYFloat, terrainBoundaryMaxYFloat);
        float zPosition = Mathf.Clamp(transform.position.z, terrainBoundaryMinZFloat, terrainBoundaryMaxZFloat);

        transform.position = new Vector3(xPosition, yPosition, zPosition);

        //Todo : remove the relativeForce when colliding with the boundaries, so that the player doesn't get "stuck" to the boundary because the force continues to push him against it
        //Todo : add a vector arrow to display the current force, use the tutorial video with the angle of attack (probably a playerController video)
    }
}
