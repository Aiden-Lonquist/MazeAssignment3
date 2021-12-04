using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class goalScript : MonoBehaviour
{
    public bool leftGoal;
    static public int player1_points, player2_points;
    public GameObject player1text, player2text;
    static public bool player1wins, isAI;
    public int winScore;
    // Start is called before the first frame update
    void Start()
    {
        player1_points = 0;
        player2_points = 0;
        if (GameObject.Find("player2") == null)
        {
            isAI = true;
        } else
        {
            isAI = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player1_points == winScore)
        {
            player1wins = true;
            SceneManager.LoadScene(0);
        } else if (player2_points == winScore)
        {
            player1wins = false;
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (leftGoal)
        {
            player2_points += 1;
            player2text.GetComponent<TextMeshProUGUI>().text = player2_points.ToString();
            GameObject.Find("ball").GetComponent<ballScript>().restartBall(false);
            reset_positions();
        } else
        {
            player1_points += 1;
            player1text.GetComponent<TextMeshProUGUI>().text = player1_points.ToString();
            GameObject.Find("ball").GetComponent<ballScript>().restartBall(true);
            reset_positions();
        }
    }

    private void reset_positions()
    {
        GameObject.Find("player1").GetComponent<Player1Script>().resetPos();
        if (GameObject.Find("player2") != null)
        {
            GameObject.Find("player2").GetComponent<Player2Script>().resetPos();
        } else
        {
            GameObject.Find("playerAI").GetComponent<aiScript>().resetPos();
        }
    }
}
