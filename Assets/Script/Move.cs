using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Animator Animation;
    public float speed;
    public float ratio;
    public Vector3 InitPos;
    public Quaternion InitRot;
    public bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        InitPos = transform.localPosition;
        InitRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && GameManager.Instance.state == 0)
        {
            if (once)
            {
                Animation.SetTrigger("OpenCar");
                once = false;
            }
            if (speed < 0.4)
            {
                speed += 0.001f * ratio * Time.deltaTime; 
            }
            else
            {
                speed = 0.4f * ratio * Time.deltaTime;
            }
        }
        if (!Input.GetMouseButton(0))
        {
            if (!once)
            {
                Animation.SetTrigger("CloseCar");
                once = true;
            }
            if (speed > 0)
            {
                speed -= 0.005f * ratio * Time.deltaTime;
            }
            else
            {
                speed = 0 * ratio * Time.deltaTime;
            }
        }
        Animation.SetFloat("Multiplier", speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cars" && GameManager.Instance.state != 1)
        {
            GetComponent<Animator>().SetTrigger("impact");
            GameManager.Instance.state = 1;
            Debug.Log("GameOver");
            StartCoroutine(GameManager.Instance.EndCoroutine());
        }

        if (collision.gameObject.tag == "End")
        {
            Debug.Log("End");
            collision.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            GameManager.Instance.newLevel(1);
        }
    }

    public void playerReset()
    {
        transform.localPosition = InitPos;
        transform.localRotation = InitRot;
        Animation.Play("MoveCar", -1, 0);
    }
}
