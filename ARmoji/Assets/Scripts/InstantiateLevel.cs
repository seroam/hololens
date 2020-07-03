using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLevel : MonoBehaviour
{
    public GameObject lanePrefab;
    public static GameObject current = null;

    public static GameObject ball = null;


    // Start is called before the first frame update
    void Start()
    {
        current =  Instantiate(lanePrefab, transform);

        current.GetComponent<CanvasGroup>().alpha = 0.2f;

        current.GetComponent<LookAtCamera>().enabled = true;

        current.GetComponent<BoxCollider>().enabled = true;
        Interactable lane = current.AddComponent<Interactable>();
        DisablePinPhysics();

        lane.OnClick.AddListener(() => PlaceLane.Place());


       // Destroy(current);
    }

    public void Reset(){
        Destroy(current);

        Transform currentTransform = current.transform;
        current = Instantiate(lanePrefab, currentTransform.position, currentTransform.rotation, transform);
	}

    public static void DisablePinPhysics(){
        foreach (var r in current.GetComponentsInChildren<Rigidbody>()){
            r.isKinematic = true;
		}
	}

    public static void EnablePinPhysics() {
        foreach (var r in current.GetComponentsInChildren<Rigidbody>()) {
            r.isKinematic = false;
        }
    }
}
