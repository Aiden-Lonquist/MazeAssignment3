using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public int respawnTimer;
    public int timer;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        timer = respawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Enemy") == null && GameObject.Find("Enemy(Clone)") == null)
        {
            if (timer <= 0)
            {
                timer = respawnTimer;
                spawnNewEnemy();
            }
            timer -= 1;
        }
        Debug.Log(timer);
    }

    public void spawnNewEnemy()
    {
        float x = Random.Range(-4.5f, 2.5f);
        float y = 0;
        float z = Random.Range(-7f, -0f); ;
        Instantiate(enemy, new Vector3(x, y, z), transform.rotation);
    }
}
