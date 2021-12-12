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

    private void Awake()
    {
        R = GetComponent<SpriteRenderer>();
        OriginalColor = R.color;
    }

    private void OnMouseDown()
    {
        //If I click the button, set the chosen action
        switch (option)
        {
            case buttons.MainMenu:
                GameManager.GM.Reset();
                GameManager.GM.EndPopUp.SetActive(false);
                SceneManager.LoadScene("Scenes/MainMenu");
                break;
            case buttons.Reset:
                GameManager.GM.Reset();
                GameManager.GM.EndPopUp.SetActive(false);
                break;
            case buttons.Select:
                Player.FinishTurn = true;
                GameManager.GM.SwitchTurn();
                break;
            case buttons.Play:
                SceneManager.LoadScene("Scenes/MainGame");
                break;
            case buttons.Quit:
                Debug.Log("quit");
                break;
        }

        R.color = OriginalColor;
    }

    private void OnMouseOver()
    {
        //set color
        R.color = new Color(0.9058824f, 0.3529412f, 0.7333333f);
    }

    private void OnMouseExit()
    {
        //set color back to default
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
}
