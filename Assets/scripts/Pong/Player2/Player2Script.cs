using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Script : MonoBehaviour
{
    private Player2_Controls player_controls;
    private InputAction movement;
    public Rigidbody2D rb;
    public float speed;
    private Vector3 start_pos;
    // Start is called before the first frame update
    private void Awake()
    {
        start_pos = transform.position;
        player_controls = new Player2_Controls();
    }

    // Update is called once per frame
    private void OnEnable()
    {
        movement = player_controls.movementMap.movementAction;
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    private void FixedUpdate()
    {
        float move_input = movement.ReadValue<float>();

        rb.velocity = new Vector2(0, move_input * speed);
        rb.transform.rotation = Quaternion.identity;
    }

    public void resetPos()
    {
        rb.transform.position = start_pos;
    }
}
