using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomTexte : MonoBehaviour
{
    public List<string> mots;
    public TextMeshPro zone;
    public TextMeshPro zone2;

    // Start is called before the first frame update
    void Start()
    {
        zone.text = mots[Random.Range(0, mots.Count)];
        zone2.text = zone.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
