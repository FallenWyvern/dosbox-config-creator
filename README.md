# Tool for creating Dosbox Config Files
**Disclaimer** This tool is provided with no license. Feel free to do whatever you want with the code here. This code works on my machine (tm) and if you decide to use this code, you're running it at your own risk. 

## What is this for?
This tool is for taking a zipped DOS game, dropping the zip onto this tool, and either save a config file or insert it directly into the zip.

## How do I use it?
**Without a ZIP**: Just click "Create Config" and click save. It'll create a very basic default config file. Then click "Save File" to save this to "DOSBOX.cfg". If you want to change this name, change "Target EXE" field with something like this: ```./FILENAME.exe``` (whatever filename you give it will create a cfg of the same name).

**With a ZIP**: Drag and drop it onto the dropzone in the upper left. The file will be opened, the files inside will be listed in the middle box. Any EXE, COM, and BAT files will go into the Executables list and any ISO, BIN, CUE, or IMG file will be put into the Images list. If you click an Executable, the Target EXE field will update to include it. If you click an Image file, the Target ISO field will update to include it.

## What About The Rest Of This?
The last third of the application is used to change the various settings in a dosbox config file. Lines that can only take specific options are listed in drop down boxes. Lines that can only take numbers will only allow numbers. Lines that can only be true/false will be checkboxes, and finally anything else will be a text field input. If you don't know what you're doing, just leave these as they are.
