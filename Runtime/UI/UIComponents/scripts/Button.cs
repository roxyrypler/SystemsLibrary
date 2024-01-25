using System;
using Plugins.SystemsLibrary.Runtime.Types.ScriptableObjects.Events;
using Plugins.SystemsLibrary.Runtime.UI.UIComponents.scripts.SO;
using UnityEngine;

namespace Plugins.SystemsLibrary.Runtime.UI.UIComponents.scripts
{
    public class Button: CustomUIComponentBase
    {
        public ButtonSO buttonData;
        public GameEvent OnClickedEvent;
        public UnityEngine.UI.Button ButtonElem;

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
            
        }
    }
}