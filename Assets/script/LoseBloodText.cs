using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseBloodText : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0)* speed * Time.deltaTime);
    }
}
