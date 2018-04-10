using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(GameContext))]
public class GameContextInspector : Editor
{
    ReorderableList reorderableList;

    void OnEnable()
    {
        reorderableList = new ReorderableList(serializedObject, serializedObject.FindProperty("missions"));

        //绘制元素
        var prop = serializedObject.FindProperty("missions");

        reorderableList = new ReorderableList(serializedObject, prop);

        //绘制按钮
        reorderableList.drawElementBackgroundCallback = (rect, index, isActive, isFocused) =>
        {
            if (Event.current.type == EventType.Repaint)
            {
                rect.xMin += 2;
                rect.xMax -= 2;
                EditorStyles.miniButton.Draw(rect, false, isActive, isFocused, false);
            }
        };

        //绘制文本框
        reorderableList.drawElementCallback = (rect, index, isActive, isFocused) =>
        {
            var element = prop.GetArrayElementAtIndex(index);
            rect.height -= 4;
            rect.y += 2;
            EditorGUI.PropertyField(rect, element);
        };

        reorderableList.onAddCallback += (list) =>
        {

            //添加元素
            prop.arraySize++;

            //选择状态设置为最后一个元素
            list.index = prop.arraySize - 1;

            //新元素添加默认字符串
            var element = prop.GetArrayElementAtIndex(list.index);
            element.stringValue = "New String " + list.index;
        };

        //AddMenue();

        reorderableList.onReorderCallback = (list) =>
        {
            //元素更新
            Debug.Log("onReorderCallback");
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        reorderableList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }


    void AddMenue()
    {
        reorderableList.onAddDropdownCallback = (Rect buttonRect, ReorderableList list) =>
        {
            var menu = new GenericMenu();
            menu.AddItem(new GUIContent("Example 1"), true, () =>
            {
            });
            menu.AddSeparator("");
            menu.AddDisabledItem(new GUIContent("Example 2"));
            menu.DropDown(buttonRect);
        };
    }
}