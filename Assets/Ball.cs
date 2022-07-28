using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed = 20;
    public Rigidbody2D rb;
    public Vector3 startPosition;

    private AudioSource paddle_sound;

    private AudioSource wall_sound;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] sounds = GetComponents<AudioSource>();
        foreach(AudioSource sound in sounds){
            if(sound.clip.ToString() == "paddle_sound (UnityEngine.AudioClip)"){
                paddle_sound = sound;
            } else if(sound.clip.ToString() == "wall_sound (UnityEngine.AudioClip)"){
                wall_sound = sound;
            }
        }
        startPosition = transform.position;
        speed =  PlayerPrefs.GetInt("speed");
        Debug.Log(AudioListener.volume);
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Launch(){
        /*float x, y;
        if (Random.Range(0,2) == 0)
        {
            x = Random.Range(1, 2);
            y = Random.Range(1, 2);
        } else
        {
            x = Random.Range(-1, -2);
            y = Random.Range(-1, -2);
        }
        */
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    public void Reset(){
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        speed = PlayerPrefs.GetInt("speed");
        Launch();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.gameObject.CompareTag("Wall")){
            wall_sound.Play();
        } else if (other.collider.gameObject.CompareTag("Paddle")){
            paddle_sound.Play();
        }
    }
    
}
