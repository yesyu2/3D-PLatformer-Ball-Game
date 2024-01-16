using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   [SerializeField] 
   private PlayerController playerController;
   [SerializeField]
   private float respawnDelay = 1.5f;
   private bool isGameEnding = false;
   private int score;
   public Text scoreText;
   public Text winText;
   public GameObject WinnerUI;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void RespawnPlayer()
    {   
        if(isGameEnding == false)
        {
            isGameEnding = true;
            StartCoroutine(RespawnCoroutine());
        }
        
    }
  public IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        //BACK TO FIRST LEVEL
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerController.transform.position = playerController.respawnPoint;
        playerController.gameObject.SetActive(true);
        isGameEnding = false;
    }
    
    public void AddScore(int numberOfScore)
    {
        score += numberOfScore;
        scoreText.text = score.ToString();
    }

    public void LevelUp()
    {
        WinnerUI.SetActive(true);
        winText.text = "Level Completed YOUR SCORE : " + score;
        Invoke("nextLevel", respawnDelay);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
