using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform Target;
    public GameObject Bullet;
    
    [Header("Graden voor de rotation")]
    public float RotPos;
    [Header("Graden voor de Random Bullet")]
    public float RotBetween;
    
    private float speed = 50;
    private IEnumerator Rotate;
    private IEnumerator target;
    [Header("Raycast")]
    public float rayLength = 15;
    public LayerMask layersToCheck;
    
    [Header("Bullet")]
    public float ShootCoolDown;
    public float BetweenBullet;
    public float BurstAmount;
    
    //Bullet Angles
    private float Angle;
    private float TempAngle;
    private float RotBullet;
    private Quaternion TransRotBullet;
    
    private bool FastTurret = false;
    
    private bool canShoot;
    private bool betweenBullet;
    private float timer;
    private float timer2;
    private float Count;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Rotate = ObjectRotate();
        target = TargetLocked();
    }
    
    void Update()
    {
        //timer voor de Burst
        timer -= Time.deltaTime;
        
        if(timer <= 0)
        {
            canShoot = true;
        }
        
        //timer voor de Between bullet
        timer2 -= Time.deltaTime;
        
        if(timer2 <= 0)
        {
            betweenBullet = true;
        }
    }
    
    void FixedUpdate()
    {
        TempAngle = Angle;
        
        Vector3 dir = new Vector3(transform.position.x, transform.position.y, transform.rotation.z);
        #region Single Hit Detection
            //shoots a raycast
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.up), rayLength, layersToCheck);
            
            if (hit == true)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    StartCoroutine(target);
                    StopCoroutine(Rotate);
                    FastTurret = false;
                    
                    if (canShoot == true)
                    {
                        if (betweenBullet == true)
                        {
                            Count += 1;
                            RotBullet = TempAngle += Random.Range(-RotBetween, RotBetween);
                            TransRotBullet = Quaternion.AngleAxis(RotBullet, Vector3.forward);
                            Instantiate(Bullet, transform.position, TransRotBullet);
                            
                            betweenBullet = false;
                            timer2 = BetweenBullet;
                            
                            if (Count == BurstAmount)
                            {
                                Count = 0;
                                timer = ShootCoolDown;
                                canShoot = false;
                            }
                        }
                    }
                }
                
                //Als we iets geraakt hebben tekenen we een groene lijn welke 1 seconden blijft staan
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * rayLength, Color.green, 1f);
            }
            
            else
            {
                //Als we gemist hebben dan tekenen we een rode lijn voor 0,5 seconden
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * rayLength, Color.red, 0.5f);
                
                if (FastTurret == false)
                {
                    //start rotating 
                    StartCoroutine(Rotate);
                    StopCoroutine(target);
                    FastTurret = true;
                }
            }
            #endregion
        
        
    }
    
    IEnumerator TargetLocked()
    {
        while (true)
        {
            //locked to the player
            Vector2 direction = Target.position - transform.position;
            Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            Quaternion rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
            
            yield return null;
        }
    }
    
    IEnumerator ObjectRotate() 
    {
        //idle rotating
        float timer = 0;
        while (true) {
            float angle = Mathf.Sin(timer) * RotPos;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            timer += Time.deltaTime;
            
            yield return null;
        }
    }
}