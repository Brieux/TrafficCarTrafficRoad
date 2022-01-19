using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public List<GameObject> Car;
    public float randomTime;
    public bool sens;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomTime -= Time.deltaTime;
        if (randomTime <= 0){
            GameObject oneCar =Instantiate(Car[Random.Range(0, 2)],this.transform) ;
            oneCar.GetComponent<Speed>().sens = sens;
            GameManager.Instance.allCars.Add(oneCar);
            randomTime = Random.Range(3f, 5f);
        }
    }
}
