using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    void OnMouseDrag()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            transform.Rotate(0, 10, 0, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            transform.Rotate(0, -10, 0, Space.World); 
        }
    }
}
