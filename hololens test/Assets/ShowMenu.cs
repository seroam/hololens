using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Toggle(Collider collider, bool b) {
        collider.gameObject.SetActive(b);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
