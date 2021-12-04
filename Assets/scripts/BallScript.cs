using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public int surviveTime;
    public float speed;
    public GameObject self;
    public AudioSource bounce;
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
            Destroy(self, 0.01f);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        bounce.time = 0.3f;
        bounce.Play();
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("Collided with enemy");
            Destroy(self, 0.01f);
        }

    }
}
