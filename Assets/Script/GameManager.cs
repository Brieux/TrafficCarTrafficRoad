using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] Image Menu;
    [SerializeField] Image MenuEnd;

    public static GameManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton(Image img)
    {
        img.gameObject.SetActive(false);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void End()
    {
        MenuEnd.gameObject.SetActive(true);
        MenuEnd.GetComponent<Animator>().SetTrigger("end");
    }

    private void Awake()
    {
        Instance = this;
    }
}
