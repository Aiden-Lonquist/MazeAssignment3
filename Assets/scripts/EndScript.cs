using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    public MeshRenderer win_text;

    public void Start()
    {
        win_text.enabled = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "Player")
        {
            win_text.enabled = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.name == "Player")
        {
            win_text.enabled = false;
        }
    }
}
