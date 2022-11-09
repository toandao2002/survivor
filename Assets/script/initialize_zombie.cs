using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialize_zombie : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zombie;
    Time time;
    public int seconds_Initialize_New_Zombie;
    private double preTime ;
    void Start()
    {
        preTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup-preTime > seconds_Initialize_New_Zombie)
        {
            float x = Random.Range(-5, 6);
            float y = Random.Range(-9, 9);
             
            Instantiate(zombie, new Vector3(x, y, 0), Quaternion.identity);
            preTime = Time.realtimeSinceStartup;
            
        }
    }
     
}
