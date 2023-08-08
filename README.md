# FivePD-P-StationDutyToggle

Allows you to go on/off duty in person at customizable coordinates.
![image](https://github.com/gggdunlix/FivePD-P-StationDutyToggle/assets/33298379/b49b752e-9f61-4c3a-bba5-f82e8f9b2e4c)
*Notice how the plugin adds a blip, marker, and tooltip for each location*

## Installation
1. Download the latest DLL from the [releases section](https://github.com/gggdunlix/FivePD-P-StationDutyToggle/releases/latest).
2. Put the DLL in the `/plugins` folder of FivePD.
3. Add this section to your `coordinates.json` file:
   ```
   "stationDutyToggle": [
		"447.2428f, -975.7278f, 29.68959f",
		"441.1443f, -981.5926f, 29.6896f"
	],
   ```
   Be sure to follow json rules. If you add the section to the end of the file, you will need to remove that comma and add one at the end of the previous section. For best results, put the entire file in a [JSON LINT](https://jsonlint.com/)
4. Edit the coordinates from the file to your liking. Again, all should have a comma at the end except for the last one.
5. After any changes are made, `ensure fivepd` in the F8 Console.

If you want, you can disable the duty toggle from the Duty Menu in the `menu.json` file.

## Limitations
* Due to the way FivePD is coded, when duty status is changed, the duty notification does not appear. This can be fixed on the client side by using my [ChangeDutyNotification](https://github.com/gggdunlix/FivePD-P-ChangeDutyNotification) plugin.
