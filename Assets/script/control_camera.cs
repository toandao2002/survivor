using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_camera : MonoBehaviour
{   
    public static control_camera Instance { get; private set; }
    Camera cam;
    public 
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        cam = GetComponent<Camera>(); 
    }
    public Vector3 get_position()
    {
        return transform.position; 
    }
    public Camera GetCamera()
    {
        return cam;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
