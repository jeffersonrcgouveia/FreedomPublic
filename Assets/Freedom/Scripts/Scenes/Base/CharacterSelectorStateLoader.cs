using ScriptableEvents.Variables;
using UnityEngine;

namespace Freedom.Scenes.Base
{
    public class CharacterSelectorStateLoader : MonoBehaviour
    {
        [SerializeField] GameObjectScriptableVariable characterPrefabState;

        public GameObject GetData() => characterPrefabState.Data;
    }
}