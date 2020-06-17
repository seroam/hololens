using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animations : MonoBehaviour
{
    private bool bouncing = false;
    Vector3 initialPosition;
    public void Drop(){
        if (!bouncing){
            initialPosition = gameObject.transform.position;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            bouncing = true;
            Button[] texts = GetComponentsInChildren<Button>();
            Debug.Log("foo");

        }
        else {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.position = initialPosition;
            bouncing = false;
		}
	}
}
