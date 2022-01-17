using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public List<GameObject> Car;
    public float randomTime;
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
            GameManager.Instance.allCars.Add(oneCar);
            randomTime = Random.Range(1.5f, 4);
        }
    }
}
