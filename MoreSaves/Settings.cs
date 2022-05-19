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
        public PlayerAction NextPage;
        public PlayerAction PreviousPage;
        public PlayerAction LockSave;

        public KeyBinds()
        {
            NextPage = CreatePlayerAction("NextPage");
            PreviousPage = CreatePlayerAction("PreviousPage");
            LockSave = CreatePlayerAction("LockSave");
            DefaultBinds();
        }

        private void DefaultBinds()
        {
            NextPage.AddDefaultBinding(Key.RightBracket);
            PreviousPage.AddDefaultBinding(Key.LeftBracket);
            PreviousPage.AddDefaultBinding(InputHandler.Instance.inputActions.dreamNail.GetKeyOrMouseBinding().Key);
        }
    }
}
