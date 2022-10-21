using HKMirror.Reflection;
using Modding;
using UnityEngine.UI;

namespace MoreSaves
{
    internal static class SaveExtensions
    {
        private static void ChangeSaveFileState(this SaveSlotButton self, SaveSlotButton.SaveFileStates nextSaveFileState)
        {
            self.saveFileState = nextSaveFileState;

            if (self.isActiveAndEnabled) self.ShowRelevantModeForSaveFileState();
        }

        public static void _prepare(this SaveSlotButton self, GameManager gameManager)
        {
            self.ChangeSaveFileState(SaveSlotButton.SaveFileStates.OperationInProgress);

            Platform.Current.IsSaveSlotInUse((int) self.saveSlot + 1, delegate(bool fileExists)
            {
                if (!fileExists)
                {
                    self.ChangeSaveFileState(SaveSlotButton.SaveFileStates.Empty);

                    return;
                }

                gameManager.GetSaveStatsForSlot((int) self.saveSlot + 1, delegate(SaveStats saveStats)
                {
                    if (saveStats == null)
                    {
                        self.ChangeSaveFileState(SaveSlotButton.SaveFileStates.Corrupted);
                    }
                    else
                    { 
                        self.Reflect().saveStats = saveStats;
                        self.ChangeSaveFileState(SaveSlotButton.SaveFileStates.LoadedStats);
                    }
                });
            });
        }
    }
}