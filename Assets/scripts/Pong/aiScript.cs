using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Vector3 start_pos;
    public Rigidbody2D ball;
    public float minimum_move_range;
    // Start is called before the first frame update
    private void Awake()
    {
        start_pos = transform.position;
    }



    private void FixedUpdate()
    {
        float ball_pos = ball.position.y;
        float cur_pos = rb.position.y;
        float move_input;
        int can_move = Random.Range(0, 2);
        if (ball_pos - cur_pos > minimum_move_range && can_move == 1)
        {
            move_input = 1;
        } else if (ball_pos - cur_pos < minimum_move_range*-1 && can_move == 1)
        {
            move_input = -1;
        } else
        {
            move_input = 0;
        }
        //float move_input = ball_pos - cur_pos;

        rb.velocity = new Vector2(0, move_input * speed);

        rb.transform.rotation = Quaternion.identity;
    }

    public void resetPos()
    {
        rb.transform.position = start_pos;
    }
}