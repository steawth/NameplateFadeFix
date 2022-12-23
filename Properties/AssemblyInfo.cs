using System;
using System.Reflection;
using MelonLoader;
using FadeFix;


[assembly: AssemblyTitle(FadeFix.BuildInfo.Description)]
[assembly: AssemblyDescription(FadeFix.BuildInfo.Description)]
[assembly: AssemblyCompany(FadeFix.BuildInfo.Company)]
[assembly: AssemblyProduct(FadeFix.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + FadeFix.BuildInfo.Author)]
[assembly: AssemblyTrademark(FadeFix.BuildInfo.Company)]
[assembly: AssemblyVersion(FadeFix.BuildInfo.Version)]
[assembly: AssemblyFileVersion(FadeFix.BuildInfo.Version)]
[assembly: MelonInfo(typeof(ModMain), FadeFix.BuildInfo.Name, FadeFix.BuildInfo.Version, FadeFix.BuildInfo.Author, FadeFix.BuildInfo.DownloadLink)]
[assembly: MelonGame("Alpha Blend Interactive", "ChilloutVR")]
[assembly: MelonColor(ConsoleColor.Magenta)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
