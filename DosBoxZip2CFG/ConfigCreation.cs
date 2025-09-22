using System;
using System.Collections;
using System.Collections.Generic;

namespace DosBoxZip2CFG
{
    public static class ConfigCreation
    {
        static public List<string> ConfigFile = new List<string>();
        static public Form1 target;

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
            ConfigFile.Add(@"fullscreen=" + target.sdlFullscreen.Checked.ToString().ToLower());
            ConfigFile.Add(@"fulldouble=" + target.sdlFulldouble.Checked.ToString().ToLower());
            ConfigFile.Add(@"fullresolution=" + target.sdlFullResolution.Text);
            ConfigFile.Add(@"windowresolution=" + target.sdlWindowRes.Text);
            ConfigFile.Add(@"output=" + target.sdlOutput.Text);
            ConfigFile.Add(@"autolock=" + target.sdlAutoLock.Checked.ToString().ToLower());
            ConfigFile.Add(@"sensitivity=" + target.sdlSensitivity.Value);
            ConfigFile.Add(@"waitonerror=" + target.sdlWaitOnError.Checked.ToString().ToLower());
            ConfigFile.Add(@"priority=" + target.sdlPriorityNotFocused.Text + "," + target.sldPriorityMinimized.Text);
            ConfigFile.Add(@"mapperfile=" + target.sdlMapper.Text);
            ConfigFile.Add(@"usescancodes=" + target.sdlUseScanCodes.Checked.ToString().ToLower());
            ConfigFile.Add(@"");
        }

        static public void CreateDosBox()
        {
            ConfigFile.Add("[dosbox]");
            ConfigFile.Add(@"language=" + target.dosboxLanguage.Text);
            ConfigFile.Add(@"machine=" + target.dosboxMachine.Text);
            ConfigFile.Add(@"captures=" + target.dosboxCaptures.Text);
            ConfigFile.Add(@"memsize=" + target.dosboxMemsize.Value);
            ConfigFile.Add(@"");
        }

        static public void CreateRender()
        {
            ConfigFile.Add(@"[render]");
            ConfigFile.Add(@"frameskip=" + target.renderFrameskip.Value);
            ConfigFile.Add(@"aspect=" + target.renderAspect.Checked.ToString().ToLower());
            ConfigFile.Add(@"scaler=" + target.renderScaler.Text);
            ConfigFile.Add(@"");
        }

        static public void CreateCPU()
        {
            ConfigFile.Add(@"[cpu]");
            ConfigFile.Add(@"core=" + target.cpuCore.Text);
            ConfigFile.Add(@"cputype=" + target.cpuCpuType.Text);
            ConfigFile.Add(@"cycles=" + target.cpuCycles.Text);
            ConfigFile.Add(@"cycleup=" + target.cpuCycleUp.Value);
            ConfigFile.Add(@"cycledown=" + target.cpuCycleDown.Value);
            ConfigFile.Add(@"");
        }

        static public void CreateMixer()
        {
            ConfigFile.Add(@"[mixer]");
            ConfigFile.Add(@"nosound=" + target.mixerNoSound.Checked.ToString().ToLower());
            ConfigFile.Add(@"rate=" + target.mixerRate.Text);
            ConfigFile.Add(@"blocksize=" + target.mixerBlockSize.Text);
            ConfigFile.Add(@"prebuffer=" + target.mixerPreBuffer.Value);
            ConfigFile.Add(@"");
        }

        static public void CreateMidi()
        {
            ConfigFile.Add(@"[midi]");
            ConfigFile.Add(@"mpu401=" + target.midiMPU.Text);
            ConfigFile.Add(@"mididevice=" + target.midiDevice.Text);
            ConfigFile.Add(@"midiconfig=" + target.midiConfig.Text);
            ConfigFile.Add(@"");
        }

