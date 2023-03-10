using System.Collections;
using Localization;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    private bool _active = false;
    // private string PrefabsLocaleKey { get; } = "LocaleKey";
    private Locale CurrentLocale { get; set; }

    private void Start()
    {
        CurrentLocale = Locale.English;
        ChangeLocale(CurrentLocale);
    }

    public void ChangeLocale()
    {
        if (CurrentLocale == Locale.English)
        {
            ChangeLocale(Locale.Ukrainian);
        }
        else
        {
            ChangeLocale(Locale.English);
        }
    }
    private void ChangeLocale(Locale locale)
    {
        if (_active)
            return;
        StartCoroutine(SetLocale(locale));
    }
    
    /* Saving user locale settings logic*/
    // private Locale GetPrefabsLocale()
    // {
    //     return (Locale)PlayerPrefs.GetInt(PrefabsLocaleKey, 0);
    // }
    //
    // private void SetPrefabsLocale(Locale locale)
    // {
    //     PlayerPrefs.SetInt(PrefabsLocaleKey, (int)locale);
    // }

    IEnumerator SetLocale(Locale locale)
    {
        _active = true;
        
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[(int)locale];

        CurrentLocale = locale;
        //SetPrefabsLocale(locale);
        
        _active = false;
    }
}
