using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject portal;
    public GameObject portal2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   //check if the portal hits the wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            //checks to see whic bullet hit the wall
            if(this.CompareTag("Bullet2"))
            {
                //finds the blue portal if it already exists
                if(GameObject.Find("portalblue(Clone)"))
                {
                    //destroys the blue portal if it exists
                    Destroy(GameObject.Find("portalblue(Clone)"));
                }
                //stores the location of where the bullet hit the wall
                Vector3 pos2 = this.transform.position;
                //sets the portal to that positiosn
                portal2.transform.position = pos2;
                //spawns the portal
                Instantiate(portal2);
                Destroy(gameObject);
            }
            //checks to see which bullet hit the wall
            if (this.CompareTag("Bullet"))
            {
                //checks if the orange portal already exists
                if(GameObject.Find("portalorange(Clone)"))
                {
                    //if the orange portal exists this deletes it
                    Destroy(GameObject.Find("portalorange(Clone)"));
                }
                //gets the position of where the bullet hit the wall
                Vector3 pos = this.transform.position;
                //set the portal to that position
                portal.transform.position = pos;
                //spawns the portal
                Instantiate(portal);
                Destroy(gameObject);
            }
        }
    }
}
