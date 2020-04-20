using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DiceManager : MonoBehaviour
{

    // This class manages the display of dice in the dice columns
    // It rolls a number of Dice based on user input and places them in the correct column

    
    public RectTransform[] DiceColumns;

    // UI Display elements
    public Text ScoreText;
    public Text NumberOfDiceRolled;

    private int _scoreText = 0;
    private int _numOfDice = 0;

    // This public property sets the number of dice to be rolled
    public int NumOfDice
    { get
        {
            return _numOfDice;
        }
     set
        {
            _numOfDice = value;
        }
    }


    private void Awake()
    {
        
        InitDiceColumns();
    }

    public void Activate()
    {
        InitDiceColumns();
        

        for (int i = 0; i < NumOfDice; i++)
        {
            
            int r = new Dice().Roll();
            AddDiceToColumn(r);
         
        }

    }

    private void InitDiceColumns()
    {
        // This function initialises our Dice Rolling system
        ScoreText.text = "";
        _scoreText = 0;
        foreach (RectTransform t in DiceColumns)
        {
            // Here we are looping thru all our columns...
            foreach (RectTransform r in t)
            {
                // Here we are looping thru all the dice sprites in the column and turning them off
                if (r.gameObject.CompareTag("Dice"))
                {
                    r.gameObject.SetActive(false);
                }
            }

        }
    }

    private void AddDiceToColumn(int column)
    {
        // This function will add a dice to the correct column
        foreach (Transform r in DiceColumns[column])
        {
            // This loop selects the correct dice column based on the number rolled
            // remember arrays start a 0, so our dice columns are indexed 0-5 = 1-6
            if (!r.gameObject.activeInHierarchy)
            {
                // Next we check all the dice sprites, as soon as we find one that is turned off,
                // we turn it on and then break out of the loop as we have done all we need to.
                r.gameObject.SetActive(true);
                // Add the value to our score total.
                _scoreText += (column + 1);
                break;
                
            }
            

        }
        // Update our score text
        ScoreText.text = _scoreText.ToString();
    }
      

    private void Update()
    {
        // This update function is for testing only - we can delete this once we're happy with the setup
        if (Input.GetKeyDown(KeyCode.D))
        {
            InitDiceColumns();
            Activate();
        }
    }

    public void SetNumberOfDice(float numDice)
    {
        // This function is hooked up to a UI slider to establish the number of dice to be rolled
        // We perform some simple mathematic operations to ensure we only ever get whole numbers - can't roll 2.6 dice...
        NumOfDice = (int)Mathf.Floor(numDice);
        NumberOfDiceRolled.text = Mathf.RoundToInt(NumOfDice).ToString();
    }
}
