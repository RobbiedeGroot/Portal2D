using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    public GameObject MovementTutorial;
    public float WASDTimer = 30f;
    // Start is called before the first frame update
    void Start()
    {
      MovementTutorial.SetActive(true);
    }

    private void Update() 
    {
      WASDTimer -= Time.deltaTime;
      if(WASDTimer < 0){
        MovementTutorial.SetActive(false);
      }
    }
}
