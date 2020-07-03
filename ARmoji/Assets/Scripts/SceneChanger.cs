using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    private string sceneToLoad;

    [SerializeField]
    private Animator animator;

    [Serializable]
    struct Connection {
        public string scene;
        public Interactable interactable;
	}

    [SerializeField]
    private Connection[] connections;
    

    void Start() {
        if (connections.Length == 0) {
            Debug.LogWarning($"No connections set on {name}. Scene change will not happen.");
            return;
        }


        foreach ( var connection in connections){
            connection.interactable.OnClick.AddListener(() => FadeToScene(connection.scene));
		}
        /*
        for (var i = 0;
            interactable.OnClick.AddListener(() => {
                FadeToScene(sceneName);
            });
        }*/
    }


    public void FadeToScene(string name){
        sceneToLoad = name;
        animator.SetTrigger("FadeOut");
	}

    public void OnFadeComplete(){
        SceneManager.LoadScene(sceneToLoad);
	}
}
