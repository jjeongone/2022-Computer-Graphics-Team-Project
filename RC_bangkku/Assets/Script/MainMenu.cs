using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnClickNewGame()
    {
        SceneManager.LoadScene("Room1");
        Debug.Log("New Game");
    }

    public void OnClickOption()
    {
        SceneManager.LoadScene("About");
        Debug.Log("About");
    }

    public void OnClickTitle()
    {
        SceneManager.LoadScene("Title");
        Debug.Log("Back to Title");
    }

    public void OnClickQuit()
    {
        Debug.Log("Quit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
