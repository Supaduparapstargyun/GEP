using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundmovement : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()       
    {
        transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
        if (transform.position.z < -10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 10);
        }
    }
}
