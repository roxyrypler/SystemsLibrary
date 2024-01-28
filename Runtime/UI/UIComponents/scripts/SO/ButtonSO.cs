using TMPro;
using UnityEngine;

namespace Plugins.SystemsLibrary.Runtime.UI.UIComponents.scripts.SO
{
    [CreateAssetMenu(menuName = "CustomUI/ButtonSO", fileName = "Button")]
    public class ButtonSO: ScriptableObject
    {
        public ThemeSO theme;
        public TMP_FontAsset font;
        public float size;
    }
}