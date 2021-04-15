using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{

    public float PlMaxSpeed = 10f;
    public float pLSpeedMult = 20f;
    public float speed = 50f;
    
    // player movement
    private Vector2 movement;
    private float moveHoriziontal;
    private float moveVertical;
    private Rigidbody2D plRigidbody;
    public AudioSource steps;
    
    // Start is called before the first frame update
    void Start()
    {
        plRigidbody = GetComponent<Rigidbody2D>(); 
    }
    
    // Update is called once per frame
    void Update()
    {
        //rotation player
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        
        
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
        
        //footsteps audio
        //if (Input.GetButtonDown("Horizontal2") || Input.GetButtonDown("Vertical2"))
            //steps.Play();
        //else if (!Input.GetButton("Horizontal2") && !Input.GetButton("Vertical2") && steps.isPlaying)
            //steps.Stop(); // or Pause()
    }
}
