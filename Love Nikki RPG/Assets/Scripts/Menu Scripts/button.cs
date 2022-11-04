using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class button : MonoBehaviour
{
    public buttons option;
    public SpriteRenderer R;
    public Color OriginalColor;
    public PlayerController Player;
    public AudioSource A;

    private void Awake()
    {
        //get the sprite renderer for the button 
        R = GetComponent<SpriteRenderer>();
        //set the original color to the renderers current color
        OriginalColor = R.color;
    }

    private void OnMouseDown()
    {
        //play the clicking noise 
        A.Play();
        //If I click the button, set the chosen action
        switch (option)
        {
            //main menu button on the ending popup
            case buttons.MainMenu:

                //set the level to 0
                God.GM.level = 0;
                // run the reset function
                God.GM.Reset();
                //set the ending popup inactive
                God.GM.EndPopUp.SetActive(false);
                //load the main menu scene
                SceneManager.LoadScene("Scenes/MainMenu");
                break;

            //reset button on the ending popup
            case buttons.Reset:

                //run the reset function
                God.GM.Reset();
                //set the button inactive
                gameObject.SetActive(false);
                //set the ending popup inactive
                God.GM.EndPopUp.SetActive(false);
                break;

            //select button to end the players turn during a level
            case buttons.Select:

                //set finish turn to true
                Player.FinishTurn = true;
                //run the switch turn function
                God.GM.SwitchTurn();
                break;

            //play button on the main menu, 
            case buttons.Play:

                //load the main game screen
                SceneManager.LoadScene("Scenes/MainGame");
                break;

            //quit button on the main menu
            case buttons.Quit:

                //quit the game
                Debug.Log("quit");
                break;

            //Next level button on the ending pop up when the player wins a level that isnt the final level
            case buttons.NextLevel:

                //run the next level function
                God.GM.Nextlvl();
                //set the button inactive
                gameObject.SetActive(false);
                //set the end pop up inactive
                God.GM.EndPopUp.SetActive(false);
                break;

            //play again button on the ending popup after winning the last level
            case buttons.PlayAgain:

                //set the level to 0
                God.GM.level = 0;
                //run the reset function
                God.GM.Reset();
                //set the button inactive
                gameObject.SetActive(false);
                //set the end pop up inactive
                God.GM.EndPopUp.SetActive(false);
                break;
        }

        //set the color back to the original color
        R.color = OriginalColor;
    }

    private void OnMouseOver()
    {
        //set color when the mouse hovers over the button
        R.color = new Color(0.9058824f, 0.3529412f, 0.7333333f);
    }

    private void OnMouseExit()
    {
        //set color back to default when the mouse isnt hovering on the button
        R.color = OriginalColor;
    }
}

public enum buttons
{
    MainMenu,
    Reset,
    Select,
    Play,
    Quit,
    NextLevel,
    PlayAgain,
}
