using Plugins.SystemsLibrary.Runtime.UI.Types.Enums;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "CustomUI/ThemeSO", fileName = "ThemeSO")]
public class ThemeSO : ScriptableObject
{
    [Header("Primary")] 
    public Color Primary_bg;
    public Color Primary_text;
    public TMP_FontAsset Primary_font;
    
    [Header("Secondary")] 
    public Color Secondary_bg;
    public Color Secondary_text;
    public TMP_FontAsset Secondary_font;
    
    [Header("Tertiary")]
    public Color Tirtiary_bg;
    public Color Tirtiary_text;
    public TMP_FontAsset Tirtiary_font;

    [Header("CallToAction")] 
    public Color CallToAction_bg;
    public Color CallToAction_text;
    public TMP_FontAsset CallToActin_font;

    [Header("Other")] public Color disable;

    public TMP_FontAsset GetFont(EThemeStyleSelector style)
    {
        TMP_FontAsset _font = null;
        switch (style)
        {
            case EThemeStyleSelector.Primary:
                _font = Primary_font;
                break;
            case EThemeStyleSelector.Secondary:
                _font = Secondary_font;
                break;
            case EThemeStyleSelector.Tertiary:
                _font = Tirtiary_font;
                break;
            case EThemeStyleSelector.CallToAction:
                _font = CallToActin_font;
                break;
        }
        return _font;
    }
    
    public Color GetBackgroundColor(EThemeStyleSelector style)
    {
        Color _color = Color.white;
        switch (style)
        {
            case EThemeStyleSelector.Primary:
                _color = Primary_bg;
                break;
            case EThemeStyleSelector.Secondary:
                _color = Secondary_bg;
                break;
            case EThemeStyleSelector.Tertiary:
                _color = Tirtiary_bg;
                break;
            case EThemeStyleSelector.CallToAction:
                _color = CallToAction_bg;
                break;
        }
        return _color;
    }
    
    public Color GetTextColor(EThemeStyleSelector style)
    {
        Color _color = Color.white;
        switch (style)
        {
            case EThemeStyleSelector.Primary:
                _color = Primary_text;
                break;
            case EThemeStyleSelector.Secondary:
                _color = Secondary_text;
                break;
            case EThemeStyleSelector.Tertiary:
                _color = Tirtiary_text;
                break;
            case EThemeStyleSelector.CallToAction:
                _color = CallToAction_text;
                break;
        }
        return _color;
    }
}
