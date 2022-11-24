using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
    public Text TotalTime;
    Text time;
    // Start is called before the first frame update
    void Start()
    {
       
        time = GetComponent<Text>();
        if (time != null)
            time.text = TotalTime.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void relay ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
