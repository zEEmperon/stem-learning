using UnityEngine;
using UnityEngine.UI;

public class LocaleController : MonoBehaviour
{
    [SerializeField] private GameObject imageHolder;
    [SerializeField] private Sprite ukrFlagSprite;
    [SerializeField] private Sprite gbFlagSprite;

    private bool isUkrainian;

    private void Start()
    {
        isUkrainian = false;
        SetFlagImage(gbFlagSprite);
        
    }

    public void ChangeLocale()
    {
        isUkrainian = !isUkrainian;
        if (isUkrainian) SetFlagImage(ukrFlagSprite);
        else SetFlagImage(gbFlagSprite);
    }

    private void SetFlagImage(Sprite sprite)
    {
        imageHolder.GetComponent<Image>().sprite = sprite;
    }
}
