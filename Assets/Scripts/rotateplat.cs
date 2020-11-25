using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateplat : MonoBehaviour
{
    int coincount = 0;
    int cointotal;
    int TotalTimer;

    bool Rotatetrig = false;
    bool rotated = false;
    float totaltime = 10;
    float currenttime = 0;
    public GameObject Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer.GetComponent<Text>().text = "Timer: 10";
    }

    // Update is called once per frame
    void Update()
    {
        cointotal = GameObject.FindGameObjectsWithTag("coin").Length;

        if(Rotatetrig == true && rotated == true)
        {
            currenttime = Time.deltaTime;
            totaltime -= currenttime;
            TotalTimer = (int)totaltime;

            Timer.GetComponent<Text>().text = "Timer: " + TotalTimer;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (TotalTimer == 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            totaltime = 10f;
            rotated = false;
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && cointotal == coincount)
        {
            Rotatetrig = true;
            rotated = true;
        }
    }
}
