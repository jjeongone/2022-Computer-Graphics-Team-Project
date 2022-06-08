using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButton : MonoBehaviour
{
    public Component Script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLight()
    {
        Debug.Log("Click Light");
    }

    public void OnClickMusic()
    {
        Debug.Log("Click Music");
    }

    // public void OnClickPixel()
    // {
    //     GameObject.Find("Main Camera").GetComponent<Pixelation>().enabled = false;
    //     Debug.Log("Click Pixelation");
    // }
}
