using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarquerUnPoint : MonoBehaviour
{
    public ParticleSystem NS;
    public bool activated = false;
    public bool fin = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated)
        {
            GetComponent<BoxCollider>().enabled = !GetComponent<BoxCollider>().enabled;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!activated)
        {
            if (other.gameObject.tag == "Player")
            {
                if (fin)
                {
                    Debug.Log("efdf");
                    GameManager.Instance.newLevel(1);
                }
                Debug.Log("Salut");
                other.gameObject.GetComponent<Score>().Marquer();
                NS.Play();
                activated = true;
            }
        }
    }
}
