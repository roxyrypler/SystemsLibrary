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

            tree.Add("Economy", new EconomyInternal());
            return tree;
        }
    }
}

