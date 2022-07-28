using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    private AudioSource _audioSource;
    private GameObject[] other;
    private bool NotFirst = false;
     private void Awake()
     {
        other = GameObject.FindGameObjectsWithTag("Music");
 
        foreach (GameObject oneOther in other)
        {
            if (oneOther.scene.buildIndex == -1)
            {
                NotFirst = true;
            }
        }
 
        if (NotFirst == true)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
     }
 
     public void PlayMusic()
     {
        Debug.Log("PlayMusic");
         if (_audioSource.isPlaying) return;
         _audioSource.loop = true;
         _audioSource.Play();
     }
 
     public void StopMusic()
     {
         _audioSource.Stop();
     }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
