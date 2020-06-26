using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLevel : MonoBehaviour
{
    public GameObject lanePrefab;
    public static GameObject current = null;

    // Start is called before the first frame update
    void Start()
    {
        current =  Instantiate(lanePrefab, transform);

        current.GetComponent<CanvasGroup>().alpha = 0.2f;

        current.GetComponent<LookAtCamera>().enabled = true;

        Interactable lane = current.AddComponent<Interactable>();
        lane.OnClick.AddListener(() => PlaceLane.Place());

       // Destroy(current);
    }

    public void Reset(){
        Destroy(current);
        //current = Instantiate(lanePrefab, transform);
        Transform currentTransform = current.transform;
        current = Instantiate(lanePrefab, currentTransform.position, currentTransform.rotation, transform);
        ;
	}
}
