using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;
using Localize;

[ExecuteInEditMode]
[RequireComponent (typeof (TextMesh))]
public class TextMeshLocalizeController : MonoBehaviour, ILocalizeObserver
{
    [SerializeField]
    private string textName;
    private TextMesh textMeshCache;
    public void ChangeTextName (string textName)
    {
        this.textName = textName;
        ShowText ();
    }

    void Awake ()
    {
        ShowText ();
    }

    private TextMesh GetText ()
    {
        if (textMeshCache == null) {
            textMeshCache = GetComponent<TextMesh> ();
        }
        return textMeshCache;
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
        GetText ().text = LocalizeFacade.GetText (textName);
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
