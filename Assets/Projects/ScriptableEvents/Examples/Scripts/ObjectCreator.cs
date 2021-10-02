using ScriptableEvents.Events;
using ScriptableEvents.Events.Base;
using UnityEngine;

namespace ScriptableEvents.Examples
{
    public class ObjectCreator : MonoBehaviour
    {
        [SerializeField] ScriptableEvent onLoad;

        [SerializeField] GameObjectScriptableEvent onCreateGameObject;

        [SerializeField] TransformScriptableEvent onFindTransform;

        [SerializeField] Vector3ScriptableEvent onPosition;

        [SerializeField] IntScriptableEvent onIncrementCounter;

        [SerializeField] FloatScriptableEvent onCalculateDamage;

        [SerializeField] BoolScriptableEvent onEnableComponent;

        [SerializeField] StringScriptableEvent onSetName;

        void Awake()
        {
            onLoad.Invoke();
            GameObject go = new GameObject("NewGameObject");
            InvokeEvent(onCreateGameObject, go);
            InvokeEvent(onFindTransform, go.transform);
            InvokeEvent(onPosition, go.transform.position);
            InvokeEvent(onIncrementCounter, 2);
            InvokeEvent(onCalculateDamage, 3.5f);
            InvokeEvent(onEnableComponent, true);
            InvokeEvent(onSetName, "New Text");
        }

        void InvokeEvent<T>(ScriptableEventBase<T> eventBase, T param) => eventBase.Invoke(param);
    }
}
