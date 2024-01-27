using Plugins.SystemsLibrary.Runtime.UI.Types.Enums;
using UnityEngine;

[CreateAssetMenu(menuName = "CustomUI/ThemeSO", fileName = "ThemeSO")]
public class ThemeSO : ScriptableObject
{
    [Header("Primary")] 
    public Color Primary_bg;
    public Color Primary_text;
    
    [Header("Secondary")] 
    public Color Secondary_bg;
    public Color Secondary_text;
    
    [Header("Tirtiary")] 
    public Color Tirtiary_bg;
    public Color Tirtiary_text;

    [Header("CallToAction")] 
    public Color CallToAction_bg;
    public Color CallToAction_text;

    [Header("Other")] public Color disable;

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
