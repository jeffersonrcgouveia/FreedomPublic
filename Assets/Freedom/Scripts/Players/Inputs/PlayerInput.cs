using UnityEngine;

namespace Freedom.Players.Inputs
{
    public class PlayerInput : MonoBehaviour
    {
        [field: SerializeField] public GameObject Movement { get; set; }
        [field: SerializeField] public GameObject Gait { get; set; }
        [field: SerializeField] public GameObject Roll { get; set; }
        [field: SerializeField] public GameObject MousePosition { get; set; }
        [field: SerializeField] public GameObject Action1 { get; set; }
        [field: SerializeField] public GameObject Action2 { get; set; }
    }
}