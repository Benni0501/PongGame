using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject Ball;

    [Header("Player 1")]
    public GameObject player1Paddle;
    public GameObject player1Goal;

    [Header("Player 2")]
    public GameObject player2Paddle;
    public GameObject player2Goal;

    [Header("Score UI")]
    public GameObject Player1Text;
    public GameObject Player2Text;

    public PhysicsMaterial2D bounce;

    private int Player1Score;
    private int Player2Score;

    public AudioMixer MasterMixer;

    public void Player1Scored(){
        
        Player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        ResetPostion();
        //bounce.bounciness += 2;
        int speed_int = PlayerPrefs.GetInt("speed");
        /*if(speed_int <= 60)
        {
            PlayerPrefs.SetInt("speed", speed_int += 1);
        }
        */
        
    }

    public void Player2Scored(){
        
        Player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        ResetPostion();
        //bounce.bounciness += 2;
    }

    private void ResetPostion(){
        Ball.GetComponent<Ball>().Reset();
        //player1Paddle.GetComponent<Paddle>().Reset();
        //player2Paddle.GetComponent<Paddle>().Reset();
    }


    void update(){
        if(Input.GetKey(KeyCode.Escape)){
            Application.Quit();
        }
    }
}
