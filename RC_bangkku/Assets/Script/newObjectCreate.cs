using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class newObjectCreate : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.clip = Resources.Load("Audio/button-17") as AudioClip;
    }

    void OnMouseDown()
    {
        Rigidbody rigidbody;
        int[,] arr = new int [8, 2]{{1, -1}, {1, 0}, {1, 1}, {0, -1}, {0, 1}, {-1, -1}, {-1, 0}, {-1, 1}};
        float[] box_pos = {boxParent.box.transform.position.x, boxParent.box.transform.position.z};
        if (boxParent.idx == 8){
            boxParent.idx = 0;
        }

        if (boxParent.select_num == boxParent.OBJECT_NUM){
            return;
        }
        Debug.Log(boxParent.idx);
        int[] obj_pos = {arr[boxParent.idx,0], arr[boxParent.idx,1]};
        int x = (int)Mathf.Round((obj_pos[0] * 100 + box_pos[0]) / 100) * 100;
        int z = (int)Mathf.Round((obj_pos[1] * 100 + box_pos[1]) / 100) * 100;
        GameObject newObj = Instantiate (boxParent.objs[boxParent.select_num], new Vector3(x , 200, z), Quaternion.identity);
        //GameObject newObj = Instantiate (obj, new Vector3(800, 200, -400), Quaternion.identity);
        newObj.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
        boxParent.posArray[obj_pos[0] + 1, obj_pos[1] + 1] = 1;
        boxParent.select_num++;
        boxParent.idx++;
        newObj.AddComponent<Drag>();
        newObj.AddComponent<Rotate>();
        newObj.AddComponent<BoxCollider>();
        rigidbody = newObj.AddComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        audioSource.Play();
    }
}
