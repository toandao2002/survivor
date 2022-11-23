using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddItem : MonoBehaviour
{
    public GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.childCount -1 < character.Instance.Item.Count)
        {
            addItem();

        }
    }
    public void addItem()
    {
        if (character.Instance.Item.Count != 0)
        {
           
                GameObject tmp = Instantiate(Item);
                tmp.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = character.Instance.Item[this.transform.childCount-1];
            tmp.transform.SetParent(this.gameObject.transform);  
     
        }
    }
}
