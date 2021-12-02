using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public CharacterController controller;
    public CapsuleCollider collider;
    public GameObject player;
    public Material Nwall, Ewall, Swall, Wwall, floor, skybox;
    public Color night, day;
    public float speed;
    public bool noclipEnabled, isNight;
    float start_pos_x, start_pos_z;
    // Start is called before the first frame update
    void Start()
    {
        start_pos_x = -3.5f;
        start_pos_z = -3.5f;

        night = new Color(0.33f, 0.31f, 0.37f, 1);
        day = new Color(1, 1, 1, 1);
        skybox.color = new Color(0.45f, 0.57f, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        movement();

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Noclip();
        }

        if (Input.GetKeyDown(KeyCode.Home) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            ResetPOS();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            ChangeTime();
        }
    }

    private void movement()
    {
        float x_movement = Input.GetAxis("Horizontal");
        float z_movement = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x_movement + transform.forward * z_movement;

        controller.Move(movement * speed * Time.deltaTime);
    }

    private void Noclip()
    {
        noclipEnabled = !noclipEnabled;
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

    private void ResetPOS()
    {
        player.transform.position = new Vector3(start_pos_x, 0.5f, start_pos_z);
        GameObject enemy = GameObject.Find("Enemy"); 
        enemy.GetComponent<EnemyScript>().resetPOS();
    }

    private void ChangeTime()
    {
        isNight = !isNight;
        if (isNight)
        {
            //turn on shader so it looks like night time
            Nwall.color = night;
            Ewall.color = night;
            Swall.color = night;
            Wwall.color = night;
            floor.color = night;
            skybox.color = new Color(0.16f, 0.13f, 0.21f, 1);
        } else
        {
            Nwall.color = day;
            Ewall.color = day;
            Swall.color = day;
            Wwall.color = day;
            floor.color = day;
            skybox.color = new Color(0.45f, 0.57f, 1, 1);
        }
    }
}
