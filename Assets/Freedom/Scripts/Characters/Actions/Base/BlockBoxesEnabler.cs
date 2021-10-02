using System.Collections.Generic;
using Freedom.Characters.Colliders;
using UnityEngine;

namespace Freedom.Characters.Actions.Base
{
    public class BlockBoxesEnabler : MonoBehaviour
    {
        [SerializeField] List<BlockBox> blockBoxes;

        public void EnableBlockBoxes() => SetBlockBoxesActive(true);

        public void DisableBlockBoxes() => SetBlockBoxesActive(false);

        void SetBlockBoxesActive(bool value)
        {
            foreach (BlockBox blockBox in blockBoxes)
            {
                blockBox.gameObject.SetActive(value);
            }
        }
    }
}