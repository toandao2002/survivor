using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    Animator anim;
    const int IDLE = 0;
    const int WALK = 1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(joystick.Horizontal, joystick.Vertical) * speed * Time.deltaTime);
    }
    public void run()
    {
         
        anim.SetInteger("state", WALK);
    }
    public void idle()
    {
       
        anim.SetInteger("state", IDLE);
    }
}
