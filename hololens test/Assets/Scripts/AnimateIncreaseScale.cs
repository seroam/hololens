using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateIncreaseScale : MonoBehaviour
{
    Vector3 initialScale;
    Vector3 scaleDelta = new Vector3(0.0035f, 0.0035f, 0.0035f);
    const float maxScaleFactor = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.localScale.x < initialScale.x * maxScaleFactor ? transform.localScale + scaleDelta : initialScale;
        /*if (transform.localScale.x < initialScale.x*maxScaleFactor){
            transform.localScale += scaleDelta;
		}
        else {
            transform.localScale = initialScale;
		}*/
    }
}
