using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manage_zombie : MonoBehaviour
{
    // Start is called before the first frame update
    public static manage_zombie Instace;
    
    float widthcam, heightcam;
    Camera cam;
    Vector3 cam_pos;
    public List<GameObject> zombies = new List<GameObject> ();
    public List<GameObject> prefab_zombie = new List<GameObject>();
    int type_spawn = 0;
    bool l_or_right= true;
    Time time;
    public float seconds_Initialize_New_Zombie;
    private double preTime ;
    private void Awake()
    {
        Instace = this; 
    }
    void Start()
    {
        cam = control_camera.Instance.GetCamera();
        heightcam = 2f * cam.orthographicSize;
        widthcam = heightcam * cam.aspect;
        
        preTime = Time.time;
    }
     
    // Update is called once per frame
    void Update()
    {
       // if (character.Instance.blood <= 0) Time.timeScale = 0f;
        cam_pos = control_camera.Instance.get_position();
        seconds_Initialize_New_Zombie -= 0.00001f;
        if (seconds_Initialize_New_Zombie <= 0.5)
        {
            seconds_Initialize_New_Zombie += 0.00001f;
        }
      
        type_spawn = Random.Range(0,2);
        if (Time.time - preTime > seconds_Initialize_New_Zombie)
        {
            if (type_spawn == 0)
            {
                spawn_single();
            }
            else if (type_spawn == 1)
            {
                spawn_3_zombie_folow_row();
            }
            preTime = Time.time;
            
        }
         
    }
    void spawn_single()
    {
        int id = Random.Range(0, prefab_zombie.Count);

        float x = 0;
        if (l_or_right)
        {
            l_or_right = !l_or_right;
            x = cam_pos.x + widthcam / 2;
        }
        else
        {
            l_or_right = !l_or_right;
            x = x = cam_pos.x - widthcam / 2;
        }
        float y = Random.Range(cam_pos.y - heightcam / 2, cam_pos.y + heightcam / 2);

        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y, 0), Quaternion.identity));

    }
    void spawn_3_zombie_folow_row ()
    {
        int id = Random.Range(0, prefab_zombie.Count);
        float x = 0;
        if (l_or_right)
        {
            l_or_right = !l_or_right;
            x = cam_pos.x + widthcam / 2;
        }
        else {
            l_or_right = !l_or_right;
            x = x = cam_pos.x - widthcam / 2 ;
        }
        float y = Random.Range(cam_pos.y - heightcam / 2, cam_pos.y + heightcam / 2);

        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y, 0), Quaternion.identity));
        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x+1, y+1, 0), Quaternion.identity));
        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x+2, y+2, 0), Quaternion.identity));

    }
    private void OnDisable()
    {
        foreach (GameObject zombie in zombies)
        {
            if (zombie != null)
                zombie.GetComponent<ZombieCommon>().enabled = false;
        }


    }
    public void RemoveZombie (GameObject zom)
    {
        foreach ( GameObject zb in zombies)
        {
            if (zb == zom )
            {
                zombies.Remove(zb);
                return; 
            }
        }
    }
    private void OnEnable()
    {
        foreach (GameObject zombie in zombies)
        {
            zombie.GetComponent<ZombieCommon>().enabled = true;
        }
    }
}
