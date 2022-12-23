using System;
using MelonLoader;
using HarmonyLib;
using FadeFix;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using RTG;
using PlayerNameplate = ABI_RC.Core.Player.PlayerNameplate;
using RefFlags = System.Reflection.BindingFlags;

namespace FadeFix
{
    
    public static class BuildInfo
    {
        public const string Name = "NameplateFadeFix"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Mod for fixing fade on nameplate images"; // Description for the Mod.  (Set as null if none)
        public const string Author = "Stealth"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class ModMain: MelonMod
    {
        private const string SettingsCategory = "NameplateFadeFix";
        private const string SettingEnableMod = "Enabled";

        public static MelonPreferences_Entry<bool> ourEnable;

        public static MelonLogger.Instance Logger;
        public static ModMain Instance { get; set; }

        public override void OnApplicationStart() // Runs after Game Initialization.
        {
            Logger = LoggerInstance;

            var category = MelonPreferences.CreateCategory(SettingsCategory, "Nameplate Fade Fix");
            ourEnable = category.CreateEntry(SettingEnableMod, true, "Enabled");

            Instance = this;
            Logger.Msg("Fixing Color Fade on Nameplate Images");
        }
    }
}


[HarmonyPatch(typeof(PlayerNameplate))]
class NameplatePatches
{
    [HarmonyPatch(nameof(PlayerNameplate.UpdateNamePlate))]
    [HarmonyPostfix]
    static void UpdateNameplate(PlayerNameplate __instance)
    {
        if (ModMain.ourEnable.Value)
        {
            if (__instance.objectMaskSlave != null)
                try
                {
                    var userImgMask = __instance.objectMaskSlave.transform.Find("UserImageMask")?.GetComponent<Image>();
                    if (userImgMask != null)
                    {
                        userImgMask.color = Color.black;
                    }
                    else
                    {
                        ModMain.Logger.Msg("Error Fixing Nameplate Fade: UserImageMask is null (and bono is a nerd)");
                    }
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
        }
    }
        
}