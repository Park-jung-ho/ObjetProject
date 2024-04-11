using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;


public class ChangeFont : EditorWindow
{
    TMP_FontAsset selectedFont;
    [MenuItem("Tools/ChangeFont")]
    public static void ShowEditorWindow()
    {
        ChangeFont w = GetWindow<ChangeFont>(false, "UI Font Changer", true);
        w.minSize = new Vector2(200, 110);
        w.maxSize = new Vector2(200, 110);   
    }

    public void OnGUI()
    {
        EditorGUILayout.LabelField("Font: ", selectedFont?.name ?? "None");

        SelectFontButton();
        OnSelectorClosed();

        ChangeAllFontsButton();
    }
    public void SelectFontButton()
    {
        EditorGUILayout.Space();
        if (GUILayout.Button("Select Font"))
        {
            EditorGUIUtility.ShowObjectPicker<TMP_FontAsset>(selectedFont, true, "", GUIUtility.GetControlID(FocusType.Passive) + 100);
        }
    }

    public void OnSelectorClosed()
    {        
        EditorGUILayout.Space();

        if (Event.current.commandName == "ObjectSelectorClosed")
        {
            if (EditorGUIUtility.GetObjectPickerObject() != null)
            {
                selectedFont = (TMP_FontAsset)EditorGUIUtility.GetObjectPickerObject();
            }
        }
    }

    public void ChangeAllFontsButton()
    {
        EditorGUILayout.Space();

        if (GUILayout.Button("Change All Fonts In Scene"))
        {
            ChangeAllFonts();
            SceneView.lastActiveSceneView.Repaint();
            UnityEditorInternal.InternalEditorUtility.RepaintAllViews();
        }
    }

    public void ChangeAllFonts()
    {
        var textCount = 0;
        var fontChangedCount = 0;

        var allTextObjects = Resources.FindObjectsOfTypeAll(typeof(TMP_Text));

        foreach (TMP_Text t in allTextObjects)
        {
            textCount++;

            if (t.font != selectedFont)
            {
                fontChangedCount++;
                t.font = selectedFont;
            }
        }
        Debug.Log(string.Format("찾은 텍스트 UI {0}개 중 {1}개 변경", textCount, fontChangedCount));
        EditorUtility.DisplayDialog("폰트 변경 완료", 
        string.Format("찾은 텍스트 UI {0}개 중 {1}개를 변경했습니다!", textCount, fontChangedCount), 
        "확인");
    }
}

