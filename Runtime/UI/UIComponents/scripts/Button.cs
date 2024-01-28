using Plugins.SystemsLibrary.Runtime.Types.ScriptableObjects.Events;
using Plugins.SystemsLibrary.Runtime.UI.Types.Enums;
using Plugins.SystemsLibrary.Runtime.UI.UIComponents.scripts.SO;
using TMPro;
using UnityEngine.UI;

namespace Plugins.SystemsLibrary.Runtime.UI.UIComponents.scripts
{
    public class Button: CustomUIComponentBase
    {
        public ButtonSO buttonData;
        public EThemeStyleSelector style;
        public GameEvent OnClickedEvent;
        public UnityEngine.UI.Button ButtonElem;
        public Image ButtonBG;
        public TextMeshProUGUI textMeshProGui;

        private void Start()
        {
            ButtonElem.onClick.AddListener(() =>
            {
                OnClickedEvent.Raise();
            });
        }

        public override void Setup()
        {
            
        }
    
        public override void Configure()
        {
            textMeshProGui.font = buttonData.theme.GetFont(style);
            textMeshProGui.color = buttonData.theme.GetTextColor(style);
            textMeshProGui.fontSize = buttonData.size;
            ButtonBG.color = buttonData.theme.GetBackgroundColor(style);
        }
    }
}