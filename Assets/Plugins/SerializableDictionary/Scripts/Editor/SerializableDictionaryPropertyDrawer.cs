using UnityEditor;
using UnityEngine;

namespace SerializableDictionary
{
    // original code from: https://github.com/upscalebaby/generic-serializable-dictionary

    /// <summary>
    /// Draws the generic dictionary a bit nicer than Unity would natively (not as many expand-arrows
    /// and better spacing between KeyValue pairs). Also renders a warning-box if there are duplicate
    /// keys in the dictionary.
    /// </summary>
    // [CustomPropertyDrawer(typeof(SerializableDictionary<,>))]
    public class SerializableDictionaryPropertyDrawer : PropertyDrawer
    {
        private const string ListRelativePropertyPath = "_listContent";
        private const string KeyCollisionRelativePropertyPath = "_keyCollision";

        private static readonly float _lineHeight = EditorGUIUtility.singleLineHeight;
        private static readonly float _vertSpace = EditorGUIUtility.standardVerticalSpacing;

        private SerializedProperty _listProperty;
        private SerializedProperty _keyCollisionProperty;

        public override void OnGUI(
            Rect pos, SerializedProperty property, GUIContent label)
        {
            _listProperty = GetListProperty(property);
            _keyCollisionProperty = GetKeyCollisionProperty(property);

            Rect currentPos = DrawList(pos);
            DrawKeyCollisionWarning(pos, currentPos);
        }

        public override float GetPropertyHeight(
            SerializedProperty property, GUIContent label)
        {
            SerializedProperty listProperty = GetListProperty(property);
            SerializedProperty keyCollisionProperty = GetKeyCollisionProperty(property);
            float totHeight = 0f;

            totHeight += EditorGUI.GetPropertyHeight(listProperty, true);

            if (keyCollisionProperty.boolValue)
            {
                totHeight += _lineHeight * 2f + _vertSpace;
            }

            return totHeight;
        }

        
        private static SerializedProperty GetListProperty(SerializedProperty property)
        {
            return property.FindPropertyRelative(ListRelativePropertyPath);
        }

        private static SerializedProperty GetKeyCollisionProperty(SerializedProperty property)
        {
            return property.FindPropertyRelative(KeyCollisionRelativePropertyPath);
        }

        private void DrawKeyCollisionWarning(Rect pos, Rect currentPos)
        {
            if (!_keyCollisionProperty.boolValue)
            {
                return;
            }

            currentPos.y += EditorGUI.GetPropertyHeight(_listProperty, true) + _vertSpace;
            Rect entryPos = new Rect(_lineHeight, currentPos.y, pos.width, _lineHeight * 2f);
            EditorGUI.HelpBox(entryPos, "Duplicate keys will not be serialized.", MessageType.Warning);
        }

        private Rect DrawList(Rect pos)
        {
            string fieldName = ObjectNames.NicifyVariableName(fieldInfo.Name);
            pos = new Rect(_lineHeight, pos.y, pos.width, _lineHeight);
            EditorGUI.PropertyField(pos, _listProperty, new GUIContent(fieldName), true);

            return pos;
        }
    }
}