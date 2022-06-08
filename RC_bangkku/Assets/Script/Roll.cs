using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moverHorizontal, 0.0f, moverVertical);

        rigidbody.AddForce(movement);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
