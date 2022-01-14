using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public GameObject Conv;
    private bool boolSign;
    // Start is called before the first frame update
    void Start()
    {
        Conv.SetActive(false);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 15f);  
        if (Random.Range(0,3) == 1)
        {
            boolSign = true;
        }
        else
        {
            boolSign = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if ((other.gameObject.tag == "Player") && boolSign)
        {
            Conv.SetActive(true);

        }
    }

}
