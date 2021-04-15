using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCube : MonoBehaviour
{
    
    public float PlMaxSpeed = 10f;
    public float pLSpeedMult = 20f;
    public float speed = 50f;
    
    // player movement
    private Vector2 movement;
    private float moveHoriziontal;
    private float moveVertical;
    private Rigidbody2D plRigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        plRigidbody = GetComponent<Rigidbody2D>(); 
    }
    
    // Update is called once per frame
    void Update()
    {
        // movement player
        moveHoriziontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        
        movement = new Vector2(moveHoriziontal, moveVertical);
        
        if(movement != Vector2.zero)
        {
            plRigidbody.AddForce(movement * pLSpeedMult);
        }
        else
        {
            plRigidbody.velocity = Vector2.zero;
        }
        
        if(plRigidbody.velocity.magnitude > PlMaxSpeed)
        {
            plRigidbody.velocity = plRigidbody.velocity.normalized * PlMaxSpeed;
        }
    }
}


