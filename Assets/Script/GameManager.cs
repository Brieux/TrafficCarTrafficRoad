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
    public List<GameObject> allCars;
    public int levelNum;
    public GameObject spawneer;

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
        switch (levelNum)
        {
            case 1:
                player.GetComponent<Animator>().SetTrigger("PlayAnim1");
                break;
            default:
                player.GetComponent<Animator>().SetTrigger("PlayAnim1");
                break;

        }
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void CrediterLeJeu()
    {

    }
    public void Replay()
    {
        MenuEnd.gameObject.SetActive(false);
        foreach(GameObject car in allCars)
        {
            Destroy(car);
        }
        allCars.Clear();
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

    public IEnumerator EndCoroutine()
    {
        Debug.Log("gameover");
        yield return new WaitForSeconds(1.1f);
        state = 1;
        MenuEnd.gameObject.SetActive(true);
        MenuEnd.GetComponent<Animator>().SetTrigger("end");
    }

    public void newLevel(int numLevel)
    {
        Debug.Log("Le level est chargé" + numLevel);
        player.transform.localPosition = spawneer.transform.position;

        if (numLevel == 1)
        {
            player.GetComponent<Animator>().SetTrigger("PlayAnim2");
            player.GetComponent<Move>().ratio *= 3;
        }
    }
}
