# How To Use:

Make sure TaleSpire is started. Click on a roll macro button to load the corresponding dice in the Talespire dice tray.
When rolled, Talespire will identify the roll macro name and apply any modifiers that were specified.


# Adding Custom Roll Macros:

The JSON file contains a main "macros" envelope which consists of roll marco entries. Each roll macro entry consists of the name in double quotes,
followed by a colon, followed by the roll formula in double quotes, and finally a comma if there are more entries. For example:

*"Shortbow": "1d20+10",*

The above roll macro will prepare a D20 in the roll tray and when it is rolled it will display Shortbow and add 10 to the rolled total. Please note
that the space for the macro name is very short in TS so try to use short names. The macro names must also be unique.

The formula can use different dice, for example:

*"EB+Hex Damage": "2d10+1D6",*

You can also separate dice, in a single roll, for multiple totals. For example, the following roll macro rolls both an attack total and damage total:

*"Rapier": "1D20+5/Damage:1D8+3",*

# How It Works

The application sends a talespire:// URI to the operating system to handle. Since the talespire:// URI is registered with the TaleSpire application
it will be passed to the TaleSpire application if it is running. TaleSpire then parses the info and generates the corresponding dice in the tray.

