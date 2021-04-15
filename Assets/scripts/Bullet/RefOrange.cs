using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefOrange : MonoBehaviour
{
    public GameObject port2;
    private RefBlue refToBlue;
    public bool exitOrange = true;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && exitOrange == true)
        { 
            //finds the other portal
            port2 = GameObject.Find("portalblue(Clone)");
            if (port2 != null)
            {
                //gets the location of the other portal, turns it off and then teleports the player.
                refToBlue = port2.GetComponent<RefBlue>();
                refToBlue.exitBlue = false;
                other.gameObject.transform.position = port2.transform.position;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        //turns the portal back on
        exitOrange = true;
    }
}
