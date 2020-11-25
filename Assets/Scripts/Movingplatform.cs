using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingplatform : MonoBehaviour
{
    float moveSpeed = 5.0f;
    float zupperlimit = 37.5f;
    float zlowerlimit = 27.5f;
    bool ismovefwd = false;
    bool ismoveback = true;
    public GameObject Player;
    bool move = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            if (ismoveback && !ismovefwd)
            {
                if (transform.position.z >= zlowerlimit)
                {
                    transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
                }
                else
                {
                    ismoveback = !ismoveback;
                    ismovefwd = !ismovefwd;
                }
            }
            if (ismovefwd && !ismoveback)
            {
                if (transform.position.z <= zupperlimit)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
                }
                else
                {
                    ismoveback = !ismoveback;
                    ismovefwd = !ismovefwd;
                }
            }
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            move = true;
        }

        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
