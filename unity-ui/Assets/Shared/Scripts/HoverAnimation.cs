using System.Collections;
using UnityEngine;

public class HoverAnimation : MonoBehaviour
{
    private Vector3 originalScale;
    public float scaleAmount = 1.1f; 
    public float lerpSpeed = 10f;

    void Start()
    {
        originalScale = transform.localScale; 
    }

    public void OnPointerEnter()
    {
        StopAllCoroutines(); 
        StartCoroutine(LerpScale(originalScale, originalScale * scaleAmount));

    }

    public void OnPointerExit()
    {
        StopAllCoroutines();
        StartCoroutine(LerpScale(transform.localScale, originalScale));
    }
    
    private IEnumerator LerpScale(Vector3 startScale, Vector3 endScale)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * lerpSpeed;
            transform.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return null;
        }
    }
}