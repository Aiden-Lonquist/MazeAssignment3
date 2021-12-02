using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public GameObject enemy;
    private Quaternion direction;
    public int initial_rotation_timer;
    private int cur_rotation_timer;
    float start_pos_x, start_pos_z;
    // Start is called before the first frame update
    void Start()
    {
        cur_rotation_timer = initial_rotation_timer;
        start_pos_x = enemy.transform.position.x;
        start_pos_z = enemy.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (cur_rotation_timer < 0)
        {
            rotateEnemy();
            cur_rotation_timer = initial_rotation_timer;
        }
        cur_rotation_timer -= 1;
        walk();
    }

    private void rotateEnemy()
    {
        direction = Random.rotation;
        // adjust values so that he doesn't rotate along x or y
        direction.x = 0;
        direction.y *= 45f;
        direction.z = 0;
        direction.w = 20;
        // lerp (FROM rotation, TO rotation, 
        enemy.transform.rotation = Quaternion.Lerp(enemy.transform.rotation, direction, 0.005f);
    }

    private void walk()
    {
        enemy.transform.position += transform.forward * speed * -1;
    }

    public void resetPOS()
    {
        enemy.transform.position = new Vector3(start_pos_x, 0f, start_pos_z);
    }
}
