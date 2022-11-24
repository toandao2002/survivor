using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDown : MonoBehaviour
{
    // Start is called before the first frame update
     float Speed =2;
    public float angle = 45;
    public float scale = 1;
    void Start()
    {
        Speed = Random.Range(0f, 2f) + 2;
         
    }
    private void OnDisable()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {   
        if (scale <= 0) Destroy(this.gameObject);
         
        transform.position = transform.position - new Vector3 (0,Speed ,0);
        transform.GetChild(0).localRotation = Quaternion.Euler(0, 0, angle);
        transform.GetChild(0).localScale = new Vector3(scale, scale, scale);
        scale -= 0.0015f;
        if (Speed >= 3.5) angle += 0.4f;
        else 
            angle -= 0.4f;
    }
}
