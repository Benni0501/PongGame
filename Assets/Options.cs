using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public AudioMixer MasterMixer;
    public Slider slider;
    public Slider paddle_slider;
    public Slider volume_slider;
    public Slider music_slider;
    private int speed_int;
    private int paddle_speed_int;
    private int volume_int;
    private int music_int;
    public GameObject text;
    public GameObject paddle_text;
    public GameObject volume_text;
    public GameObject music_text;
    // Start is called before the first frame update
    void Start()
    {
        speed_int = PlayerPrefs.GetInt("speed");
        slider.value = speed_int;
        text.GetComponent<Text>().text = slider.value.ToString();

        paddle_speed_int = PlayerPrefs.GetInt("paddle_speed");
        paddle_slider.value = paddle_speed_int;
        paddle_text.GetComponent<Text>().text = paddle_slider.value.ToString();

        volume_int = PlayerPrefs.GetInt("volume");
        volume_slider.value = volume_int;
        volume_text.GetComponent<Text>().text = volume_slider.value.ToString();

        music_int = PlayerPrefs.GetInt("music");
        music_slider.value = music_int;
        music_text.GetComponent<Text>().text = music_slider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void zuruek()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ball_speed()
    {
        PlayerPrefs.SetInt("speed", (int)slider.value);
        Debug.Log(slider.value.ToString());
        text.GetComponent<Text>().text = slider.value.ToString();
    }

    public void paddle_speed()
    {
        PlayerPrefs.SetInt("paddle_speed", (int)paddle_slider.value);
        Debug.Log(paddle_slider.value.ToString());
        paddle_text.GetComponent<Text>().text = paddle_slider.value.ToString();
    }

    public void volume(){
        PlayerPrefs.SetInt("volume", (int) volume_slider.value);
        volume_text.GetComponent<Text>().text = volume_slider.value.ToString();
        float volume_range = volume_slider.value - 80;
        MasterMixer.SetFloat("Effects", volume_range);
    }

    public void music(){
        PlayerPrefs.SetInt(key: "music", (int) music_slider.value);
        music_text.GetComponent<Text>().text = music_slider.value.ToString();
        float music_range = music_slider.value-80;
        MasterMixer.SetFloat("Music", music_range);
    }
}
