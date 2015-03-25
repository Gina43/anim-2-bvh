# SLCachedb2 #

Anim2Bvh converter.
The program performs the conversion off-line.
Any viewer must be closed before launching the program.

The UUID of the animation to be converted must be listed in a separate text file (. Txt).

The UUID of the animations may be  obtained using the specific functions in the viewers. Phoenix, for example, provides the function "animation explorer" which lists the animations in use (including UUID).

The file-Anim.txt UUID contains a sample text file that the program reads.

use:

  1. Close the viewer.

> 2. launch SLCachedb2.exe

> 3. Select the text file containing the UUID of the animations (UUID List)

> 4. It is proposed the path of the text file as the default file BVH destination. You can select a different path. (Output Dir)

> 5. Press the "Read" button. The Found and Total textboxes show respectively the total number of animations in the list and those found in the cache.

> 6. Press the "Write BVH Files" button.

The data in the local caches remain for a limited time. This is because the oldest data is deleted to make room for new data.

Perform the recovery immediately after the close of the session during which you have seen or used the animations IW.

For the more experienced i remember that libraries openmetaverse allow the interception of packets, including even those of the animations and their UUID.

A good example of this use is MyNewProxy, developed by the Borg Mockba (information in his blog)
http://metadventures.blogspot.com/2010_10_01_archive.html

A simple version (download just a list of UUID animation) of MyNewProxy is AnimList (you can download here the file SLAnimList.rar containing AnimList.exe and the LibOpenMetaverse library).
Read the wiki section AnimList for more.


## SLCachedb2 version 1.1.20 ##

Added option "Select by date / time"

By setting the corresponding checkbox, you can convert the animations without actually knowing their UUID and, therefore, is not necessary to read the text file containing the list of animation to convert.

All animations in the cache downloaded in the time interval between "from" and "to" will be converted.

Time is  referred to SL time.