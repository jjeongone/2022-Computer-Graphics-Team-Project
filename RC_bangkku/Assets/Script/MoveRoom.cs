using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveRoom : MonoBehaviour
{
    private Scene scene;
    private Button button;
    private int num;
    private int minNum = 1;
    private int maxNum = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        num = Convert.ToInt32(scene.name.Split("Room")[1]);
        
        if(num == minNum)
        {   
            button = GameObject.Find("Left Button").GetComponent<Button>();
            button.interactable = false;
        }

        if(num == maxNum)
        {   
            button = GameObject.Find("Right Button").GetComponent<Button>();
            button.interactable = false;
        }
        

        Debug.Log("Scene Name: " + scene.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLeftButton()
    {
        SceneManager.LoadScene("Room" + (num - 1));
        Debug.Log("Click Left");        
    }

    public void OnClickRightButton()
    {
        SceneManager.LoadScene("Room" + (num + 1));
        Debug.Log("Click Right");
    }
}
