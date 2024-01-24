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

    [Header("Other")] public Color disable;
}
