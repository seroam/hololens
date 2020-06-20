using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Interactable interactable = null;
    [SerializeField]
    private string sceneName = "";

    // Start is called before the first frame update
    void Start()
    {
        if (interactable == null){
            Debug.LogWarning($"No interactable set on {name}. Scene change will not happen.");
            return;
		}

        interactable.OnClick.AddListener(() => {
            FadeToScene(sceneName);
        });
    }


    public void FadeToScene(string sceneName){
        animator.SetTrigger("FadeOut");
	}

    public void OnFadeComplete(){
        SceneManager.LoadScene(sceneName);
	}
}
