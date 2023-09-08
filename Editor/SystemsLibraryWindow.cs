using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using Sirenix.OdinInspector;
using SystemsLibrary;

public class SystemsLibraryWindow : OdinMenuEditorWindow
{
    [MenuItem("Systems Library/My Window")]
    private static void OpenWindow()
    {
        GetWindow<SystemsLibraryWindow>().Show();
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();
        tree.Selection.SupportsMultiSelect = false;

        tree.Add("Economy", new EconomyInternal());
        //tree.Add("Settings", GeneralDrawerConfig.Instance);
        //tree.Add("Utilities", new TextureUtilityEditor());
        //tree.AddAllAssetsAtPath("Odin Settings", "Assets/Plugins/Sirenix", typeof(ScriptableObject), true, true);
        return tree;
    }
}

public class TextureUtilityEditor
{
    [BoxGroup("Tool"), HideLabel, EnumToggleButtons]
    public Tool Tool;

    public List<Texture> Textures;

    [Button(ButtonSizes.Large), HideIf("Tool", Tool.Rotate)]
    public void SomeAction() { }

    [Button(ButtonSizes.Large), ShowIf("Tool", Tool.Rotate)]
    public void SomeOtherAction() { }
}

