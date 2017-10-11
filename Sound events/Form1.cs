using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sound_events
{
    public partial class Form1 : Form
    {
        KeyboardHook hook = new KeyboardHook();

        List<Event> events = new List<Event>();
        List<SoundEffect> soundList = new List<SoundEffect>();

        public Form1()
        {
            InitializeComponent();

            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Sounds.txt"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/");
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Sounds.txt").Close();
            }
            else
            {
                string[] lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Sounds.txt");

                int lineNumber = -1;
                foreach (string line in lines)
                {
                    ++lineNumber;
                    string[] columns = line.Split('|');
                    if (columns.Length != 6)
                        continue;

                    ModifierKeys mod = (ModifierKeys)Enum.Parse(typeof(ModifierKeys), columns[0]);
                    Keys key = (Keys)Enum.Parse(typeof(Keys), columns[1]);
                    Button btn = new Button();
                    Event.PlayModes playmode = (Event.PlayModes)Enum.Parse(typeof(Event.PlayModes), columns[5]);
                    Event ev = new Event(mod, key, columns[2], columns[3], lineNumber, btn, Convert.ToSingle(columns[4]), playmode);

                    if (!(ev.modifier == Sound_events.ModifierKeys.None && ev.key == Keys.None))
                        hook.RegisterHotKey(ev.modifier, ev.key);

                    btn.Parent = panel;
                    int index = panel.Controls.GetChildIndex(btn, false);
                    panel.Controls.SetChildIndex(btn, index - 1);

                    btn.Size = new Size(100, 100);
                    try
                    {
                        btn.BackgroundImage = Image.FromFile(ev.ImageName);
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.BackColor = Color.Transparent;
                    }
                    catch
                    {

                    }
                    btn.FlatStyle = FlatStyle.Popup;

                    btn.MouseUp += new MouseEventHandler(delegate (Object o, MouseEventArgs args)
                    {
                        if (args.Button == MouseButtons.Left)
                            hook_KeyPressed(btn, new KeyPressedEventArgs(ev.modifier, ev.key));
                        else if (args.Button == MouseButtons.Right)
                        {
                            EditEvent(ev);
                        }
                    });
                    events.Add(ev);
                }
            }

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Settings.txt"))
            {
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Settings.txt").Close();                
                List<string> lines = new List<string>(File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Settings.txt"));
                lines.Add("0|0");
                lines.Add("0.3");
                lines.Add("0,0|434,384");
                File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Settings.txt", lines);


                ShowOptions();
            }
            else
            {
                string[] lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Settings.txt");
                string[] indicies = lines[0].Split('|');

                if (indicies.Length < 2)
                {
                    ShowOptions();
                }
                else
                {
                    try
                    {
                        Helper.Mic = (Guid)new GuidConverter().ConvertFromString(indicies[0]);
                        Helper.Out = (Guid)new GuidConverter().ConvertFromString(indicies[1]);
                    }
                    catch
                    {
                        ShowOptions();
                    }
                }
                string[] posloc = lines[2].Split('|');
                string[] pos = posloc[0].Split(',');
                string[] loc = posloc[1].Split(',');

                Size = new Size(Convert.ToInt32(pos[0]), Convert.ToInt32(pos[1]));
                Location = new Point(Convert.ToInt32(loc[0]), Convert.ToInt32(loc[1]));
            }

            ModifierKeys nmod = Sound_events.ModifierKeys.Alt | Sound_events.ModifierKeys.Control;
            Keys nkey = Keys.R;
            Button nbtn = new Button();
            float vol = 0.3f;
            string[] volumelines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Settings.txt");
            if (volumelines.Length > 1)
                vol = Convert.ToSingle(volumelines[1]);

            Event nev = new Event(nmod, nkey, "reee.mp3", "reeeeeee.jpg", -1, nbtn, vol, Event.PlayModes.multi);

            if (!(nev.modifier == Sound_events.ModifierKeys.None && nev.key == Keys.None))
                hook.RegisterHotKey(nev.modifier, nev.key);

            nbtn.Parent = panel;
            panel.Controls.SetChildIndex(nbtn, 0);

            nbtn.Size = new Size(100, 100);
            try
            {
                nbtn.BackgroundImage = Image.FromFile(nev.ImageName);
                nbtn.BackgroundImageLayout = ImageLayout.Stretch;
                nbtn.BackColor = Color.Transparent;
            }
            catch
            {

            }
            nbtn.FlatStyle = FlatStyle.Popup;

            nbtn.MouseUp += new MouseEventHandler(delegate (Object o, MouseEventArgs args)
            {
                if (args.Button == MouseButtons.Left)
                    hook_KeyPressed(nbtn, new KeyPressedEventArgs(nev.modifier, nev.key));
                else if (args.Button == MouseButtons.Right)
                {
                    EditEvent(nev);
                }
            });
            events.Add(nev);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            foreach (var ev in events)
            {
                if (e.Modifier == ev.modifier && e.Key == ev.key)
                {
                    if (ev.PlayMode == Event.PlayModes.multi)
                    {
                        var sound = new SoundEffect(ev.SoundName, ev.Volume, ev);
                        sound.parent = this;
                        soundList.Add(sound);
                    }
                    else if (ev.PlayMode == Event.PlayModes.start_stop)
                    {
                       var sound = soundList.Find((x) => x.soundFileName == ev.SoundName);
                        if (sound != null)
                        {
                            RemoveSound(sound);
                        }
                        else
                        {
                            sound = new SoundEffect(ev.SoundName, ev.Volume, ev);
                            sound.parent = this;
                            soundList.Add(sound);
                        }
                    }
                    else if (ev.PlayMode == Event.PlayModes.once)
                    {
                        var sound = soundList.Find((x) => x.soundFileName == ev.SoundName);
                        if (sound != null)
                        {
                            RemoveSound(sound);
                            sound = new SoundEffect(ev.SoundName, ev.Volume, ev);
                            sound.parent = this;
                            soundList.Add(sound);
                        }
                    }

                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                // Do some stuff
                Hide();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Dispose();
            foreach (var sound in soundList)
            {
                sound.Dispose();
            }
            List<string> lines = new List<string>(File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Settings.txt"));
            lines[2] = Size.Width.ToString() + "," + Size.Height.ToString() + "|" + Location.X.ToString() + "," + Location.Y.ToString();
            File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Settings.txt", lines.ToArray());
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm();
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    var info = new FileInfo(form.sound);
                }
                catch
                {
                    return;
                }

                Keys key = Keys.None;
                foreach (var item in form.keys)
                {
                    key = key | item;
                }

                foreach (var v in events)
                {
                    if (v.modifier == form.mods && v.key == key)
                        return;
                }

                int linenum = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Sounds.txt").Length;

                Button btn = new Button();
                Event ev = new Event(form.mods, key, form.sound, form.icon, linenum, btn, form.Volume, Event.PlayModes.multi);
                events.Add(ev);

                if (!(ev.modifier == Sound_events.ModifierKeys.None && ev.key == Keys.None))
                    hook.RegisterHotKey(ev.modifier, ev.key);

                string line = ev.modifier.ToString() + "|" + ev.key.ToString() + "|" + ev.SoundName + "|" + ev.ImageName + "|" + ev.Volume.ToString() + "|" + ev.PlayMode.ToString();

                File.AppendAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Sounds.txt", new string[1] { line });

                btn.Parent = panel;

                btn.Size = new Size(100, 100);
                try
                {
                    btn.BackgroundImage = Image.FromFile(ev.ImageName);
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.BackColor = Color.Transparent;
                }
                catch
                {

                }
                btn.FlatStyle = FlatStyle.Popup;

                btn.MouseUp += new MouseEventHandler(delegate (Object o, MouseEventArgs args)
                {
                    if (args.Button == MouseButtons.Left)
                        hook_KeyPressed(btn, new KeyPressedEventArgs(ev.modifier, ev.key));
                    else if (args.Button == MouseButtons.Right)
                    {
                        EditEvent(ev);
                    }
                });
                int index = panel.Controls.GetChildIndex(btn, false);
                panel.Controls.SetChildIndex(btn, index - 1);

                ev.EchoAmount = form.EchoAmount;
                ev.UseEcho = form.UseEcho;
            }
        }

        void EditEvent(Event a_ev)
        {
            AddForm form = new AddForm();
            form.AllowFileEdit = a_ev.lineNum > -1;
            form.sound = a_ev.SoundName;
            form.icon = a_ev.ImageName;
            form.mods = a_ev.modifier;
            form.keys = new List<Keys>(new Keys[1] { a_ev.key });
            form.Volume = a_ev.Volume;
            form.UseEcho = a_ev.UseEcho;
            form.EchoAmount = a_ev.EchoAmount;
            form.Playmode = a_ev.PlayMode;
            var result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    var info = new FileInfo(form.sound);
                }
                catch
                {
                    return;
                }           

                Keys key = Keys.None;
                foreach (var item in form.keys)
                {
                    key = key | item;
                }

                foreach (var v in events)
                {
                    if (v == a_ev)
                        continue;
                    if (v.modifier == form.mods && v.key == key)
                        return;
                }

                a_ev.key = key;
                a_ev.modifier = form.mods;
                a_ev.Volume = form.Volume;
                a_ev.PlayMode = form.Playmode;
                if (form.AllowFileEdit)
                {
                    a_ev.SoundName = form.sound;
                    a_ev.ImageName = form.icon;

                    string line = a_ev.modifier.ToString() + "|" + a_ev.key.ToString() + "|" + a_ev.SoundName + "|" + a_ev.ImageName + "|" + a_ev.Volume.ToString() + "|" + a_ev.PlayMode.ToString();
                    string[] lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Sounds.txt");
                    lines[a_ev.lineNum] = line;
                    File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Sounds.txt", lines);
                }
                else
                {
                    string[] lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Settings.txt");
                    if (lines.Length < 2)
                    {
                        var temp = new List<string>(lines);
                        temp.Add(a_ev.Volume.ToString());
                        lines = temp.ToArray();
                    }
                    else
                        lines[1] = a_ev.Volume.ToString();
                    File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Settings.txt", lines);
                }

                if (!(a_ev.modifier == Sound_events.ModifierKeys.None && a_ev.key == Keys.None))
                {
                    ReRegister();
                }

                a_ev.button.Parent = panel;

                try
                {
                    a_ev.button.BackgroundImage = Image.FromFile(a_ev.ImageName);
                    a_ev.button.BackgroundImageLayout = ImageLayout.Stretch;
                    a_ev.button.BackColor = Color.Transparent;
                }
                catch
                {

                }
                a_ev.button.FlatStyle = FlatStyle.Popup;

                a_ev.EchoAmount = form.EchoAmount;
                a_ev.UseEcho = form.UseEcho;
            }
            else if (result == DialogResult.Ignore)
            {
                if (!form.AllowFileEdit)
                    return;

                List<string> lines = new List<string>(File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Sounds.txt"));
                lines.RemoveAt(a_ev.lineNum);
                File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Sounds.txt", lines.ToArray());
                a_ev.button.Dispose();
                events.Remove(a_ev);
                a_ev = null;
                ReRegister();
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptions();
        }

        void ShowOptions()
        {
            OptionsForm form = new OptionsForm();
            form.MicIndex = Helper.Mic;
            form.OutIndex = Helper.Out;
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                Helper.Mic = form.MicIndex;
                Helper.Out = form.OutIndex;

                string[] lines = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Settings.txt");
                lines[0] = Helper.Mic.ToString() + "|" + Helper.Out.ToString();
                File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SoundEvents/Settings.txt", lines);
            }
        }

        void ReRegister()
        {
            hook.Dispose();
            hook = new KeyboardHook();
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            foreach (var ev in events)
            {
                if (!(ev.modifier == Sound_events.ModifierKeys.None && ev.key == Keys.None))
                    hook.RegisterHotKey(ev.modifier, ev.key);
            }
        }

        public void RemoveSound(SoundEffect a_sound)
        {
            a_sound.Dispose();
            soundList.Remove(a_sound);
        }
    }
}
