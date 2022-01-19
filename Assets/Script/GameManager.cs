using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
    public GameObject player2;
    public GameObject target;
    public GameObject target0;
    public GameObject maintarget;
    public GameObject menuplay;
    public GameObject menuplay1;
    public GameObject menuplay2;
    public GameObject menuplay3;
    public GameObject menuCredit;
    public GameObject menuendgame;

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
                maintarget = target;
                //player.GetComponent<Animator>().SetTrigger("PlayAnim1");
                break;
            default:
                maintarget = target0;
                //player.GetComponent<Animator>().SetTrigger("PlayAnim1");
                break;

        }
        player.GetComponent<Move>().demarrer();
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void CrediterLeJeu()
    {
        menuCredit.SetActive(!menuCredit.activeInHierarchy);
        menuplay.SetActive(!menuplay.activeInHierarchy);
        menuplay1.SetActive(!menuplay1.activeInHierarchy);
        menuplay2.SetActive(!menuplay2.activeInHierarchy);
        menuplay3.SetActive(!menuplay3.activeInHierarchy);
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
        player.GetComponent<NavMeshAgent>().enabled = false;
        player.transform.localPosition = spawneer.transform.position;
        player.GetComponent<NavMeshAgent>().enabled = true;
        player.GetComponent<Move>().demarrer();
        player.transform.localScale *= 1f;
        player.GetComponent<Move>().rapidity *= 1.2f;
        player.GetComponent<NavMeshAgent>().acceleration = 150;
        player.GetComponent<NavMeshAgent>().destination = target.transform.position;
    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
