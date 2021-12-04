using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{
    public float speed;
    public bool directionRight;
    public Rigidbody2D rb;
    public float acceleration_timer;
    public float acceleration_speed;
    public float max_speed;
    private Vector3 start_pos;
    // Start is called before the first frame update
    void Start()
    {
        start_pos = transform.position;
        startBall();
        StartCoroutine("accelerateBall");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator accelerateBall()
    {
        while (true)
        {
            float cur_speed_x = rb.velocity.x;
            float cur_speed_y = rb.velocity.y;
            if (Mathf.Abs(cur_speed_x) < 250)
            {
                rb.velocity = new Vector2(cur_speed_x * (acceleration_speed+0.1f), cur_speed_y * (acceleration_speed+0.1f));
            } else if (Mathf.Abs(cur_speed_x) < max_speed)
            {
                rb.velocity = new Vector2(cur_speed_x * acceleration_speed, cur_speed_y * acceleration_speed);
            }
            //Debug.Log("speed X increased from " + cur_speed_x + "to" + rb.velocity.x);
            yield return new WaitForSeconds(acceleration_timer);
        }
    }


    private void startBall()
    {
        float y_speed = (Random.value*2)-1;
        if (directionRight)
        {
            rb.velocity = new Vector2(speed, speed * y_speed);
        } else
        {
            rb.velocity = new Vector2(speed*-1, speed * y_speed);
        }
    }

    public void restartBall(bool directionRight)
    {
        rb.transform.position = start_pos;
        float y_speed = (Random.value * 2) - 1;
        if (directionRight)
        {
            rb.velocity = new Vector2(speed, speed * y_speed);
        }
        else
        {
            rb.velocity = new Vector2(speed * -1, speed * y_speed);
        }
    }
}
