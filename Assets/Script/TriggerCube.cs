using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerCube : MonoBehaviour
{
    public int balloonCount ;
    public GameObject gameOverPanel;
    public TextMeshProUGUI life;
    // Start is called before the first frame update
    void Start()
    {
         gameOverPanel.SetActive(false);
        life.text = " LIFE : " + balloonCount.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Balloon"))
        {
            balloonCount--;
            life.text = " LIFE : "+balloonCount.ToString();

            Debug.Log(balloonCount);
            if (balloonCount <= 0)
            {
                
               
                gameOverPanel.SetActive(true);
                Time.timeScale = 0;


            }


        }

    }
}



