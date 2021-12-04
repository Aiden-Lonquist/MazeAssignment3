using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameEndScript : MonoBehaviour
{
    public GameObject player1text, player2text, GameOverText;
    // Start is called before the first frame update
    void Start()
    {
        /*Debug.Log(goalScript.player1_points);
        Debug.Log(goalScript.player2_points);
        Debug.Log(goalScript.player1wins);*/
        player1text.GetComponent<TextMeshProUGUI>().text = goalScript.player1_points.ToString();
        player2text.GetComponent<TextMeshProUGUI>().text = goalScript.player2_points.ToString();
        if (goalScript.player1wins)
        {
            GameOverText.GetComponent<TextMeshProUGUI>().text = "Player 1 Wins";
        } else if (!goalScript.isAI)
        {
            GameOverText.GetComponent<TextMeshProUGUI>().text = "Player 2 Wins";
        } else
        {
            GameOverText.GetComponent<TextMeshProUGUI>().text = "Computer Wins";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            restart_game();
        }
    }

    public void restart_game()
    {
        goalScript.player1_points = 0;
        goalScript.player2_points = 0;
        SceneManager.LoadScene("game_start");
    }
}
