using Sirenix.OdinInspector;
using UnityEngine;

namespace Plugins.SystemsLibrary.Runtime.UI.UIComponents.scripts
{
    public abstract class CustomUIComponentBase: MonoBehaviour
    {
        public bool OverrideStyle;
        private void Awake()
        {
            Init();
        }
        
        public abstract void Setup();
        public abstract void Configure();

        [Button("Configure Now")]
        public void Init()
        {
            if (!OverrideStyle) return;
            Setup();
            Configure();
        }

        private void OnValidate()
        {
            if (!OverrideStyle) Init();
        }
    }
}