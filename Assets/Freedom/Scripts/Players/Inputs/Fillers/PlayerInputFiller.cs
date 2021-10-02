using Freedom.Camera;
using Freedom.Characters.Actions.Base;
using Freedom.Characters.Locomotion.Direction;
using Freedom.Characters.Locomotion.Gait;
using Freedom.Players.Inputs.Buttons;
using Freedom.Players.Inputs.Buttons.ButtonHoldForSecondsInput;
using UnityEngine;

namespace Freedom.Players.Inputs.Fillers
{
    public abstract class PlayerInputFiller : MonoBehaviour
    {
        [SerializeField] CharacterDirection direction;
        [SerializeField] CharacterGait gait;
        [SerializeField] CharacterAction roll;

        DirectionalInput _movementInput;
        ButtonHoldForSecondsInput _gaitHoldInput;
        ButtonDownInput _rollInput;
        MousePositionInput _mousePositionInput;

        public FollowMouseCamera Camera { get; set; }

        void OnDisable()
        {
            if (!_movementInput) return;
            _movementInput.OnDirectionalAxis -= direction.CalculateMovingDirection;
            _gaitHoldInput.OnButtonHold -= SetGaitSprinting;
            _gaitHoldInput.OnButtonHeldUp -= SetGaitNotSprinting;
            _gaitHoldInput.OnButtonUp -= gait.ToggleIsWalking;
            _rollInput.OnButtonDown -= roll.Execute;
            _mousePositionInput.OnPositionMouse -= Camera.SetPointerPosition;
        }

        public void PopulateInput(PlayerInput playerInput)
        {
            InitializeComponents(playerInput);
            _movementInput.OnDirectionalAxis += direction.CalculateMovingDirection;
            _gaitHoldInput.OnButtonHold += SetGaitSprinting;
            _gaitHoldInput.OnButtonHeldUp += SetGaitNotSprinting;
            _gaitHoldInput.OnButtonUp += gait.ToggleIsWalking;
            _rollInput.OnButtonDown += roll.Execute;
            _mousePositionInput.OnPositionMouse += Camera.SetPointerPosition;
            PopulateActions(playerInput);
        }

        void InitializeComponents(PlayerInput playerInput)
        {
            _movementInput = playerInput.Movement.GetComponent<DirectionalInput>();
            _gaitHoldInput = playerInput.Gait.GetComponent<ButtonHoldForSecondsInput>();
            _rollInput = playerInput.Roll.GetComponent<ButtonDownInput>();
            _mousePositionInput = playerInput.MousePosition.GetComponent<MousePositionInput>();
        }

        void SetGaitSprinting() => gait.IsSprinting = true;
        void SetGaitNotSprinting() => gait.IsSprinting = false;

        protected abstract void PopulateActions(PlayerInput playerInput);
    }
}