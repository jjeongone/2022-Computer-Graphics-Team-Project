using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxParent : MonoBehaviour
{
    public const int OBJECT_NUM = 10;

    public GameObject[] objs_parent;
    public GameObject box_parent;
    public static GameObject[] objs;
    public static GameObject box;
    public static int idx = 0;
    // x축 앞에 +5 ~ -2
    // z축 앞에 +6 ~ -6
    public static int select_num = 0;
    public static int[,] posArray = new int [8, 13];

    private void Start() {
        for (int i = 0; i < 1000; i++){
            int j = Random.Range(0, OBJECT_NUM);
            int r = Random.Range(0, OBJECT_NUM);
            Debug.Log(j);
            Debug.Log(r);
            GameObject temp = objs_parent[j];
            objs_parent[j] = objs_parent[r];
            objs_parent[r] = temp;
        }

        SceneManager.sceneLoaded += LoadedsceneEvent;

        objs = objs_parent;
        box = box_parent;
        
    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode){
        select_num = 0;
        idx = 0;
    }
}
