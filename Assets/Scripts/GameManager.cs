using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // general
    public float arrowSpeed;
    public float arrowStrafespeed;
    public bool gameRunning = false;
    public bool gameOver = false;
    public GameObject arrow;
    public static GameManager instance;

    // end level stuff
    [SerializeField]
    private GameObject endLevelMenu;

    // game over stuff
    [SerializeField]
    private GameObject gameOverMenu;

    // arrow count stuff
    [SerializeField]
    private TMP_Text arrowCountText;
    private int arrowCount;
    
    // coin stuff
    [SerializeField]
    private TMP_Text coinCountText;
    private int coinCount;
    
    // score stuff
    [SerializeField]
    private TMP_Text scoreText;
    private int score;

    // ui parts to set false after load scene or gameover
    [SerializeField]
    private GameObject[] uiParts;

    // score related methods
    public void IncrementScoreByAmount(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
    
    // coin related methods
    public void IncrementCoinCount()
    {
        coinCount += 1;
        coinCountText.text = (coinCount).ToString();
    }
    
    public int GetCoinCount()
    {
        return coinCount;
    }

    public void SetCoinCount(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            IncrementCoinCount();
        }
    }
    
    
    // arrow count related methods
    public void IncrementArrowCount()
    {
        arrowCount += 1;
        arrowCountText.text = (arrowCount).ToString();
    }
    
    public int GetArrowCount()
    {
        return arrowCount;
    }

    public void SetArrowCount(int amount)
    {
        arrowCount = amount;
        
        if(arrowCount <= 0)
        {
            arrowCount = 0;
            GameOver();
            
        }
        arrowCountText.text = arrowCount.ToString();

    }

    // this is about make this GamaManger exist during the whole game
    private void Awake()
    {
        // Singleton Zımbırtısı
        // Eğer ilk defa giriyorsa bir scene'e,
        // GameManager Instance'ı olmadığı için atama yapıyoruz
        if (instance == null || instance == this)
        {
            instance = this;
            // DontDestroyOnLoad(this);
        }
        else
        {
            // Eğer null değilse zaten daha önce girilmiş
            // ve buranın instance'ı var demektir
            Destroy(this.gameObject);
        }
        
    }
    
    // this is for to start game when the the screen is tapped
    public void StartGame()
    {
        gameRunning = true;
        gameOver = false;
    }
    
    public void MakeCalculation(int value, string operation)
    {
        int newArrowCount;
        Debug.Log("Hesaplama yapildi");
        if(operation == "x")
        {
            newArrowCount = this.arrowCount * value;
            SetArrowCount(newArrowCount);
            Debug.Log("newArrowCount: " + newArrowCount);
        }
        if (operation == "÷")
        {
            newArrowCount = this.arrowCount / value;
            SetArrowCount(newArrowCount);
            Debug.Log("newArrowCount: " + newArrowCount);
        }
        if (operation == "+")
        {
            newArrowCount = this.arrowCount + value;
            SetArrowCount(newArrowCount);
            Debug.Log("newArrowCount: " + newArrowCount);
        }
        if (operation == "-")
        {
            newArrowCount = this.arrowCount - value;
            SetArrowCount(newArrowCount);
            Debug.Log("newArrowCount: " + newArrowCount);
        }


    }
    
    public void GameOver()
    {
        gameOver = true;
        gameRunning = false;

        gameOverMenu.SetActive(true);

        HideUIParts();
    }

    public void EndLevel()
    {
        gameRunning = false;

        endLevelMenu.SetActive(true);
        HideUIParts();
    }

    private void HideUIParts()
    {
        foreach (var part in uiParts)
        {
            part.SetActive(false);
        }
    }

    public void ResetLevel()
    {
        try
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        catch
        {
            Debug.LogError("Couldn't reload the scene");
        }
    }

    public void LoadNextLevel()
    {
        // for now lets just use reset
        ResetLevel();

        
        //try
        //{
        //    int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        //    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //}
        //catch
        //{
        //    Debug.LogError("The Index of the next scene that you wanted to load, doesn't exist");
        //}
        
    }
    
}
