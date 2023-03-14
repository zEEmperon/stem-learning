using System.Collections;
using UnityEngine;

public class HoverAnimation : MonoBehaviour
{
    [SerializeField] private float scaleAmount = 1.1f; 
    [SerializeField] private float lerpSpeed = 10f;
    
    private Vector3 _originalScale;

    void Start()
    {
        _originalScale = transform.localScale; 
    }

    public void OnPointerEnter()
    {
        StopAllCoroutines(); 
        StartCoroutine(LerpScale(_originalScale, _originalScale * scaleAmount));

    }

    public void OnPointerExit()
    {
        StopAllCoroutines();
        StartCoroutine(LerpScale(transform.localScale, _originalScale));
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