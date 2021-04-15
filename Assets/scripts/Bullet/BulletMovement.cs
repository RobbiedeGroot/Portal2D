using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector3 startPos;
    
    public float Speed;
    
    [Header("Afstand vanaf de start pos")]
    public float Distance;
    
    private Vector3 startPosPos;
    private Vector3 startPosMin;
    
    private Rigidbody2D rig;
    
    private bool Once = false;
    
    
    // Start is called before the first frame update
    
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
        
        startPos = this.transform.position;
        
        startPosPos = new Vector3(startPos.x + Distance, startPos.y + Distance);
        startPosMin = new Vector3(startPos.x - Distance, startPos.y - Distance);
        
        Speed *= 1000;
    }
    
    void FixedUpdate() {
        //kijkt of de bullet na een bepaalde afstand is en delete die dan
        if (this.transform.position.x > startPosPos.x || this.transform.position.x < startPosMin.x || this.transform.position.y > startPosPos.y || this.transform.position.y < startPosMin.y)
        {
            Destroy(this.gameObject);
        }
        //only adds the force once
        if (Once == false)
        {
            rig.AddRelativeForce(Vector2.up * Time.deltaTime * Speed);
            Once = true;
        }
    }
}
