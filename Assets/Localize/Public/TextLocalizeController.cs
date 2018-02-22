using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;
using Localize;

[ExecuteInEditMode]
[RequireComponent (typeof (Text))]
public class TextLocalizeController : MonoBehaviour, ILocalizeObserver
{
    [SerializeField]
    private string textName;
    private Text textCache;
    public void ChangeTextName (string textName)
    {
        this.textName = textName;
        ShowText ();
    }

    void Awake ()
    {
        ShowText ();
        textCache = GetComponent<Text> ();
    }

    void OnEnable ()
    {
        LocalizeManager.AddObserver (this);

    }
    void OnDisable ()
    {
        LocalizeManager.RemoveObserver (this);
    }

    private void ShowText ()
    {
        textCache.text = LocalizeFacade.GetText (textName);
    }

    public void OnUpdateLanguageSetting ()
    {
        ShowText ();
#if UNITY_EDITOR
        Selection.activeGameObject = gameObject;
        SceneView.FrameLastActiveSceneView ();
#endif
    }

#if UNITY_EDITOR
    void OnValidate ()
    {
        ShowText ();
    }
#endif
}
