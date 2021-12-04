using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public int surviveTime;
    public float speed;
    public GameObject self, enemy;
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        self.transform.position += transform.forward*speed;
        if (surviveTime % 1 == 0)
        {
            surviveTime -= 1;
        }

        if(surviveTime <= 0)
        {
            Destroy(self, 0.1f);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("play sound");
        if (collision.gameObject.tag == enemy.tag)
        {
            Debug.Log("Collided with enemy");
            enemy.GetComponent<EnemyScript>().takeDamage();
        }

    }
}
