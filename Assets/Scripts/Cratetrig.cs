using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBrotate : MonoBehaviour
{
    bool rotate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            rotate = true;
        }
    }

}
