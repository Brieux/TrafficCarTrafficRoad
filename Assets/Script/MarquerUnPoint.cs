using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarquerUnPoint : MonoBehaviour
{
    public ParticleSystem NS;
    public int NumAnimToPlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Salut");
            other.gameObject.GetComponent<Score>().Marquer();
            NS.Play();
            switch (NumAnimToPlay)
            {
                case 1:
                    other.gameObject.GetComponent<Animator>().SetTrigger("PlayAnim1");
                    break;
                default:
                    other.gameObject.GetComponent<Animator>().SetTrigger("PlayAnim1");
                    break;

            }
        }
    }
}
