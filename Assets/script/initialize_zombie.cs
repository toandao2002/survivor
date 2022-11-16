using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialize_zombie : MonoBehaviour
{
    // Start is called before the first frame update
    float widthcam, heightcam;
    Camera cam;
    Vector3 cam_pos;

    public GameObject zombie;
    Time time;
    public float seconds_Initialize_New_Zombie;
    private double preTime ;
    void Start()
    {
        cam = control_camera.Instance.GetCamera();
        heightcam = 2f * cam.orthographicSize;
        widthcam = heightcam * cam.aspect;
        
        preTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        cam_pos = control_camera.Instance.get_position();



        if (Time.realtimeSinceStartup-preTime > seconds_Initialize_New_Zombie)
        {
            float x = Random.Range(cam_pos.x - widthcam / 2 , cam_pos.x + widthcam / 2 );
            float y = Random.Range(cam_pos.y - heightcam / 2  , cam_pos.y + heightcam /2 );
             
            Instantiate(zombie, new Vector3(x, y, 0), Quaternion.identity);
            preTime = Time.realtimeSinceStartup;
            
        }
         
    }
     
}
