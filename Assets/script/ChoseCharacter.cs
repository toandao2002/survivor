using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoseCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Chosecharacter(int i)
    {
        if (i ==0)
        {
            SceneManager.LoadScene("GamePlay1");
        }
        else
        {
            SceneManager.LoadScene("GamePlay2");
        }
    } 
}
