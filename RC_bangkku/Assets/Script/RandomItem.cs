using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    private GameObject prefab;

    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        prefab = Resources.Load<GameObject>("Model/book");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBox()
    {
        obj = Instantiate(prefab);
        Debug.Log("Click Box");
    }
}
