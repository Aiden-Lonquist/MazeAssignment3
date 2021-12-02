using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public CharacterController controller;
    public CapsuleCollider collider;
    public GameObject player;
    public float speed;
    public bool noclipEnabled;
    float start_pos_x, start_pos_z;
    // Start is called before the first frame update
    void Start()
    {
        start_pos_x = -3.5f;
        start_pos_z = -3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        movement();

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            noclipEnabled = !noclipEnabled;
            noclip();
        }

        if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            resetPOS();
        }
    }

    private void movement()
    {
        float x_movement = Input.GetAxis("Horizontal");
        float z_movement = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x_movement + transform.forward * z_movement;

        controller.Move(movement * speed * Time.deltaTime);
    }

    private void noclip()
    {
        if (noclipEnabled)
        {
            collider.enabled = false;
            player.layer = 7;
        } else
        {
            collider.enabled = true;
            player.layer = 0;
        }
    }

    private void resetPOS()
    {
        player.transform.position = new Vector3(start_pos_x, 0.5f, start_pos_z);
        GameObject enemy = GameObject.Find("Enemy"); 
        enemy.GetComponent<EnemyScript>().resetPOS();
    }
}
