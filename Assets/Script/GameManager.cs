using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] Image Menu;
    [SerializeField] Image MenuEnd;
    public int state;
    public GameObject player;

    public static GameManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        state = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton(Image img)
    {
        img.gameObject.SetActive(false);
        state = 0;
    }

    public void Replay()
    {
        MenuEnd.gameObject.SetActive(false);
        player.GetComponent<Score>().resetScore();
        player.GetComponent<Move>().playerReset();
        state = 0;
    }

    public void End()
    {
        state = 1;
        MenuEnd.gameObject.SetActive(true);
        MenuEnd.GetComponent<Animator>().SetTrigger("end");
    }

    private void Awake()
    {
        Instance = this;
    }
}
