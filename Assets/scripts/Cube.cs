using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool Pickup = false;
    public bool Pickedup = false;
    public GameObject CubeObject;
    public GameObject Player;
    
    private Transform tempTrans ;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R) && Pickedup == true)
        {
            CubeObject.GetComponent<MovementCube>().enabled = false;
            
            CubeObject.GetComponent<Rigidbody2D>().angularDrag = 50;
            CubeObject.GetComponent<Rigidbody2D>().drag = 50;
            
            RevertParent();
            
            Pickedup = false;
        }
        
        if (Input.GetKeyUp(KeyCode.E) && Pickup == true && Pickedup == false)
        {
            CubeObject.GetComponent<Transform>().rotation = GetComponent<Transform>().rotation;
            CubeObject.GetComponent<Transform>().position = GetComponent<Transform>().position + new Vector3(0, 1, 0);
            
            CubeObject.GetComponent<Rigidbody2D>().angularDrag = 0.05f;
            CubeObject.GetComponent<Rigidbody2D>().drag = 0;
            
            CubeObject.GetComponent<MovementCube>().enabled = true;
            
            ChangeParent();
            
            Pickedup = true;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cube"))
        {
            Pickup = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        Pickup = false;
    }
    
    void ChangeParent()
    {
        tempTrans = CubeObject.transform.parent;
        CubeObject.transform.parent = Player.transform; 
    }
    
    void RevertParent()
    {
        CubeObject.transform.parent = tempTrans;
    }
}
