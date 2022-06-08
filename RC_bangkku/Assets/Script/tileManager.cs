using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    
    public GameObject _tilePrefab;
    public GameObject _tilePrefabOff;

    public static bool is_drag = false;

    private Dictionary<Vector2, GameObject> objDict = new Dictionary<Vector2, GameObject>();
    public static Vector2 emp = new Vector2(-1, -1);
    


    void Start() {
        generateGrid();
    }

    void generateGrid(){
        int x_init;
        int x_fin;
        for (int z = 0; z < 33; z++){
            GameObject pre;
            if (z < 16){
                x_init = 500 - 50 * z; 
                x_fin = 500 + 50 * z;
            }
            else {
                x_init = -300 + 50 * (z - 16);
                x_fin = 1300 - 50 * (z - 16);
            }
            for (int x = x_init ; x <= x_fin; x  += 100){
                pre = z % 2 == 0 ? _tilePrefab : _tilePrefabOff;
                int x_pos = x + 460;
                int z_pos = z * 50 + 375;
                GameObject newObj = Instantiate(pre, new Vector3(x_pos, 50 , z_pos), Quaternion.identity);
                newObj.transform.localScale = new Vector3(50.0f * Mathf.Sqrt(2), 1.0f, 50.0f * Mathf.Sqrt(2));
                newObj.name = $"Tile {x_pos} {z_pos}";
                newObj.transform.eulerAngles = new Vector3(0, 45.0f ,0);
                objDict.Add(new Vector2(x_pos, z_pos) , newObj);
            }
        }
    }

    void Update(){
        foreach (Vector2 v in objDict.Keys){
            objDict[v].SetActive(is_drag);
            Renderer r = objDict[v].GetComponent<Renderer>();
            Color c = r.material.color;
            if (v == emp){
                c.a = 150.0f / 255.0f;
                r.material.color = c;
            }
            else{
                c.a = 80.0f / 255.0f;
                r.material.color = c;
            }

        }
    }
}
