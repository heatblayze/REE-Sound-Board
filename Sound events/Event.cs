using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sound_events
{
    public class Event
    {
        public ModifierKeys modifier;
        public Keys key;
        public string SoundName;
        public string ImageName;
        public int lineNum;
        public Button button;
        public float Volume;
        public bool UseEcho = false;
        public float EchoAmount = 120;
        public string Name;
        public enum PlayModes { multi, once, start_stop};
        public PlayModes PlayMode;

        public Event(ModifierKeys a_mod, Keys a_key, string a_sound, string a_image, int a_lineNum, Button btn, float a_vol, PlayModes a_playmode)
        {
            modifier = a_mod;
            key = a_key;
            lineNum = a_lineNum;
            SoundName = a_sound;
            ImageName = a_image;
            button = btn;
            Volume = a_vol;
            PlayMode = a_playmode;
        }
    }
}
