using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletZuantoudan : ShootBullet
{   
    public int  dame = 10   ;
    public float speed=0.03f;
    public int time_destroy =4;
    Vector3 camera_pos, dir ;
    public long timeInitBullet = 2;
    float preTime = 0 , width , height ;
    Camera cam;
    public override int GetDame()
    {
        return dame; 
    }

    public override void SetDame(int value)
    {
        dame = value; 
    }

    public override void shoot()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        dir = new Vector3(x, y, 0);
        dir.Normalize();
        preTime = Time.time;

        cam = control_camera.Instance.GetCamera();
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Time.time -preTime>= time_destroy) Destroy(gameObject);
        move();
    }
    void move()
    {
        camera_pos = control_camera.Instance.get_position();
        
        if (transform.position.x > camera_pos.x + width / 2)
        {
            dir.x = -1;
        }
        else if (transform.position.x < camera_pos.x - width / 2)
        {
            dir.x = 1;
        }
        if (transform.position.y > camera_pos.y + height / 2)
        {
            dir.y = -1;
        }
        else if (transform.position.y < camera_pos.y - height / 2)
        {
            dir.y = 1;
        }

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float angle2 = Vector2.Angle(dir, Vector2.up);
        if (dir.x > 0) angle2 *= -1;

        transform.Translate(dir * speed * Time.deltaTime);
        transform.GetChild(0).localRotation = Quaternion.Euler(0, 0, angle2);
    }
}
