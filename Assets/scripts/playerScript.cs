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

    [Header("Sounds")]
    public AudioSource walk;
    public AudioSource collide;
    public AudioSource bgm;
    public AudioSource bgm2;
    private AudioSource currentMusic;
    private bool musicPlaying;
    void Start()
    {
        start_pos_x = -3.5f;
        start_pos_z = -3.5f;
        currentMusic = bgm;
        isNight = false;
        musicPlaying = false;
        GameObject.Find("Fog").GetComponent<Renderer>().enabled = false;

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
            isNight = !isNight;
            ChangeTime();
            currentMusic.Stop();
            swapBgm();
            if (musicPlaying) {
                currentMusic.Play(); 
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ThrowBall();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ToggleFlashlight();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFog();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleBgm();
        }
    }

    private void movement()
    {
        float x_movement = Input.GetAxis("Horizontal");
        float z_movement = Input.GetAxis("Vertical");

        if (x_movement != 0 || z_movement != 0)
        {
            PlayWalkSound();
        } else {
            PlayWalkSound(false);
        }

        Vector3 movement = transform.right * x_movement + transform.forward * z_movement;

        controller.Move(movement * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    private void PlayWalkSound(bool toggle = true) {
        if (toggle) {
            if (!walk.isPlaying) {
                walk.time = 0;
                walk.Play();
            }
        } else {
            walk.Stop();
        }
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

    public void setPOS(Vector3 pos)
    {
        player.transform.position = pos;
    }

    private void ChangeTime()
    {
        //get the reference to the light Object by tag
        var sceneLight = GameObject.FindWithTag( "light" );


        if (isNight)
        {
            // CHANGE TO NIGHT

            Debug.Log("Night");
            //disable the Light
            sceneLight.GetComponent<Light>().enabled = false;
            skybox.color = night;
        } else
        {
            // CHANGE TO DAY

            Debug.Log("Day");
            //enable the Light
            sceneLight.GetComponent<Light>().enabled = true;
            skybox.color = day;
        }
    }

    private void swapBgm () {
        if (currentMusic == bgm) {
            currentMusic = bgm2;
        } else {
            currentMusic = bgm;
        }
    }

    private void ToggleFlashlight() {
        GameObject flashlight = GameObject.Find("Flashlight");
        if (flashlight.GetComponent<Light>().enabled) {
            flashlight.GetComponent<Light>().enabled = false;
        } else {
            flashlight.GetComponent<Light>().enabled = true;
        }
    }

    private void ToggleFog() {
        
        Debug.Log(currentMusic.volume);

        GameObject fog = GameObject.Find("Fog");
        if (fog.GetComponent<Renderer>().enabled) {
            fog.GetComponent<Renderer>().enabled = false;
            currentMusic.volume = 1;
        } else {
            fog.GetComponent<Renderer>().enabled = true;
            currentMusic.volume /= 2;
        }
    }

    private void ToggleBgm() {
        if (currentMusic.isPlaying) {
            currentMusic.Stop();
            musicPlaying = false;
        } else {
            currentMusic.Play();
            musicPlaying = true;
        }
    }

    private void ThrowBall()
    {
        Instantiate(ball, head.transform.position + head.transform.forward/2, head.transform.rotation);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "enemy")
        {
            ResetPOS();
        }

        if (collision.gameObject.tag == "wall")
        {
            Debug.Log("HIT WALL");
            collide.Play();
        }

    }

    public Vector3 GetPlayerPOS() {
        return transform.position;
    }
}
