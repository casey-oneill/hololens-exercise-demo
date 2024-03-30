using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgessIndicatorController : MonoBehaviour
{

    public SpriteRenderer Renderer;

    private float t = 0;

    private float value;
    private float targetValue;

    public void SetIndicatorValue(float newValue)
    {
        this.targetValue = newValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        value = 360f;
        targetValue = 360f;
  
        Renderer.sharedMaterial.SetFloat("_Arc2", 360f);
    }

    // Update is called once per frame
    void Update()
    {
        if (value != targetValue)
        {
            value = Mathf.Lerp(value, targetValue, t);
            t += 0.5f * Time.deltaTime;
        }
        else
        {
            t = 0; // Reset interpolator
        }

        // Update UI
        Renderer.sharedMaterial.SetFloat("_Arc2", value);
    }
}
