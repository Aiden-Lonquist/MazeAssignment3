using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    public CharacterController controller;
    public CapsuleCollider collider;
    public GameObject player, ball, head;
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

        // night = new Color(0.45f, 0.57f, 1, 1);
        // day = new Color(0.16f, 0.13f, 0.21f, 1);
        skybox.color = day;
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            ThrowBall();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ToggleFlashlight();
        }
    }

    private void movement()
    {
        float x_movement = Input.GetAxis("Horizontal");
        float z_movement = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x_movement + transform.forward * z_movement;

        controller.Move(movement * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
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

    public void ResetPOS()
    {
        player.transform.position = new Vector3(start_pos_x, 0.5f, start_pos_z);
        if (GameObject.Find("Enemy") != null)
        {
            GameObject enemy = GameObject.Find("Enemy");
            enemy.GetComponent<EnemyScript>().resetPOS();
        } else
        {
            GameObject enemy = GameObject.Find("Enemy(Clone)");
            enemy.GetComponent<EnemyScript>().resetPOS();
        }
    }

    private void ChangeTime()
    {
        //get the reference to the light Object by tag
        var sceneLight = GameObject.FindWithTag( "light" );


        if (isNight)
        {
            Debug.Log("Night");
            //disable the Light
            sceneLight.GetComponent<Light>().enabled = false;
            skybox.color = night;
        } else
        {
            Debug.Log("Day");
            //enable the Light
            sceneLight.GetComponent<Light>().enabled = true;
            skybox.color = day;
        }

        isNight = !isNight;
    }

    private void ToggleFlashlight() {
        GameObject flashlight = GameObject.Find("Flashlight");
        if (flashlight.GetComponent<Light>().enabled) {
            flashlight.GetComponent<Light>().enabled = false;
        } else {
            flashlight.GetComponent<Light>().enabled = true;
        }
    }

    private void ThrowBall()
    {
        Instantiate(ball, head.transform.position + head.transform.forward/2, head.transform.rotation);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            ResetPOS();
        } 
    }
}
