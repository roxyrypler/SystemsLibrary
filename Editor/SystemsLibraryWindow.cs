using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace SystemsLibrary.Editor
{
    public class SystemsLibraryWindow : OdinMenuEditorWindow
    {
        [MenuItem("Systems Library/Systems Editor")]
        private static void OpenWindow()
        {
            GetWindow<SystemsLibraryWindow>().Show();
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            var tree = new OdinMenuTree();
            tree.Selection.SupportsMultiSelect = false;

            tree.Add("Services/Economy", new EconomyEditor());
            tree.Add("AI", new AIEditor());
            tree.Add("UI", new UIEditor());
            return tree;
        }
    }
}