        static public void CreateSBlaster()
        {
            ConfigFile.Add(@"[sblaster]");
            ConfigFile.Add(@"sbtype=" + target.sblasterSBType.Text);
            ConfigFile.Add(@"sbbase=" + target.sblasterSBBase.Text);
            ConfigFile.Add(@"irq=" + target.sblasterIRQ.Text);
            ConfigFile.Add(@"dma=" + target.sblasterDMA.Text);
            ConfigFile.Add(@"hdma=" + target.sblasterHDMA.Text);
            ConfigFile.Add(@"sbmixer=" + target.sblasterSBMixer.Checked.ToString().ToLower());
            ConfigFile.Add(@"oplmode=" + target.sblasterOPLMode.Text);
            ConfigFile.Add(@"oplemu=" + target.sblasterOPLEmu.Text);
            ConfigFile.Add(@"oplrate=" + target.sblasterOPLRate.Text);
            ConfigFile.Add(@"");
        }

        static public void CreateGUS()
        {
            ConfigFile.Add(@"[gus]");
            ConfigFile.Add(@"gus=" + target.gusEnableGus.Checked.ToString().ToLower());
            ConfigFile.Add(@"gusrate=" + target.gusRate.Text);
            ConfigFile.Add(@"gusbase=" + target.gusBase.Text);
            ConfigFile.Add(@"gusirq=" + target.gusIRQ.Text);
            ConfigFile.Add(@"gusdma=" + target.gusDMA.Text);
            ConfigFile.Add(@"ultradir=" + target.gusUltraDir.Text);
            ConfigFile.Add(@"");
        }

        static public void CreateSpeaker()
        {
            ConfigFile.Add(@"[speaker]");
            ConfigFile.Add(@"pcspeaker=" + target.speakerEnable.Checked.ToString().ToLower());
            ConfigFile.Add(@"pcrate=" + target.speakerPCRate.Text);
            ConfigFile.Add(@"tandy=" + target.speakerTandy.Text);
            ConfigFile.Add(@"tandyrate=" + target.speakerTandyRate.Text);
            ConfigFile.Add(@"disney=" + target.speakerDisney.Checked.ToString().ToLower());
            ConfigFile.Add(@"");
        }

        static public void CreateJoystick()
        {
            ConfigFile.Add(@"[joystick]");
            ConfigFile.Add(@"joysticktype=" + target.joystickType.Text);
            ConfigFile.Add(@"timed=" + target.joystickTimed.Checked.ToString().ToLower());
            ConfigFile.Add(@"autofire=" + target.joystickAutoFire.Checked.ToString().ToLower());
            ConfigFile.Add(@"swap34=" + target.joystickSwap.Checked.ToString().ToLower());
            ConfigFile.Add(@"buttonwrap=" + target.joystickButtonWrap.Checked.ToString().ToLower());
            ConfigFile.Add(@"");
        }

        static public void CreateSerial()
        {
            ConfigFile.Add(@"[serial]");
            ConfigFile.Add(@"serial1=" + target.serial1.Text);
            ConfigFile.Add(@"serial2=" + target.serial2.Text);
            ConfigFile.Add(@"serial3=" + target.serial3.Text);
            ConfigFile.Add(@"serial4=" + target.serial4.Text);
            ConfigFile.Add(@"");
        }

        static public void CreateDOS()
        {
            ConfigFile.Add(@"[dos]");
            ConfigFile.Add(@"xms=" + target.dosXMS.Checked.ToString().ToLower());
            ConfigFile.Add(@"ems=" + target.dosEMS.Checked.ToString().ToLower());
            ConfigFile.Add(@"umb=" + target.dosUMB.Checked.ToString().ToLower());
            ConfigFile.Add(@"keyboardlayout=" + target.dosKeyLayout.Text.Split(' ')[0]);
            ConfigFile.Add(@"");
        }

        static public void CreateIPX()
        {
            ConfigFile.Add(@"[ipx]");
            ConfigFile.Add(@"ipx=" + target.ipxEnable.Checked.ToString().ToLower());
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
}