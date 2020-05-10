using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private float spawnRate = 1.0f; //Spawn rate
    public List<GameObject> targets; //Create a list to hold different balls
    private int scoreHolder; //Save current score
    public bool spawnBool = true; //set gen balls or not

    
    //-----UI-----
    public GameObject titleScreenHolder; //hold Title Screen
    public TextMeshProUGUI scoreTextHolder; //Hold Score text display
    public TextMeshProUGUI gameOverTextPrompt; //Hold Gameover Text
    public Button restartButton; //Hold restart button


    //-----SPAWN BALLS-----
    IEnumerator SpawnTarget()
    {
        while(spawnBool) //while true/false
        {
            yield return new WaitForSeconds(spawnRate); //wait every 1.0f seconds
            int index = Random.Range(0, targets.Count); //create a int which is random form 0~3 (list "tagrst" count how many)
            Instantiate(targets[index]); //Instantiate from list "target" random 0~3
        }
    }

    //-----
    public void UpdateScore(int scoreToAdd)
    {
        //When mouse clicked in "Target" script, Update Score will be called with "Target" points value
        //So the new score point will add to current scoreHolder
        scoreHolder += scoreToAdd;
        scoreTextHolder.text = "Score:" + scoreHolder; //Display current Score in scoreTextHolder.text
    }

    //-----GAME OVER----
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true); //show restart button
        gameOverTextPrompt.gameObject.SetActive(true); //show game over
        spawnBool = false; //set while loop to false
    }

    //-----RESTART SENCE-----
    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //-----START GAME METHOD which will be called in DifficultyButton Script-----
    public void StartGame(int difficulty)
    {

        StartCoroutine(SpawnTarget()); //start IEnumerator SpawnTarget()
        scoreHolder = 0; //score = 0 when started
        UpdateScore(0); //start UpdateScore method with score 0
        spawnBool = true; //set spawn while loop to true
        spawnRate /= difficulty; //set difficulty which pass from ifficultyButton Script

        titleScreenHolder.SetActive(false); //Un show Title Screen

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
