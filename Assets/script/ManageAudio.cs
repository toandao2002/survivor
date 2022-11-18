using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageAudio : MonoBehaviour
{
    public static ManageAudio Instance;
    public AudioClip behurt;
    // Start is called before the first frame update
      AudioSource audioSource;
    public AudioClip game_lose, game_win ;
    public AudioSource getaudio()
    {
        return audioSource;
    }
    public List<AudioClip> audioBullets;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playSound(int i )
    {
         
        audioSource.PlayOneShot(audioBullets[i]);
    }
    public void gameWin()
    {
       

        audioSource.PlayOneShot(game_win);
    }
    public void gameLose()
    {

        audioSource.PlayOneShot(game_lose);
    }
    public void Behurt()
    {
        audioSource.PlayOneShot(behurt);
    }
}
