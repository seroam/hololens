using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animations : MonoBehaviour
{
    private bool animating = false;
    Vector3 initialPosition;
    public void Drop(){
        if (!animating){
            initialPosition = gameObject.transform.position;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            animating = true;
            Button[] texts = GetComponentsInChildren<Button>();

            SetButtonText("Stop animation");

        }
        else {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.position = initialPosition;
            animating = false;

            SetButtonText("Animate");
		}
	}

    public void FreakOut(){
        if (!animating){
            Animator animator = gameObject.GetComponent<Animator>();

            Debug.Log("animating");
		}

	}

    private void SetButtonText(string s){
        GameObject button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Text text = button.GetComponentInChildren<Text>();
        if (text != null) {
            text.text = s;
        }
    }
}
