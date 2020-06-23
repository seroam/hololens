using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLevel : MonoBehaviour
{
    public GameObject lanePrefab;
    private GameObject current;


    // Start is called before the first frame update
    void Start()
    {
        current =  Instantiate(lanePrefab, transform);

       // Destroy(current);
    }

    public void Reset(){
        Destroy(current);
        Start();
	}
}
