using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Animator Animation;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (speed < 0.4)
            {
                speed += 0.001f; 
            }
            else
            {
                speed = 0.4f;
            }
        }
        if (!Input.GetMouseButton(0))
        {
            if (speed > 0)
            {
                speed -= 0.005f;
            }
            else
            {
                speed = 0;
            }
        }
        Animation.SetFloat("Multiplier", speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cars")
        {
            Debug.Log("GameOver");
        }
    }
}
