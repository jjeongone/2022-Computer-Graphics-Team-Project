using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float rotateSpeed = 10.0f;
    public float zoomSpeed = 10.0f;
    public float movementSpeed = 5f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }
    
    void Update()
    {
        Zoom();
        Rotate();
        ChangeProjection();
        Move();
    }

    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if(distance != 0 && mainCamera.orthographic != true)
        {
            mainCamera.fieldOfView += distance;
        }
        else if (distance != 0 && mainCamera.orthographic == true)
        {
            mainCamera.orthographicSize += distance * 10;
        }
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(2))
        {
             Vector3 rot = transform.rotation.eulerAngles;           // Euler angle representation of camera orientation
            rot.y += Input.GetAxis("Mouse X") * rotateSpeed;        // Mouse X position * rotate speed
            rot.x += -1 * Input.GetAxis("Mouse Y") * rotateSpeed;   // Mouse Y position * rotate speed
            Quaternion q = Quaternion.Euler(rot);                   // Euler angle to quaternion
            q.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f);
        }
    }

    private void ChangeProjection()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            mainCamera.orthographic = !mainCamera.orthographic;
        }
    }

    private void Move()
    {
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");

        if (mainCamera != null)
        {
            mainCamera.transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue));
        }
    }

    public void TopView()
    {
        Debug.Log("Top");
        mainCamera.orthographic = true;
        Vector3 trans = transform.position;
        trans.x = 1000f;
        trans.y = 500f;
        trans.z = 1200f;
        transform.position = Vector3.Lerp(transform.position, trans, 2f);
        //mainCamera.transform.translation = new Vector3(-150f, 300f, 100f);
        Vector3 rot = transform.rotation.eulerAngles;           // Euler angle representation of camera orientation
        rot.y = 45;
        rot.x = 90;   
        rot.z = 0;   
        Quaternion q = Quaternion.Euler(rot);                   // Euler angle to quaternion
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f);
        mainCamera.orthographicSize = 650;
    }

    public void FrontView()
    {
        Debug.Log("Front");
        mainCamera.orthographic = true;
        Vector3 trans = transform.position;
        trans.x = -150f;
        trans.y = 300f;
        trans.z = 100f;
        transform.position = Vector3.Lerp(transform.position, trans, 2f);
        //mainCamera.transform.translation = new Vector3(-150f, 300f, 100f);
        Vector3 rot = transform.rotation.eulerAngles;           // Euler angle representation of camera orientation
        rot.y = 45;
        rot.x = 0;   
        rot.z = 0;   
        Quaternion q = Quaternion.Euler(rot);                   // Euler angle to quaternion
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f);
        mainCamera.orthographicSize = 350;
    }

    public void RightView()
    {
        Debug.Log("Right");
        mainCamera.orthographic = true;
        Vector3 trans = transform.position;
        trans.x = 1900f;
        trans.y = 300f;
        trans.z = 260f;
        transform.position = Vector3.Lerp(transform.position, trans, 2f);
        //mainCamera.transform.translation = new Vector3(-150f, 300f, 100f);
        Vector3 rot = transform.rotation.eulerAngles;           // Euler angle representation of camera orientation
        rot.y = -45;
        rot.x = 0;   
        rot.z = 0;   
        Quaternion q = Quaternion.Euler(rot);                   // Euler angle to quaternion
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 2f);
        mainCamera.orthographicSize = 350;
    }
}