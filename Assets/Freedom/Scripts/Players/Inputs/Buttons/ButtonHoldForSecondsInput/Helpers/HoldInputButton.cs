using System.Collections.Generic;
using UnityEngine;

namespace Freedom.Players.Inputs.Buttons.ButtonHoldForSecondsInput.Helpers
{
    public class HoldInputButton
    {
        readonly Dictionary<string, ButtonHold> _buttonsStartTime = new Dictionary<string, ButtonHold>();

        const float DefaultHoldSeconds = 0.18f;

        /**
         * If the user hold the button "buttonName" for the duration of "holdSeconds", the callback
         * event "OnButtonHold" will be called. After "OnButtonHold" is called, when the button is
         * released, the callback event "OnButtonHeldUp" is called. If the user release the button
         * before "holdSeconds" time, the callback event "OnButtonUp" is called.
         *
         * return true while the user is holding the button
         */
        public bool HoldButton(string buttonName, ButtonCallBack onButtonHold,
            ButtonCallBack onButtonHeldUp, ButtonCallBack onButtonUp, float holdSeconds = DefaultHoldSeconds)
        {
            if (Input.GetButtonDown(buttonName))
            {
                _buttonsStartTime.Add(buttonName, new ButtonHold {StartTime = Time.time});
            }

            bool buttonHolding = false;
            if (Input.GetButton(buttonName))
            {
                ButtonHold buttonHold = _buttonsStartTime[buttonName];
                float nextHoldTime = buttonHold.StartTime + holdSeconds;
                float holdingTime = Time.time;
                if (!buttonHold.Held & (buttonHolding = holdingTime >= nextHoldTime))
                {
                    buttonHold.Held = true;
                    onButtonHold();
                }
                // Debug.Log($"StartTime:{buttonHold.StartTime} HoldingTime: {holdingTime} NextHoldTime: {nextHoldTime} buttonHold.Held: {buttonHold.Held} holdingTime >= nextHoldTime: {holdingTime >= nextHoldTime}");
            }

            if (Input.GetButtonUp(buttonName))
            {
                ButtonHold buttonHold = _buttonsStartTime[buttonName];
                if (_buttonsStartTime.Remove(buttonName))
                {
                    if (buttonHold.Held)
                    {
                        onButtonHeldUp?.Invoke();
                    }
                    else
                    {
                        onButtonUp?.Invoke();
                    }
                }
            }

            return buttonHolding;
        }

        public delegate void ButtonCallBack();

        class ButtonHold
        {
            public float StartTime { get; internal set; }
            public bool Held { get; internal set; }
        }
    }
}