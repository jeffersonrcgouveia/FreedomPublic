#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace Freedom.Characters.Attributes.Editor
{
	[CustomEditor(typeof(CharacterHealth))]
	public class CharacterHealthEditor : UnityEditor.Editor
	{
		const string AddHealthButton = "Add 8 Health";
		const string SubtractHealthButton = "Subtract 8 Health";

		const int DefaultChangeAmount = 8;
		const float SpaceAmount = 5;

		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			CharacterHealth characterHealth = (CharacterHealth) target;
			GUILayout.Space(SpaceAmount);
			if (GUILayout.Button(AddHealthButton)) characterHealth.AddHealth(DefaultChangeAmount);
			if (GUILayout.Button(SubtractHealthButton)) characterHealth.SubtractHealth(DefaultChangeAmount);
		}
	}
}

#endif