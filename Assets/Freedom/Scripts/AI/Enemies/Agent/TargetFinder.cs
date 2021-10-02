using System;
using UnityEngine;
using UnityEngine.Events;

namespace Freedom.AI.Enemies.Agent
{
	[Serializable]
	public class TargetFinder
	{
		[SerializeField] LayerMask targetLayerMask;

		[field:SerializeField] public float Range { get; private set; }

		[field: SerializeField, Space] public UnityEvent<Transform> OnFindTarget { get; set; }

		[field: SerializeField] public UnityEvent OnLoseTarget { get; set; }

		bool _canFireOnLoseTargetEvent;

		public Transform TryFindTarget(Vector3 chaserPosition)
		{
			bool foundTarget = Physics.CheckSphere(chaserPosition, Range, targetLayerMask);

			if (foundTarget)
			{
				Transform target = OverlapTarget(chaserPosition);
				OnFindTarget?.Invoke(target);
				_canFireOnLoseTargetEvent = true;
				return target;
			}

			if (_canFireOnLoseTargetEvent)
			{
				OnLoseTarget?.Invoke();
				_canFireOnLoseTargetEvent = false;
			}

			return null;
		}

		Transform OverlapTarget(Vector3 chaserPosition)
		{
			Collider[] others = Physics.OverlapSphere(chaserPosition, Range, targetLayerMask);
			return others.Length > 0 ? others[0].transform : null;
		}
	}
}