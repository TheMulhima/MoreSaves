using System;
using System.Collections.Generic;
using InControl;
using Modding;
using Modding.Converters;
using Newtonsoft.Json;
using UnityEngine;

namespace MoreSaves
{
    [Serializable]
    public class SaveNaming
    {
        public Dictionary<int, string> SaveSlotNames_Saver = new Dictionary<int, string>();
    }
    
    public class GlobalSettings
    {
        [JsonConverter(typeof(PlayerActionSetConverter))]
        public KeyBinds keybinds = new KeyBinds();
    }
    
    public class KeyBinds : PlayerActionSet
    {
        public PlayerAction NextPage_Keyboard;
        public PlayerAction PreviousPage_Keyboard;
        public PlayerAction NextPage_Controller;
        public PlayerAction PreviousPage_Controller;
        
        public bool NextPageIsPressed => NextPage_Keyboard.IsPressed || NextPage_Controller.IsPressed;
        public bool NextPageWasPressed => NextPage_Keyboard.WasPressed || NextPage_Controller.WasPressed;
        public bool PreviousPageIsPressed => PreviousPage_Keyboard.IsPressed || PreviousPage_Controller.IsPressed;
        public bool PreviousPageWasPressed => PreviousPage_Keyboard.WasPressed || PreviousPage_Controller.WasPressed;

        public KeyBinds()
        {
            NextPage_Keyboard = CreatePlayerAction("NextPage_Keyboard");
            PreviousPage_Keyboard = CreatePlayerAction("PreviousPage_Keyboard");
            NextPage_Controller = CreatePlayerAction("NextPage_Controller");
            PreviousPage_Controller = CreatePlayerAction("PreviousPage_Controller");
            DefaultBinds();
        }

        private void DefaultBinds()
        {
            NextPage_Keyboard.AddDefaultBinding(Key.RightBracket);
            PreviousPage_Keyboard.AddDefaultBinding(Key.LeftBracket);
            NextPage_Controller.AddDefaultBinding(InputControlType.RightTrigger);
            PreviousPage_Controller.AddDefaultBinding(InputControlType.LeftTrigger);
        }
    }
}
