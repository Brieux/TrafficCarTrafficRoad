using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarquerUnPoint : MonoBehaviour
{
    public ParticleSystem NS;
    public int NumAnimToPlay;
    public bool activated = false;
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
                if (gameObject.tag == "End")
                {
                    GameManager.Instance.newLevel(1);
                }
                Debug.Log("Salut");
                other.gameObject.GetComponent<Score>().Marquer();
                NS.Play();
                switch (NumAnimToPlay)
                {
                    case 1:
                        other.gameObject.GetComponent<Animator>().SetTrigger("PlayAnim1");
                        break;

                    case 2:
                        other.gameObject.GetComponent<Animator>().SetTrigger("PlayAnim2");
                        break;
                    case 3:
                        other.gameObject.GetComponent<Animator>().SetTrigger("PlayAnim3");
                        break;
                    default:
                        other.gameObject.GetComponent<Animator>().SetTrigger("PlayAnim1");
                        break;

                }
            }
        }
        activated = true;
    }
}
