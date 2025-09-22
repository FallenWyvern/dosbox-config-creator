using System;
using System.Collections;
using System.Collections.Generic;

public static class ConfigCreation
{
	static public List<string> ConfigFile = new List<string>();
	
	static public void CreateConfig()
    {
        ConfigFile.Clear();
        ConfigFile = new List<string>();
        
        CreateConfigHeader();
        CreateConfigSDL();
        CreateDosBox();
        CreateRender();
        CreateCPU();
        CreateMixer();
        CreateMidi();
        CreateSBlaster();
        CreateGUS();
        CreateSpeaker();
        CreateJoystick();
        CreateSerial();
        CreateDOS();
        CreateIPX();
        CreateAutoExec();
    }

	static public void CreateConfigHeader()
    {
        ConfigFile.Add("# This is the configuration file for DOSBox 0.74. (Please use the latest version of DOSBox)");
        ConfigFile.Add("# Lines starting with a # are commentlines and are ignored by DOSBox.");
        ConfigFile.Add("# They are used to (briefly) document the effect of each option.");
        ConfigFile.Add("");
    }

    static public void CreateConfigSDL()
    {
        ConfigFile.Add("[sdl]");
        ConfigFile.Add(@"fullscreen=TRUE");
        ConfigFile.Add(@"fulldouble=false");
        ConfigFile.Add(@"fullresolution=Fixed");
        ConfigFile.Add(@"windowresolution=1280x800");
        ConfigFile.Add(@"output=direct3d");
        ConfigFile.Add(@"autolock=true");
        ConfigFile.Add(@"sensitivity=100");
        ConfigFile.Add(@"waitonerror=true");
        ConfigFile.Add(@"priority=higher,normal");
        ConfigFile.Add(@"mapperfile=mapper-0.74.map");
        ConfigFile.Add(@"usescancodes=true");
        ConfigFile.Add(@"");
    }

    static public void CreateDosBox()
    {        
        ConfigFile.Add("[dosbox]");
        ConfigFile.Add(@"language=");
        ConfigFile.Add(@"machine=svga_s3");
        ConfigFile.Add(@"captures=.\Captures\");
        ConfigFile.Add(@"memsize=32");
        ConfigFile.Add(@"");
    }

    static public void CreateRender()
    {
        ConfigFile.Add(@"[render]");
        ConfigFile.Add(@"frameskip=0");
        ConfigFile.Add(@"aspect=false");
        ConfigFile.Add(@"scaler=normal3x");
        ConfigFile.Add(@"");
    }

    static public void CreateCPU()
    {
        ConfigFile.Add(@"[cpu]");
        ConfigFile.Add(@"core=dynamic");
        ConfigFile.Add(@"cputype=auto");
        ConfigFile.Add(@"cycles=max");
        ConfigFile.Add(@"cycleup=10");
        ConfigFile.Add(@"cycledown=20");
        ConfigFile.Add(@"");
    }

    static public void CreateMixer()
    {
        ConfigFile.Add(@"[mixer]");
        ConfigFile.Add(@"nosound=false");
        ConfigFile.Add(@"rate=44100");
        ConfigFile.Add(@"blocksize=512");
        ConfigFile.Add(@"prebuffer=20");
        ConfigFile.Add(@"");
    }

    static public void CreateMidi()
    {
        ConfigFile.Add(@"[midi]");
        ConfigFile.Add(@"mpu401=intelligent");
        ConfigFile.Add(@"mididevice=default");
        ConfigFile.Add(@"midiconfig=");
        ConfigFile.Add(@"");
    }

    static public void CreateSBlaster()
    {
        ConfigFile.Add(@"[sblaster]");
        ConfigFile.Add(@"sbtype=sb16");
        ConfigFile.Add(@"sbbase=220");
        ConfigFile.Add(@"irq=7");
        ConfigFile.Add(@"dma=1");
        ConfigFile.Add(@"hdma=5");
        ConfigFile.Add(@"sbmixer=true");
        ConfigFile.Add(@"oplmode=auto");
        ConfigFile.Add(@"oplemu=default");
        ConfigFile.Add(@"oplrate=44100");
        ConfigFile.Add(@"");
    }

    static public void CreateGUS()
    {
        ConfigFile.Add(@"[gus]");
        ConfigFile.Add(@"gus=false");
        ConfigFile.Add(@"gusrate=44100");
        ConfigFile.Add(@"gusbase=240");
        ConfigFile.Add(@"gusirq=5");
        ConfigFile.Add(@"gusdma=3");
        ConfigFile.Add(@"ultradir=C:\ULTRASND");
        ConfigFile.Add(@"");
    }

    static public void CreateSpeaker()
    {
        ConfigFile.Add(@"[speaker]");
        ConfigFile.Add(@"pcspeaker=true");
        ConfigFile.Add(@"pcrate=44100");
        ConfigFile.Add(@"tandy=auto");
        ConfigFile.Add(@"tandyrate=44100");
        ConfigFile.Add(@"disney=true");
        ConfigFile.Add(@"");
    }

    static public void CreateJoystick()
    {
        ConfigFile.Add(@"[joystick]");
        ConfigFile.Add(@"joysticktype=auto");
        ConfigFile.Add(@"timed=true");
        ConfigFile.Add(@"autofire=false");
        ConfigFile.Add(@"swap34=false");
        ConfigFile.Add(@"buttonwrap=false");
        ConfigFile.Add(@"");
    }

    static public void CreateSerial()
    {
        ConfigFile.Add(@"[serial]");
        ConfigFile.Add(@"serial1=dummy");
        ConfigFile.Add(@"serial2=dummy");
        ConfigFile.Add(@"serial3=disabled");
        ConfigFile.Add(@"serial4=disabled");
        ConfigFile.Add(@"");
    }

    static public void CreateDOS()
    {
        ConfigFile.Add(@"[dos]");
        ConfigFile.Add(@"xms=true");
        ConfigFile.Add(@"ems=true");
        ConfigFile.Add(@"umb=true");
        ConfigFile.Add(@"keyboardlayout=auto");
        ConfigFile.Add(@"");
    }

    static public void CreateIPX()
    {
        ConfigFile.Add(@"[ipx]");
        ConfigFile.Add(@"ipx=false");
        ConfigFile.Add(@"");
    }

    static public void CreateAutoExec()
    {
        ConfigFile.Add(@"[autoexec]");
        ConfigFile.Add(@"# Lines in this section will be run at startup.");
        ConfigFile.Add(@"# You can put your MOUNT lines here.");
        ConfigFile.Add(@"");
    }
}
