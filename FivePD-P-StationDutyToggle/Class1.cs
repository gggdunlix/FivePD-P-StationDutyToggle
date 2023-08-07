using FivePD.API;
using FivePD.API.Utils;
using System;
using System.Collections.Generic;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace FivePD_P_StationDutyToggle

{
    public class Class1 : Plugin
    {
        internal Class1()
        {
            Debug.WriteLine("[FivePD Station Duty Toggle] ^2Plugin loading...");
            var config = API.LoadResourceFile(API.GetCurrentResourceName(), "/config/coordinates.json");
            var json = JObject.Parse(config);
            if (json["stationDutyToggle"] == null)
            {
                Debug.WriteLine("[FivePD Custom Duty Notification] ^8Something is wrong with your coordinates.json! Fix it and then^5 ensure fivepd");
                return;
            }
            Tick += TickMeth;
            Debug.WriteLine("[FivePD Station Duty Toggle] ^2Plugin loaded! ^6Made by GGGDunlix | ^5gggdunlix.github.io");

        }
        private async Task TickMeth()
        {
            bool duty = FivePD.API.Utilities.IsPlayerOnDuty();
            var config = API.LoadResourceFile(API.GetCurrentResourceName(), "/config/coordinates.json");
            var json = JObject.Parse(config);
            var vector3s = json["stationDutyToggle"];
            foreach (string s in vector3s)
            {
                string first = s.Substring(0, s.IndexOf(","));
                s.Remove(0, s.IndexOf(","));
                string second = s.Substring(0, s.IndexOf(","));
                s.Remove(0, s.IndexOf(","));
                string third = s.Substring(0, s.IndexOf(","));
                int int1 = int.Parse(first);
                int int2 = int.Parse(second);
                int int3 = int.Parse(third);
                Vector3 loc = new Vector3(int1, int2, int3);

                //Draw markers
                API.DrawMarker(((int)MarkerType.VerticalCylinder), loc.X, loc.Y, loc.Z, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1f, 1f, 1f, 100, 149, 237, 50, false, false, 2, false, (string)null, (string)null, false);

                //Blips
                Blip blip = new Blip(API.AddBlipForCoord(loc.X, loc.Y, loc.Z));
                blip.Color = BlipColor.Blue;
                API.SetBlipSprite(blip.Handle, 430);

                //Position bool
                bool isInRange = Game.PlayerPed.IsInRangeOf(loc, 2f);

                //tooltip
                string tooltip = "Press E to go ~g~On Duty~s~.";
                if (duty) { tooltip = "Press E to go ~r~Off Duty~s~."; }

                if (isInRange)
                {
                    API.BeginTextCommandDisplayHelp("STRING");
                    API.AddTextComponentSubstringPlayerName(tooltip);
                    API.EndTextCommandDisplayHelp(0, false, true, -1);
                }

                //keybind (toggle)
                if (isInRange)
                {
                    if (API.IsControlJustPressed(0, 51))
                    {
                        if (duty) Utilities.SetPlayerDuty(false); else Utilities.SetPlayerDuty(true);
                    }
                }
            }
        }
    }
}