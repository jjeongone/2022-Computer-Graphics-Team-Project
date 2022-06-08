using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lighting : MonoBehaviour
{
    public GameObject button;

    public void changeLighting(){
        Light l = gameObject.GetComponent<Light>();
        l.intensity = 0;
    }
}
