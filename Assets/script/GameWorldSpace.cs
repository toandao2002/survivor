using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldSpace : MonoBehaviour
{
    public static GameWorldSpace Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
