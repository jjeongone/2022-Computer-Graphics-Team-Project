using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.clip = Resources.Load("Audio/button-50") as AudioClip;
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        audioSource.Play();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag() {
        tileManager.is_drag = true;
        Vector3 tmp = GetMouseWorldPos() + mOffset;
        tmp.z = tmp.z + tmp.y;
        
        int x = (int)Mathf.Round((tmp.x - 60) / 50) * 50 + 60;

        int is_divided = (x % 100 == 60) ? 75 : 25;

        int z = (int)Mathf.Round((tmp.z - is_divided) / 100) * 100 + is_divided;
        
        tileManager.emp = new Vector2(x, z);

        Vector3 pos = new Vector3(x, Mathf.Max(Mathf.Min(tmp.y, 200), 100), z);
        transform.position = pos;
    }

    private void OnMouseUp() {
        Debug.Log(tileManager.emp);
        tileManager.emp = new Vector2(-1, -1);
        tileManager.is_drag = false;

    }
}
