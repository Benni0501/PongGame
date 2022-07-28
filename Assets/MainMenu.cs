using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioMixer MasterMixer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();

        int firstStart = PlayerPrefs.GetInt("FirstStart");
        if(firstStart == 0){
            FirstStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FirstStart(){
        PlayerPrefs.SetInt("FirstStart",1);
        PlayerPrefs.SetInt("speed", 25);
        PlayerPrefs.SetInt("paddle_speed", 25);
        PlayerPrefs.SetInt("volume", 80);
        PlayerPrefs.SetInt(key: "music", 80);
        MasterMixer.SetFloat("Effects", 0);
        MasterMixer.SetFloat("Music", 0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
