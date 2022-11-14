using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerSound : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource[] audioSources;

    public AudioSource[] AudioSources { get => audioSources; set => audioSources = value; }

    void Start()
    {
        AudioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
