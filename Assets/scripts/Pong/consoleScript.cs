using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class consoleScript : MonoBehaviour
{
    public GameObject console;
    public bool isVisible;
    private Vector3 initialScale;
    string input;
    public Camera camera;
    //private ConsoleControl console_control;

    /*    private void Awake()
        {
            console_control = new ConsoleControl();
        }

        private void OnEnable()
        {
            console_control.Enable();
        }

        private void OnDisable()
        {
            console_control.Disable();
        }*/

    void Start()
    {
        initialScale = gameObject.transform.localScale;
        console.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            changeVisible();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            changeVisible();
        }
    }

/*    public void OnTab(InputValue value)
    {
        Debug.Log("TAB");
        changeVisible();
    }

    public void OnEnter(InputValue value)
    {
        Debug.Log("Enter");
    }*/

    private void changeVisible()
    {
        isVisible = !isVisible;
    }

    private void OnGUI()
    {
        if (isVisible)
        {
            console.transform.localScale = initialScale;
            Time.timeScale = 0;
            input = GUI.TextField(new Rect(0, 695, 610, 369), input);
            GUI.skin.textField.fontSize = 30;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (input != "" && input.StartsWith("/"))
                {
                    checkInput(input);
                }
            }
        }
        else
        {
            console.transform.localScale = new Vector3(0, 0, 0);
            Time.timeScale = 1;
        }
    }

    private void checkInput(string input)
    {
        int input_length = input.Length;
        if (input == "/restart")
        {
            restartGame();
            Debug.Log("restarted the game");
            updateInput("");
        } else if (input_length >= 10 && input.Substring(0,11) == "/background")
        {
            if (input == "/background red")
            {
                Debug.Log("change bg color to red");
                updateBGColor("red");
            } else if (input == "/background blue")
            {
                Debug.Log("change bg color to blue");
                updateBGColor("blue");
            } else if (input == "/background green")
            {
                Debug.Log("change bg color to green");
                updateBGColor("green");
            }
            else if (input == "/background default")
            {
                Debug.Log("change bg color to default");
                updateBGColor("default");
            }
            else
            {
                updateInput("Use /background [color], available colors:\nred, green, blue, default");
            }
        } else if (input == "/help")
        {
            updateInput("Available commands are:\n/restart, /background, /help");
        }else
        {
            Debug.Log("Invalid input is: " + input);
            updateInput("Error: Invalid Command, try:\n/help");
        }
    }

    private void restartGame()
    {
        GameObject.Find("player1").GetComponent<Player1Script>().resetPos();
        if (GameObject.Find("player2") != null)
        {
            GameObject.Find("player2").GetComponent<Player2Script>().resetPos();
        } else
        {
            GameObject.Find("playerAI").GetComponent<aiScript>().resetPos();
        }
        GameObject.Find("ball").GetComponent<ballScript>().restartBall(true);
        goalScript.player1_points = 0;
        goalScript.player2_points = 0;
        GameObject.Find("player1Score").GetComponent<TextMeshProUGUI>().text = goalScript.player1_points.ToString();
        GameObject.Find("player2Score").GetComponent<TextMeshProUGUI>().text = goalScript.player2_points.ToString();
    }

    private void updateBGColor(string color)
    {
        if (color == "red")
        {
            camera.backgroundColor = new Color(0.5f, 0.15f, 0.15f);
        } else if (color == "blue")
        {
            camera.backgroundColor = new Color(0.15f, 0.15f, 0.5f);
        } else if (color == "green")
        {
            camera.backgroundColor = new Color(0.15f, 0.5f, 0.15f);
        } else if (color == "default")
        {
            camera.backgroundColor = new Color(0.2f, 0.2f, 0.2f);
        }
        updateInput("");

    }

    private void updateInput(string new_input)
    {
        input = new_input;
    }
}
