using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //Inicializando el GameManager (Logica del juego)
    public static GameManager instance;

    //Controles de manejo.
    private bool isGameStarted = false;
    private bool areScreensActive = true;
  

    // Points,text and Scores
    private int segment=0;
    public Text segments,speed,gameOver;

    //Speed
    private float speedController=0.2f;


	void Start ()
    {
		
	}
	void Update ()
    {
        StartGame();
	}

    public void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else if (instance!=null)
        {
            Destroy(gameObject);
        }
    }
    public void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            isGameStarted = true;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            isGameStarted = false;
            LoadScene();
             
        }
    }
    public void LoadScene() { SceneManager.LoadScene("MainScene"); }
    public bool IsGameStarted(){ return isGameStarted; }
    public void Dead() { isGameStarted = false; areScreensActive = false; gameOver.GetComponent< Text > ().enabled = true; }
    public bool AreScreensActive() { return areScreensActive; }
    public void SetScreensActive(bool a){ areScreensActive = a; }
    public int  Myrandoms(){return (int)Random.Range(1, 2);}
    public void Segmentmanager() { segment++;}
    public void SpeedManager(float a) { speedController = a; speed.text = speedController.ToString(".00"); }
    public void UpdateSegments(){segments.text = segment.ToString("0");}
    public void Win() { gameOver.text = "You Win !!!"; Dead(); }

}
