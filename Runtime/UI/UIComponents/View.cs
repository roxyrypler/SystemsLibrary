using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class View : MonoBehaviour
{
    public ViewSO viewData;

    public GameObject containerTop;
    public GameObject containerCenter;
    public GameObject containerBottom;

    private Image imageTop;
    private Image imageCenter;
    private Image imageBottom;

    private VerticalLayoutGroup verticalLayoutGroup;

    private void Awake()
    {
        Init();
    }

    [Button("Configure Now")]
    public void Init()
    {
        Setup();
        Configure();
    }
    
    public void Setup()
    {
        verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
        imageTop = containerTop.GetComponent<Image>();
        imageCenter = containerCenter.GetComponent<Image>();
        imageBottom = containerBottom.GetComponent<Image>();
    }
    
    public void Configure()
    {
        verticalLayoutGroup.padding = viewData.padding;
        verticalLayoutGroup.spacing = viewData.spacing;
    }

    private void OnValidate()
    {
        Init();
    }
}
