using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float maxlimit = 5.0f;
    float ftimercounter = 10;
    float movespeed = 5.0f;
    int icounter;
    int totalcoinleft;
    public GameObject TextTimerCounter;
    public GameObject PlaneBgo;
    public GameObject coinleft;
    public Rigidbody PlayerRb;
    public Animator playerAnim;
    bool startcount = true;
    bool rotate = false;
    bool coingone = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -maxlimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -maxlimit);
        }

        if (transform.position.x < -maxlimit)
        {
            transform.position = new Vector3(-maxlimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > maxlimit)
        {
            transform.position = new Vector3(maxlimit, transform.position.y, transform.position.z);
        }



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


        if (Input.GetKey(KeyCode.A))
        {
            StartRun();
            transform.rotation = Quaternion.Euler(0, -90, 0);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            StartRun();
            transform.rotation = Quaternion.Euler(0, 90, 0);

        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("isrun", false);
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {  
            TimerCounter.GetComponent<Text>().text = "Timer Countdown: " + icounter.ToString();
        }*/
        if (rotate == true && coingone == true)
        {
            if (ftimercounter > 0 && startcount)
            {
                ftimercounter -= Time.deltaTime;
                icounter = Mathf.RoundToInt(ftimercounter);
                TextTimerCounter.GetComponent<Text>().text = "Timer Countdown: " + icounter.ToString();
            }
            else if (ftimercounter <= 0 && startcount)
            {
                ftimercounter = 10;
                icounter = 10;
                startcount = false;
                rotate = false;
                TextTimerCounter.GetComponent<Text>().text = "Timer Countdown: " + icounter.ToString();
                PlaneBgo.GetComponent<Transform>().Rotate(0, 90, 0);

            }
        }
        totalcoinleft = GameObject.FindGameObjectsWithTag("coin").Length;
        if(totalcoinleft == 0)
        {
            Debug.Log("AllowPlaneB");
            coingone = true;
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
            TextTimerCounter.GetComponent<Text>().text = "Timer Countdown: " + icounter.ToString();
            Debug.Log("Acvtiavted PlaneB 90deg rotation");
            rotate = true;
            PlaneBgo.GetComponent<Transform>().Rotate(0, 90, 0);
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "coin")
        {      
            Destroy(other.gameObject);
        }
    }
}
