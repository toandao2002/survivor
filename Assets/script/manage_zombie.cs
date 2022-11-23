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
    public List<GameObject> zombies = new List<GameObject>();
    public List<GameObject> prefab_zombie = new List<GameObject>();
    int type_spawn = 0;
    bool l_or_right = true;
    int id;
    Time time;
    public float seconds_Initialize_New_Zombie;
    private double preTime, fTime;
    private void Awake()
    {
        Instace = this;
    }
    void Start()
    {
        cam = control_camera.Instance.GetCamera();
        heightcam = 2f * cam.orthographicSize;
        widthcam = heightcam * cam.aspect;
        fTime = Time.time;
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
        if (Time.time < 50)
        {
            id = Random.Range(2, 4);
            type_spawn = Random.Range(0, 2);
        }
        else if (Time.time - fTime <= 100)
        {
            id = Random.Range(0, 4);
            type_spawn = Random.Range(0, 3);
        }

        else if (Time.time - fTime <= 130)
        {
            id = Random.Range(0, prefab_zombie.Count);
            type_spawn = Random.Range(0, 4);
        }
        else  
        {
            id = Random.Range(0, prefab_zombie.Count);
            type_spawn = Random.Range(0, 5);
        }
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
            else if (type_spawn == 2)
            {
                spawn_Many_zombie_folow_Both_side();
            }
            else if (type_spawn == 3)
            {
                spawn_zombie_follow_circle();
            }
            else if (type_spawn == 4)
            {
                spawn_Many_zombie_folow_Both_side();
                spawn_zombie_follow_circle();
            }
            preTime = Time.time;

        }

    }
    void spawn_single()
    {
        

        float x = 0;
        if (l_or_right)
        {
            l_or_right = !l_or_right;
            x = cam_pos.x + widthcam / 2;
        }
        else
        {
            l_or_right = !l_or_right;
            x = cam_pos.x - widthcam / 2;
        }
        float y = Random.Range(cam_pos.y - heightcam / 2, cam_pos.y + heightcam / 2);

        //zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y, 0), Quaternion.identity));
        GameObject zombie = ObjectPoolZombie.Instance.GetPooledObject(id);
        zombie.transform.position = new Vector3(x, y, 0);
        zombies.Add(zombie);
    }
    void spawn_3_zombie_folow_row()
    {
         
         
        float x = 0;

        if (l_or_right)
        {
            l_or_right = !l_or_right;
            x = cam_pos.x + widthcam / 2;
        }
        else
        {
            l_or_right = !l_or_right;
            x = cam_pos.x - widthcam / 2;
        }
        float y = Random.Range(cam_pos.y - heightcam / 2, cam_pos.y + heightcam / 2);

       // zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y, 0), Quaternion.identity));
        GameObject zombie = ObjectPoolZombie.Instance.GetPooledObject(id);
        zombie.transform.position = new Vector3(x, y, 0);
        zombies.Add(zombie);

        //zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x + 1, y + 1, 0), Quaternion.identity));
        zombie = ObjectPoolZombie.Instance.GetPooledObject(id);
        zombie.transform.position = new Vector3(x + 1, y + 1, 0);
        zombies.Add(zombie);


        //zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x + 2, y + 2, 0), Quaternion.identity));
        zombie = ObjectPoolZombie.Instance.GetPooledObject(id);
        zombie.transform.position = new Vector3(x + 2, y + 2, 0);
        zombies.Add(zombie);

    }
    void spawn_Many_zombie_folow_Both_side()
    {
         
        float x = 0;

        x = cam_pos.x + widthcam / 2;

        float y = cam_pos.y;
        GameObject zombie;
        float tmp =0.5f;
        for (int i = 0; i <6; i++)
        {
            zombie = ObjectPoolZombie.Instance.GetPooledObject(id);
            zombie.transform.position = new Vector3(x, y + tmp , 0);
            zombies.Add(zombie);
            zombie = ObjectPoolZombie.Instance.GetPooledObject(id);
            zombie.transform.position = new Vector3(x, y - tmp, 0);
            zombies.Add(zombie);
            tmp += 0.5f;
        }

        
        x = cam_pos.x - widthcam / 2;
        tmp = 0.5f;
        for (int i = 0; i < 6; i++)
        {
            zombie = ObjectPoolZombie.Instance.GetPooledObject(id);
            zombie.transform.position = new Vector3(x, y + tmp, 0);
            zombies.Add(zombie);
            zombie = ObjectPoolZombie.Instance.GetPooledObject(id);
            zombie.transform.position = new Vector3(x, y - tmp, 0);
            zombies.Add(zombie);
            tmp += 0.5f;
        }
/*        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y + 0.5f, 0), Quaternion.identity));
        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y - 0.5f, 0), Quaternion.identity));
        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y + 1, 0), Quaternion.identity));
        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y - 1, 0), Quaternion.identity));
        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y + 1.5f, 0), Quaternion.identity));
        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y - 1.5f, 0), Quaternion.identity));
        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y + 2, 0), Quaternion.identity));
        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y - 2, 0), Quaternion.identity));
        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y + 2.5f, 0), Quaternion.identity));
        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y - 2.5f, 0), Quaternion.identity));
        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y + 3f, 0), Quaternion.identity));
        zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, y - 3f, 0), Quaternion.identity));*/

    }
    void spawn_zombie_follow_circle()
    {
        
        float x = cam_pos.x;
        int dir = 1;
        if (character.Instance.joystick.Vertical > 0)
        {
            dir = 1;
        }
        else dir = -1;
        float y = cam_pos.y;
        int radius = (int)heightcam / 2;
        Vector3 pos_main = character.Instance.get_position();
        GameObject zombie;
        for (int i = -5; i <= 5; i++)
        {   

            x = i + pos_main.x;
            int tmp = radius * radius - (int)Mathf.Pow(x - pos_main.x, 2);
            if (tmp <= 0|| i == 0 ) continue;
            //zombies.Add(Instantiate(prefab_zombie[id], new Vector3(x, dir * Mathf.Sqrt(tmp) + pos_main.y, 0), Quaternion.identity));
            zombie = ObjectPoolZombie.Instance.GetPooledObject(id);
            zombie.transform.position = new Vector3(x, dir * Mathf.Sqrt(tmp) + pos_main.y, 0);
            zombies.Add(zombie);
        }
    }
    private void OnDisable()
    {
        foreach (GameObject zombie in zombies)
        {
            if (zombie != null)
                zombie.GetComponent<ZombieCommon>().enabled = false;
        }


    }
    public void RemoveZombie(GameObject zom)
    {
        foreach (GameObject zb in zombies)
        {
            if (zb == zom)
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
