using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValueManagerScript : MonoBehaviour
{
    private int player1_points, player2_points;
    public GameObject player1text, player2text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void player1Score()
    {
        player1_points += 1;
        player1text.GetComponent<TextMeshProUGUI>().text = player1_points.ToString();
    }

    public void player2Score()
    {
        player2_points += 1;
        player2text.GetComponent<TextMeshProUGUI>().text = player2_points.ToString();
    }
}
