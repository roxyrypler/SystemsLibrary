using Plugins.SystemsLibrary.Runtime.UI.Types.Enums;
using Plugins.SystemsLibrary.Runtime.UI.UIComponents.scripts;
using TMPro;

public class Text : CustomUIComponentBase
{
    public TextSO textData;
    public EThemeStyleSelector style;

    private TextMeshProUGUI textMeshProGui;
    
    public override void Setup()
    {
        textMeshProGui = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public override void Configure()
    {
        textMeshProGui.color = textData.theme.GetTextColor(style);
        textMeshProGui.font = textData.font;
        textMeshProGui.fontSize = textData.size;
    }
}
