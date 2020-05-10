using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Get UI
using UnityEngine.UI;



public class DifficultyButton : MonoBehaviour
{
    //to hold Button for script to manage
    private Button buttonHolder;

    //Integrate with GamaeManager Script
    private GameManager gameManagerHolder;

    //Set Difficuly
    public int difficulty;


    //Method - Call "StartGame" method with int parameter "Difficuly"
    void SetDifficulty()
    {
        Debug.Log(buttonHolder.gameObject.name + "was clicked");
        //
        gameManagerHolder.StartGame(difficulty);
    }


    // Start is called before the first frame update
    void Start()
    {
        //Get Button component in inspector
        buttonHolder = GetComponent<Button>();
        //Set when button(in inspector) on click, call SetDifficulty Method
        buttonHolder.onClick.AddListener(SetDifficulty);
        //
        gameManagerHolder = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
