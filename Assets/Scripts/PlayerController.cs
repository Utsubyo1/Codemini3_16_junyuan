using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float movespeed = 5.0f;
    float icounter = 10;
    public GameObject TimerCounter;
    public Rigidbody PlayerRb;
    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            StartRun();
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            StartRun();
            transform.rotation = Quaternion.Euler(0, 180, 0);
            
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.SetBool("isrun", false);
        }


        if (Input.GetKey(KeyCode.A) )
        {
            StartRun();
            transform.rotation = Quaternion.Euler(0, -90, 0);
           
        }
        else if (Input.GetKey(KeyCode.D) )
        {
            StartRun();
            transform.rotation = Quaternion.Euler(0, 90, 0);
            
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("isrun", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {  
            TimerCounter.GetComponent<Text>().text = "Timer Countdown: " + icounter.ToString();
        }
    }

    void StartRun()
    {
        playerAnim.SetBool("isrun", true);
        playerAnim.SetFloat("walk", 0.26f);
        transform.Translate(Vector3.forward * Time.deltaTime * movespeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cone"))
        {
            icounter -= Time.deltaTime;
            TimerCounter.GetComponent<Text>().text = "Timer Countdown: " + icounter.ToString();
            Debug.Log("Acvtiavted PlaneB 90deg rotation"); 
        }
    }


}
