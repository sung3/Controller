
using System.IO;
using UnityEngine;
using UnityEditor;

public class Test : EditorWindow
{
    [MenuItem("Tools/Test")]
    public static void CreateWindow()
    {
        EditorWindow editorWindow = GetWindow(typeof(Test));
        editorWindow.minSize = new Vector2(700, 500);
    }

    private static string folderPath = "";
    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        {
            EditorGUILayout.Space();
            GUILayout.Label("文件夹路径（支持拖拽到文本框）");
            var rect1 = EditorGUILayout.GetControlRect(GUILayout.Width(700), GUILayout.Height(20));
            if ((Event.current.type == EventType.DragUpdated || Event.current.type == EventType.DragExited) 
                && rect1.Contains(Event.current.mousePosition))
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)
                {
                    folderPath = DragAndDrop.paths[0];
                }
            }
            EditorGUI.TextField(rect1, folderPath);
            
            EditorGUILayout.Space();
            if (GUILayout.Button("执行", GUILayout.Width(700f)))
            {
                OnButtonClick();
            }
        }
        EditorGUILayout.EndVertical();
    }

    private void OnButtonClick()
    {
        string[] guids = AssetDatabase.FindAssets("t:Model", new string[] {folderPath});
        for (int index = 0; index < guids.Length; ++index)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[index]);

            if (!path.Contains("_Root"))
            {
                string rootFBXPath = path.Replace(".FBX", "_Root.FBX");
                if (File.Exists(rootFBXPath))
                {
                    File.Delete(path);
                }
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
