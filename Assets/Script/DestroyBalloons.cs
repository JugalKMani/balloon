using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyBalloons : MonoBehaviour
{
    
    public GameObject balloonSpawn;
    public GameObject canvas;
    public GameObject scoreCanvas;
    public GameObject gameOverPanel ;
    public GameObject pausePanel;


    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI currentScoreText;

    public GameObject Explosion; 
    public int score = 0;
    public int highScore = 0;
    public GameObject camara;

    

    public AudioClip popSound;
    public AudioSource audio;

    public Camera mainCamera;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        highScoreText.text = "HighScore: " + highScore.ToString();
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        
    }

    void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            
            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.collider.CompareTag("Balloon"))
                {
                   
                    hit.collider.gameObject.SetActive(false);
                    Instantiate(Explosion, transform.position, Quaternion.identity);
                    PopSound();
                    score++;
                    
                }
            }
        }
      
        currentScoreText.text = " Score : " + score.ToString();
        if(score > highScore)
        {
            highScore = score;
            highScoreText.text = "HighScore : " + highScore.ToString();

            PlayerPrefs.SetInt("HighScore", highScore);
        }
        

    }

    public void PlayButton()
    {
        balloonSpawn.SetActive(true);
        canvas.SetActive(false);
        scoreCanvas.SetActive(true);

    }
    public void RetryBtn()
    {
        SceneManager.LoadScene(0);
    }
    public void PopSound()
    {
        audio.clip = popSound;
    }
    
    public void PauseBtn()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);

    }
    public void ResumeBtn()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false );
    }
    public void ExitBtn()
    {
        Application.Quit();
    }




}
