using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startMultiplayer(string message)
    {
        SceneManager.LoadScene("game");
        //Debug.Log(message);
    }

    public void startAI(string message)
    {
        SceneManager.LoadScene("game_ai");
        //Debug.Log(message);
    }
}

