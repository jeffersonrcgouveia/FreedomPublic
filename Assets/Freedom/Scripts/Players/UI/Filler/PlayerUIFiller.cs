using Freedom.Characters.Attributes;
using Freedom.UI.ProgressBar;
using UnityEngine;

namespace Freedom.Players.UI.Filler
{
    public class PlayerUIFiller : MonoBehaviour
    {
        [SerializeField] CharacterHealth characterHealth;

        [SerializeField, Space] ProgressBarUpdater healthBar;

        public void PopulateFields(GameObject character)
        {
            characterHealth = character.GetComponentInChildren<CharacterHealth>();
            characterHealth.OnChangePercent += health => healthBar.FillAmount = health;
        }
    }
}