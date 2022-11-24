using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectDropbox : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> Box_Images;
    public Image img_box;
    public float speed, timeInit;
    int id=0;
    float pre_Time;
    Vector3 pos;
    float x, y;
    void Start()
    {
        pre_Time = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.realtimeSinceStartup - pre_Time > timeInit)
        {
            for (int i =0; i <=16; i++)
            {
                id = Random.Range(0, Box_Images.Count);
                Image tmp = Instantiate(img_box, new Vector3(Random.Range(0, 1000), img_box.transform.position.y, 0), Quaternion.identity);

                tmp.transform.gameObject.AddComponent<DropDown>();
                tmp.transform.GetChild(0).GetComponent<Image>().sprite = Box_Images[id];
                tmp.transform.SetParent(this.transform);
            }
            
            pre_Time = Time.realtimeSinceStartup;
        }
    }
    
}
