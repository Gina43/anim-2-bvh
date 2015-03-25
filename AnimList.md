# SLAnimList is a small utility to get the list (UUID) of Avatar animations IW. #

This is a proxy based on the LibOpenmetaverse library (Grid Proxy).
Thanks to Mockba the Borg. I used the sources of his MyNewProxy, modifying and restricting the analysis to the animation packets.
Details on the Borg blog at  http://metadventures.blogspot.com/.

## How to use ##
Download the SLAnimList.rar file, unrar it.
Go to the release directory

The use however is quite simple.

1. Launch AnimList.exe.

2. Open your viewer and select the Grid 'http://localhost:8080' (create it if not there)

3. Log in

4. Move the cursor on the avatar which you want the list of animations.

5. The name of the Resident will appear in the textbox "Selected avatar" on the proxy form.

6. Press the button "Monitor On" (You will see the list of animations in the list box).

7. When the number of animations is stabilized, press the "Monitor Off" button.

---

Pay attention to the launch and closure sequence of programs:

Opening:

a) launch AnimList.exe.

b) open the viewer

Closing:

a) close the viewer

b) close the form AnimList

---


If the viewer does not allow you to select the Grid

> Make a copy of shortcut to your viewer, and rename it as you like.

> Right click on this shortcut, select "properties",

> In the window that pops up, edit the "target" field only. Use your arrow keys to (press right arrow) move to the very end of the text

> Copy the next line, and paste it in there at the very end.

> -loginuri http://localhost:8080/

> Press "OK" then double click your new shortcut, you done!


If the Avatar is linked to some object (like poseballs) then the resident's name  will not be transferred to the textbox in the proxy form and you have to manually write the name in the textbox (it's OK to copy and paste from profile).

It will create a new folder for each avatar monitored.
The folder contains a file named " Animation list.txt ".
The folder will be created in the directory where  resides the file AnimList.exe.


The file "Animation list.txt" is formatted to be read by the utility "SLCachedb2"

# Version 1.30 #

"Who" command added.
This command shows the list of avatars currently within the drawing distance.
This is the list of avatars that can currently be seen at the viewer, not the entire list of avatars connected to the region.
The command is very useful when you need to manually enter the name of the resident. Just copy and paste the name from the list.