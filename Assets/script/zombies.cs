using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombies : MonoBehaviour
{   
     public float step;
    // Start is called before the first frame update
    character character;
    
    void Start()
    {
        character = FindObjectOfType<character>();
    }

    // Update is called once per frame
    void Update()
    {
        movetoCharacter();
    }
    public void movetoCharacter()
    {
        Vector3 posMain = character.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, character.transform.position, step);
    }
}
