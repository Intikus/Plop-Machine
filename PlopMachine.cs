using BepInEx;
using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Security;
using UnityEngine;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Rendering;

[module: UnverifiableCode]
#pragma warning disable CS0618 // Type or member is obsolete
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618 // Type or member is obsolete

namespace PlopMachine
{
    [BepInPlugin("Intikus.plopmachine", "PlopMachine", "0.0.1")]
    public class PlopMachine : BaseUnityPlugin
    {

        readonly float magicnumber = 1.0594630776202568303519954093385f;
        int CurrentKey = 0;
        int QueuedModulation = 0;
        int debugtimer = 0;

        readonly string[,] notesinkey =
        {
            {"Gb", "Ab", "Bb", "B" , "Db", "Eb", "F" , "Gb"}, //Gb  (the same as F#) 
            {"Db", "Eb", "F" , "Gb", "Ab", "Bb", "C" , "Db"}, //Db 
            {"Ab", "Bb", "C" , "Db", "Eb", "F" , "G" , "Ab"}, //Ab
            {"Eb", "F" , "G" , "Ab", "Bb", "C" , "D" , "Eb"}, //Eb
            {"Bb", "C" , "D" , "Eb", "F" , "G" , "A" , "Bb"}, //Bb
            {"F" , "G" , "A" , "Bb", "C" , "D" , "E" , "F" }, //F
            {"C" , "D" , "E" , "F" , "G" , "A" , "B" , "C" }, //C
            {"G" , "A" , "B" , "C" , "D" , "E" , "F#", "G" }, //G
            {"D" , "E" , "F#", "G" , "A" , "B" , "C#", "D" }, //D
            {"A" , "B" , "C#", "D" , "E" , "F#", "G" , "A" }, //A
            {"E" , "F#", "G#", "A" , "B" , "C#", "D#", "E" }, //E
            {"B" , "C#", "D#", "E" , "F#", "G#", "A#", "B" }, //B
            {"F#", "G#", "A#", "B" , "C#", "D#", "F" , "F#"}, //F#   (the same as Gb)
        };
        public readonly int[,] intsinkey = 
        {
            { 6  , 8  , 10 , 11 , 1  , 3  , 5  , 6  }, //Gb  (the same as F#) 
            { 1  , 3  , 5  , 6  , 8  , 10 , 0  , 1  }, //Db 
            { 8  , 10 , 0  , 1  , 3  , 5  , 7  , 8  }, //Ab
            { 3  , 5  , 7  , 8  , 10 , 0  , 2  , 3  }, //Eb
            { 10 , 0  , 2  , 3  , 5  , 7  , 9  , 10 }, //Bb
            { 5  , 7  , 9  , 10 , 0  , 2  , 4  , 5  }, //F
            { 0  , 2  , 4  , 5  , 7  , 9  , 11 , 0  }, //C
            { 7  , 9  , 11 , 0  , 2  , 4  , 6  , 7  }, //G
            { 2  , 4  , 6  , 7  , 9  , 11 , 1  , 2  }, //D
            { 9  , 11 , 1  , 2  , 4  , 6  , 8  , 9  }, //A
            { 4  , 6  , 8  , 9  , 11 , 1  , 3  , 4  }, //E
            { 11 , 1  , 3  , 4  , 6  , 8  , 10 , 11 }, //B
            { 6  , 8  , 10 , 11 , 1  , 3  , 5  , 6  }, //F#   (the same as Gb)
        };
        //todo: make a switch thing that makes the notes into the ints immediatelly
        
        
        
        /* the switch statement
        int transposition = 0;
        switch (NoteNow)
        {
            case "C":
                transposition = 0;
                break;
        
            case "C#" or "Db":
                transposition = 1;
                break;
        
            case "D":
                transposition = 2;
                break;
        
            case "D#" or "Eb":
                transposition = 3;
                break;
        
            case "E":
                transposition = 4;
                break;
        
            case "F":
                transposition = 5;
                break;
        
            case "F#" or "Gb":
                transposition = 6;
                break;
        
            case "G":
                transposition = 7;
                break;
        
            case "G#" or "Ab":
                transposition = 8;
                break;
        
            case "A":
                transposition = 9;
                break;
        
            case "A#" or "Bb":
                transposition = 10;
                break;
        
            case "B":
                transposition = 11;
                break;
        }
        */



        int lel = 27;
        int lel2 = 0;
        int lel3 = 0;
        //int lel4 = 0;
        bool yoyo = true;
        bool yoyo2 = true;
        bool yoyo3 = true;
        bool yoyo4 = true;
        bool yoyo5 = true;
        bool yoyo6 = true;
        bool yoyo7 = true;
        bool yoyo8 = true;
        bool yoyo9 = true;
        bool meme = false;

        bool EntryRequest = true;

        bool entrychord = false;
        bool entryriff = false;
        bool entrysample = false;

        bool playingchord = false;
        bool playingriff = false;
        bool playingsample = false;

        string chordnotes = "yosup";
        string chordleadups = "yosup";

        string riffline = "the command line yo like [pow,pow]";
        string riffleadups = "just the name of the chord";

        bool PatchTest = false;


        int chordstopwatch = 0;
        string chordqueuedentry = "yeah";

        bool inwaitmode = false;
        int riffstopwatch = 0;
        string UpcomingEntry = "Balaboofake";         //important to set a first one
        string[] theline;
        int riffindex;
        int rifflength;
        string riffcurrentvar;
        bool islooping;
        int tilestasked;
        int loopcountdown;
        float riffd;
        int upcomingdelay;


        string sampleinfo = "hehe";
        string sampleleadups = "lel";
        string[] theinfo;
        int indexofsample;
        //int pitchofsample;
        float speeedofsample = 1;
        int sampletransposition;
        int samplestopwatch;

        //readonly bool firstchordevahhhhhhasbeenplayedd = false;

        bool Lslot1 = false;
        bool Lslot2 = false;
        bool Lslot3 = false;
        int Ltime1 = 12;
        int Ltime2 = 12;
        int Ltime3 = 12;
        string Lnote1 = "yo";
        string Lnote2 = "yo";
        string Lnote3 = "yo";
        int agora = 1;
        float phob;

        //string teststring = "hehe";
        string CurrentRegion;

        //float distancetovibeepicentre = 0;

        float intensity = 1.0f;

        AudioReverbPreset[] thepresets = [AudioReverbPreset.Off, AudioReverbPreset.Generic, AudioReverbPreset.PaddedCell, AudioReverbPreset.Room, AudioReverbPreset.Bathroom, AudioReverbPreset.Livingroom, AudioReverbPreset.Stoneroom, AudioReverbPreset.Auditorium, AudioReverbPreset.Concerthall, AudioReverbPreset.Cave, AudioReverbPreset.Arena, AudioReverbPreset.Hangar, AudioReverbPreset.CarpetedHallway, AudioReverbPreset.Hallway, AudioReverbPreset.StoneCorridor, AudioReverbPreset.Alley, AudioReverbPreset.Forest, AudioReverbPreset.City, AudioReverbPreset.Mountains, AudioReverbPreset.Quarry, AudioReverbPreset.Plain, AudioReverbPreset.ParkingLot, AudioReverbPreset.SewerPipe, AudioReverbPreset.Underwater, AudioReverbPreset.Drugged, AudioReverbPreset.Dizzy, AudioReverbPreset.Psychotic, AudioReverbPreset.User];
        /*
        float IntikusdecayHFRatio = 0.5f;
        float IntikusdecayTime = 1f;
        float Intikusdensity = 1f;
        float Intikusdiffusion = 1f;
        float IntikusdryLevel = 1f;
        float IntikushfReference = 1f;
        float IntikuslfReference = 1f;
        float IntikusreflectionsDelay = 1f;
        float IntikusreflectionsLevel = 1f;
        float IntikusreverbDelay = 1f;
        float IntikusreverbLevel = 1f;
        float IntikusreverbPreset = 1f;
        float Intikusroom = 1f;
        float IntikusroomHF = 1f;
        float IntikusroomLF = 1f;
        */
        float[] RangeAdjs = [0.1f, 0.2f, 0.5f, 1f, 2f, 5f, 10f, 50f, 100f, 500f, 1000f, 2000f, 5000f];
        //float[] ack = [IntikusdecayHFRatio, IntikusdecayTime, Intikusdensity, Intikusdiffusion, IntikusdryLevel, IntikushfReference, IntikuslfReference, IntikusreflectionsDelay, IntikusreflectionsLevel, IntikusreverbDelay, IntikusreverbLevel, IntikusreverbPreset, Intikusroom, IntikusroomHF, IntikusroomLF]

        float[] revbvalues = [0.5f, 1.0f, 100.0f, 100.0f, 0f, 5000.0f, 250.0f, 0.0f, -10000f, 0.04f, 0.0f, 1f, 0.0f, 0.0f, 0.0f];
        string[] revbnames = ["decayHFRatio: 0.1 - 2.0", "decayTime (s): 0.1 - 20.0", "density%: 0.0 - 100.0", "diffusion%: 0.0 - 100.0", "dryLevel(md): -10000.0 - 0.0", "hfReference(Hz): 1000.0 - 20000.0", "lfReference(Hz): 20.0 - 1000.0", "reflectionsDelay(mB): -10000.0 - 2000.0", "reflectionsLevel(mB): -10000.0 - 1000.0", "reverbDelay(s): 0.0 - 0.1", "reverbLevel(mB): -10000.0 - 2000.0", "reverbPreset: what", "room(mb): -10000.0 - 0.0", "roomHF(mB): -10000.0 - 0.0", "roomLF(mB): -10000.0 - 0.0"];
        public static class EnumExt_AudioFilters
        {
#pragma warning disable 0649
            public static RoomSettings.RoomEffect.Type AudioFiltersReverb;
#pragma warning restore 0649
        }

        public void OnEnable()
        {
            On.Music.IntroRollMusic.ctor += IntroRollMusic_ctor;
            On.RainWorldGame.Update += RainWorldGame_Update;
            
            On.AmbientSoundPlayer.TryInitiation += AmbientSoundPlayer_TryInitiation;
            On.PlayerGraphics.DrawSprites += hehedrawsprites;

            On.RainWorldGame.ctor += RainWorldGame_ctor;
        }

        bool fileshavebeenchecked = false;
        string[][] ChordInfos;
        //{
        // hellothere thinks making files are a cool idea (for the things (the mod)) (((instead of having htem all in the dll (this)))
        //};
        static readonly Dictionary<string, VibeZone[]> vibeZonesDict = new();
        struct VibeZone
        {
            public VibeZone(string room, float radius, string songName)
            {
                this.room = room;
                this.radius = radius;
                this.songName = songName;
            }

            public string room;
            public float radius;
            public string songName;
        }
        private void RainWorldGame_ctor(On.RainWorldGame.orig_ctor orig, RainWorldGame self, ProcessManager manager)
        {
            orig.Invoke(self, manager);
            try
            {
                if (!fileshavebeenchecked)
                {
                    Debug("Checking files");
                    string[] mydirs = AssetManager.ListDirectory("soundeffects", false, true);
                    Debug("Printing all directories in soundeffects");
                    foreach (string dir in mydirs)
                    {
                        //Debug(dir);


                        string filename = GetFolderName(dir);
                        //Debug(filename);

                        //C:/ Program Files(x86) / Steam / steamapps / common / Rain World - My Copy / RainWorld_Data / StreamingAssets\soundeffects\!Entries.txt
                        if (filename == "!entries.txt")
                        {
                            Debug("The file exists actually");
                            string[] lines = File.ReadAllLines(dir);

                            Debug("it has read all its lines");
                            List<string[]> listtho = new List<string[]>();
                            foreach (string line in lines)
                            {
                                string[] chord = line.Split(new char[] { '$' });
                                Debug("Plopmachine:  Registered Entry: " + line + " in ");
                                listtho.Add(chord);
                            }
                            Debug("it has added the thongs");
                            ChordInfos = listtho.ToArray();
                        }
                        //Debug("It got to this end");
                    }
                    Debug("Yo it's done with sfx");
                    string[] dirs = AssetManager.ListDirectory("world", true, true);
                    foreach (string dir in dirs)
                    {
                        string regName = GetFolderName(dir).ToUpper();
                        string path = dir + Path.DirectorySeparatorChar + "vibe_zones.txt";
                        if (File.Exists(path) && !vibeZonesDict.ContainsKey(regName))
                        {
                            Debug($"It found the path for vibezone {regName} tho");
                            string[] lines = File.ReadAllLines(path);
                            VibeZone[] zones = new VibeZone[lines.Length];
                            for (int i = 0; i < lines.Length; i++)
                            {
                                string[] arr = lines[i].Split(',');
                                zones[i] = new VibeZone(arr[0], float.Parse(arr[1]), arr[2]);
                                Debug($"{arr[0]}, {arr[1]}, {arr[2]}");
                            }
                            vibeZonesDict.Add(regName, zones);
                        }
                    }
                    Debug("Yo wassup it went past worlds");
                    fileshavebeenchecked = true;
                }
            }
            catch (Exception e)
            {
                Debug(e);
                //throw;
            }
        }
        static string GetFolderName(string path)
        {
            string[] arr = path.Split(Path.DirectorySeparatorChar);
            return arr[arr.Length - 1];
        }

        public void hehedrawsprites(On.PlayerGraphics.orig_DrawSprites orig, PlayerGraphics self, RoomCamera.SpriteLeaser sLeaser, RoomCamera rCam, float timeStacker, Vector2 camPos)
        {
            //orig(self, sLeaser, timeStacker, rCam, timeStacker, camPos);
            orig(self, sLeaser, rCam, timeStacker, camPos);
            Color camocoloryo = rCam.PixelColorAtCoordinate(self.player.mainBodyChunk.pos);
            //Debug($"So the color at here issss {color}");
            //Color mycolor = sLeaser[self.startSprite].color;
            foreach (var sprite in sLeaser.sprites)
            {
                sprite.color = camocoloryo;
            }
        }


        /*
            //On Initialize()
            IDetour hookTestMethodA = new Hook(
                    typeof(Class Of Property).GetProperty("property without get_", BindingFlags.Instance | BindingFlags.Public).GetGetMethod(),
                    typeof(Class where hook is located).GetMethod("name of the methodHK", BindingFlags.Static | BindingFlags.Public)
                );
            //On Static hook class
                public delegate Type_of_property orig_nameOfProperty(Class self);
                
                public static Type_of_property get_PropertyHK(orig_nameOfProperty orig_nameOfProperty, Class self)
                {
                return orig_nameOfProperty(self);
                }
        */



        //public delegate int orig_lengthSamples(int self);
        //
        //    public static int get_CreateHK(orig_lengthSamples orig_lengthSamples, AudioClip self)
        //    {
        //        
        //        return orig_lengthSamples(self);
        //    }



        public int IndexTOCKInt(int integer)
        {
            int treatedkey = CurrentKey + 6;

            int Note = intsinkey[treatedkey, integer - 1];

            return Note;
        }

        private SoundID[] SampDict(string length)
        {
            //Debug($"It's trying to get length {length}");
            SoundID[] library = new SoundID[7]; //to do:  make better
            string acronym = CurrentRegion.ToUpper();
            VibeZone[] newthings;
            bool diditwork = vibeZonesDict.TryGetValue(acronym, out newthings);
            //we retrieve a newthings array (one of many vibezones)
            //Debug("C" + diditwork);
            VibeZone newthing = newthings[0]; //TEMP DUMMY FOR UNTIL HELLOTHERE'S REQUIUM
            //and pick the one that is closer
            //Debug("d");
            string patch = newthing.songName;
            //Debug(patch);
            //switch (acronym)
            //{
            //    case "su" or "hi":
            //        patch = "Trisaw";
            //        break;
            //
            //    case "gw" or "sh":
            //        patch = "Bell";
            //        break;
            //
            //    case "ss" or "sb" or "sl":
            //        patch = "Litri";
            //        break;
            //
            //    case "cc" or "si":
            //        patch = "Sine";
            //        break;
            //
            //    case "ds" or "lf" or "uw":
            //        patch = "Clar";
            //        break;
            //    default:
            //        patch = "Trisaw";
            //        break;
            //}
            //cc(chimney cannopy)
            //ds(drainage system)
            //gw(garbage wastes)
            //hi(industrial complex)
            //lf(farm array)
            //sb("sb subterranian")
            //sh(shadow)
            //si(sky place)
            //sl(shoreline)
            //ss(fivebepples)
            //su(outskirts)
            //uw(underhang and wall)
            switch (length)
            {
                case "L":
                    switch (patch)
                    {
                        case "Trisaw":
                            library = [C1LongTrisaw, C2LongTrisaw, C3LongTrisaw, C4LongTrisaw, C5LongTrisaw, C6LongTrisaw, C7LongTrisaw];
                            break;

                        case "Clar":
                            library = [C1LongClar, C2LongClar, C3LongClar, C4LongClar, C5LongClar, C6LongClar, C7LongClar];
                            break;

                        case "Litri":
                            library = [C1LongLitri, C2LongLitri, C3LongLitri, C4LongLitri, C5LongLitri, C6LongLitri, C7LongLitri];
                            break;

                        case "Sine":
                            library = [C1LongSine, C2LongSine, C3LongSine, C4LongSine, C5LongSine, C6LongSine, C7LongSine];
                            break;

                        case "Bell":
                            library = [C1LongBell, C2LongBell, C3LongBell, C4LongBell, C5LongBell, C6LongBell, C7LongBell];
                            break;
                    }
                    break;
                case "M":
                    switch (patch)
                    {
                        case "Trisaw":
                            library = [C1MediumTrisaw, C2MediumTrisaw, C3MediumTrisaw, C4MediumTrisaw, C5MediumTrisaw, C6MediumTrisaw, C7MediumTrisaw];
                            break;

                        case "Clar":
                            library = [C1MediumClar, C2MediumClar, C3MediumClar, C4MediumClar, C5MediumClar, C6MediumClar, C7MediumClar];
                            break;

                        case "Litri":
                            library = [C1MediumLitri, C2MediumLitri, C3MediumLitri, C4MediumLitri, C5MediumLitri, C6MediumLitri, C7MediumLitri];
                            break;

                        case "Sine":
                            library = [C1MediumSine, C2MediumSine, C3MediumSine, C4MediumSine, C5MediumSine, C6MediumSine, C7MediumSine];
                            break;

                        case "Bell":
                            library = [C1MediumBell, C2MediumBell, C3MediumBell, C4MediumBell, C5MediumBell, C6MediumBell, C7MediumBell];
                            break;

                    }
                    break;
                case "S":
                    switch (patch)
                    {
                        case "Trisaw":
                            library = [C1ShortTrisaw, C2ShortTrisaw, C3ShortTrisaw, C4ShortTrisaw, C5ShortTrisaw, C6ShortTrisaw, C7ShortTrisaw];
                            break;

                        case "Clar":
                            library = [C1ShortClar, C2ShortClar, C3ShortClar, C4ShortClar, C5ShortClar, C6ShortClar, C7ShortClar];
                            break;

                        case "Litri":
                            library = [C1ShortLitri, C2ShortLitri, C3ShortLitri, C4ShortLitri, C5ShortLitri, C6ShortLitri, C7ShortLitri];
                            break;

                        case "Sine":
                            library = [C1ShortSine, C2ShortSine, C3ShortSine, C4ShortSine, C5ShortSine, C6ShortSine, C7ShortSine];
                            break;

                        case "Bell":
                            library = [C1ShortBell, C2ShortBell, C3ShortBell, C4ShortBell, C5ShortBell, C6ShortBell, C7ShortBell];
                            break;

                    }
                    break;
            }
            return library;
        }

        private int Peeps(int low, int high)
        {

            int tlow = Peep(low);
            int thigh = Peep(high);

            if (tlow == thigh) { thigh++; }

            int lol = UnityEngine.Random.Range(tlow, thigh);

            return lol;
        }

        private int Peep(int value)  //marked for die
        {
            //take 10 as an example, agora being.... 2-3 people? 
            // i can follow a 2.5 people rule
            //agora then has to be changed (from being just an int to
            //be the result of a method)

            if (agora <= 1) { phob = 1; }
            //if (agora > 1) { phob = (float)((Mathf.Log((float)(agora * 0.7)) / 3.8) + 1); }
            if (agora > 1) { phob = (float)((Mathf.Log((float)(agora * 0.8)) / 4.5) + 1); }

            //Debug(phob);
            float fvalue = value;
            float avalue = fvalue / phob;

            string st1 = avalue.ToString();
            //Debug($"{st1}, Peep");

            //Debug(st1);
            int PointPos = st1.IndexOf('.');

            //Debug($"PointPos, Funny");
            if (PointPos == -1) { st1 += ".00000"; }
            else
            {
                string lettersafterpoint = st1.Substring(PointPos);
                int lettersamount = lettersafterpoint.Length - 1;

                switch (lettersamount)
                {
                    case 4:
                        st1 += "0";
                        break;
                    case 3:
                        st1 += "00";
                        break;
                    case 2:
                        st1 += "000";
                        break;
                    case 1:
                        Debug("what");
                        st1 += "00000";
                        break;
                    default:
                        break;
                }

                //Debug($"{st1}, Peep 2");
            }

            string[] parts = st1.Split('.');
            int former = int.Parse(parts[0]);
            string latter = parts[1].Substring(0, 5);
            int latterint = int.Parse(latter);

            //int dicedint = UnityEngine.Random.Range(0, 100000);
            int dicedint = UnityEngine.Random.Range(0, 100000);

            //1.99999 latter
            //  44246 diced
            if (latterint > dicedint) { former++; }
            return former;

        }

        private void Plop(string input, VirtualMicrophone mic)
        {
            string s = input.ToString();


            string[] parts = s.Split('-');


            string slib = parts[0]; //either L for Long, M for Medium, or S for Short
            int oct = int.Parse(parts[1]);
            int ind = int.Parse(parts[2]);

            //Debug($"So the string is {s}, which counts as {parts.Length} amounts of parts. {slib}, {oct}, {ind}");

            SoundID[] slopb = SampDict(slib);

            //Debug($"and it picked a sample through the SampDict, called {slopb}");  
            //Debug($"Samples picked: [{string.Join(", ", slopb.ToList())}]");

            //SoundID sampleused = slopb[oct]; //one octave higher
            SoundID sampleused = slopb[oct - 1];
            //Debug("Octave integer " + oct + ". sampleused: " + sampleused);

            //Debug($"It uses the sample {sampleused}");

            int transposition = IndexTOCKInt(ind);

            float speeed = 1;

            speeed *= Mathf.Pow(magicnumber, transposition);

            // get intensity and turn that into too 
            // (which will also be reverb effect here then)

            if (RainWorld.ShowLogs)
            {
                //Debug($"the note that played: {NoteNow}, {transposition} at {CurrentKey}");
            }

            PlayThing(sampleused, mic, speeed);

        }

        private void PushModulation()
        {
            int dicedsign = UnityEngine.Random.Range(-5, 3);
            if (dicedsign <= 0) dicedsign = -1; else dicedsign = 1; //6/8th chance to go downwards, unstable by choice
            int dicedint = UnityEngine.Random.Range(0, 777) / (Math.Abs(QueuedModulation) + 1);
            int deadint = CurrentKey; //debug thing
            if (dicedint <= 77 && dicedint > 44) CurrentKey += 1 * dicedsign;
            if (dicedint <= 44 && dicedint > 7) CurrentKey += 2 * dicedsign;
            if (dicedint <= 7) CurrentKey += 3 * dicedsign;

            Debug($"The chance rolled {dicedint}, modified by {QueuedModulation}, it goes to {dicedsign}. So it was {deadint} and now is {CurrentKey}");
            QueuedModulation = 0;
            IdleFetter.Analyze(this);

            //CurrentKey += QueuedModulation;
            
            switch (CurrentKey)
            {
                case -7:
                    CurrentKey = 5;
                    break;
                case -8:
                    CurrentKey = 4;
                    break;
                case -9:
                    CurrentKey = 3;
                    break;
                case 7:
                    CurrentKey = -5;
                    break;
                case 8:
                    CurrentKey = -4;
                    break;
                case 9:
                    CurrentKey = -3;
                    break;
                default:
                    break;
            }
        }
        private void PlayEntry(VirtualMicrophone mic)
        {
            //Debug($"yo sup dude,{EntryRequest} {UpcomingEntry} {chordqueuedentry} {entrychord} {entryriff} {entrysample} {playingchord} {playingriff} {playingsample}");

            // string[] CurrentChordLol = new string[3];

            //string sowhatwasthechorddude = "yo";                obsolete

            // this part will check if it's a chord or entry, and seperate it to be one of the two

            if (EntryRequest == true)
                for (int i = 0; i < ChordInfos.GetLength(0); i++)
                {
                    //Debug($"Nuclear {UpcomingEntry} vs Coughing {ChordInfos[i, 0]}... Round {i}, begin!");

                    //Debug("ummm");
                    if (UpcomingEntry == ChordInfos[i][0])
                    {
                        Debug($"So it's gonna start a {UpcomingEntry}, with the key {CurrentKey}");
                        //Debug($"{ChordInfos[i, 0]},{ChordInfos[i, 1]},{ChordInfos[i, 2]},{ChordInfos[i, 3]}");

                        switch (ChordInfos[i][1])
                        {
                            case "Chord":
                                //sowhatwasthechorddude = UpcomingEntry;
                                chordnotes = ChordInfos[i][2];
                                chordleadups = ChordInfos[i][3];
                                entrychord = true;
                                break;
                            case "Riff":
                                riffline = ChordInfos[i][2];
                                riffleadups = ChordInfos[i][3];
                                //Debug(ChordInfos[i, 3] +" " + riffleadups);
                                entryriff = true;
                                break;
                            case "Sample":
                                sampleinfo = ChordInfos[i][2];
                                sampleleadups = ChordInfos[i][3];
                                entrysample = true;
                                break;
                        }
                    }
                }
            //Debug("Done with entryrequest");
            if (EntryRequest == true && entrychord == true)
            {
                //playing a chord
                //Debug("Starts the chord: " + UpcomingEntry + " " + chordnotes + "    and leadup: " + chordleadups);
                PushModulation();
                EntryRequest = false;
                entrychord = false;
                string[] inst = chordnotes.Split(',');

                string chord = inst[0];
                string bass = inst[1];

                //string[] notes = chord.Split(' ');
                string[] notes = chord.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < notes.Length; i++)
                {
                    Plop(notes[i], mic);
                    //Debug($"It is playing the Notes?{chord},{notes.Length},{i}, {notes[i]}... {debugtimer}");    
                }
                //Debug($"done playing them???{EntryRequest}");                                  !!!!!!!!!!
                //string[] bassnotes = bass.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] bassnotes = bass.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int sowhichoneisitboss = UnityEngine.Random.Range(0, bassnotes.Length);

                Plop(bassnotes[sowhichoneisitboss], mic); //THIS is where it fucked up, which was because it had a space before the comma
                //Debug("And i played a Bass note");


                //all notes have been played, moving onto liason

                string[] leadups = chordleadups.Split('|');
                int butwhatnowboss = UnityEngine.Random.Range(0, leadups.Length);
                string leadup = leadups[butwhatnowboss];

                string[] leadupinfo = leadup.Split(',');

                chordqueuedentry = leadupinfo[0];
                int low = int.Parse(leadupinfo[1]);
                int high = int.Parse(leadupinfo[2]);
                string liaisonnotes = leadupinfo[3];
                QueuedModulation = int.Parse(leadupinfo[4]);

                int madeupchordcountdown = Peeps(low, high);

                chordstopwatch = madeupchordcountdown * 4;

                if (liaisonnotes == "0")
                {
                    Lslot1 = false;
                    Lslot2 = false;
                    Lslot3 = false;
                }
                else
                {
                    string[] thebabes = liaisonnotes.Split(' ');

                    //ok so when 0 = short 1 = mid 2 = long

                    int Ltype1 = UnityEngine.Random.Range(0, 3);
                    int Ltype2 = UnityEngine.Random.Range(0, 3);
                    int Ltype3 = UnityEngine.Random.Range(0, 3);

                    switch (thebabes.Length)
                    {
                        case 1:
                            Lslot1 = true;
                            switch (Ltype1)
                            {
                                case 0:
                                    Lnote1 = "S-" + thebabes[0];
                                    break;
                                case 1:
                                    Lnote1 = "M-" + thebabes[0];
                                    break;
                                case 2:
                                    Lnote1 = "L-" + thebabes[0];
                                    break;
                            }
                            Ltime1 = Peeps(6, 39);
                            Lslot2 = false;
                            Lslot3 = false;
                            break;
                        case 2:
                            Lslot1 = true;
                            switch (Ltype1)
                            {
                                case 0:
                                    Lnote1 = "S-" + thebabes[0];
                                    break;
                                case 1:
                                    Lnote1 = "M-" + thebabes[0];
                                    break;
                                case 2:
                                    Lnote1 = "L-" + thebabes[0];
                                    break;
                            }
                            Ltime1 = Peeps(6, 36);
                            Lslot2 = true;
                            switch (Ltype2)
                            {
                                case 0:
                                    Lnote2 = "S-" + thebabes[1];
                                    break;
                                case 1:
                                    Lnote2 = "M-" + thebabes[1];
                                    break;
                                case 2:
                                    Lnote2 = "L-" + thebabes[1];
                                    break;
                            }
                            Ltime2 = Peeps(9, 39);
                            Lslot3 = false;
                            break;
                        case 3:
                            Lslot1 = true;
                            switch (Ltype1)
                            {
                                case 0:
                                    Lnote1 = "S-" + thebabes[0];
                                    break;
                                case 1:
                                    Lnote1 = "M-" + thebabes[0];
                                    break;
                                case 2:
                                    Lnote1 = "L-" + thebabes[0];
                                    break;
                            }
                            Ltime1 = Peeps(3, 49);
                            Lslot2 = true;
                            switch (Ltype2)
                            {
                                case 0:
                                    Lnote2 = "S-" + thebabes[1];
                                    break;
                                case 1:
                                    Lnote2 = "M-" + thebabes[1];
                                    break;
                                case 2:
                                    Lnote2 = "L-" + thebabes[1];
                                    break;
                            }
                            Ltime2 = Peeps(9, 59);
                            Lslot3 = true;
                            switch (Ltype3)
                            {
                                case 0:
                                    Lnote3 = "S-" + thebabes[2];
                                    break;
                                case 1:
                                    Lnote3 = "M-" + thebabes[2];
                                    break;
                                case 2:
                                    Lnote3 = "L-" + thebabes[2];
                                    break;
                            }
                            Ltime3 = Peeps(12, 55);
                            break;
                    }
                }
                playingchord = true;
                //Debug($"Info given of: Timer: {low} {high}, {chordstopwatch}, And times: {Ltime1}, {Ltime2}, {Ltime3}, and Key {CurrentKey} of chord (put another name here)... {debugtimer}");
            }
            //Debug("Done with entrychord");

            if (playingchord == true)
            {
                //Debug("It's playing liaisonnotes" + $": {Lslot1}, {Ltime1} {Lnote1}. {Lslot2}, {Ltime2} {Lnote2}. {Lslot3}, {Ltime3} {Lnote3}. ");
                //REMINDER: LNOTES CURRENTLY NEED A LENGTH, 
                //FUTURE UPDATE MIGHT TRY TO RANDOMISE THE LENGTH. LTYPE
                
                //WORKING ON THIS DOWN THERE

                if (chordstopwatch == 0)
                {
                    EntryRequest = true;
                    UpcomingEntry = chordqueuedentry;
                    //Debug($"{UpcomingEntry} will play");       
                    playingchord = false;
                }
                else
                {
                    if (Lslot1 == true)
                    {
                        if (Ltime1 == 0)
                        {
                            Plop(Lnote1, mic);

                            if (Lnote1.Contains("S-")) Ltime1 = Peeps(30, 120);
                            if (Lnote1.Contains("M-")) Ltime1 = Peeps(80, 200);
                            if (Lnote1.Contains("L-")) Ltime1 = Peeps(150, 300);

                            Debug($"Liaison 1 is {Lnote1}, time delayed= {Ltime1}");
                        }
                        else
                        {
                            Ltime1--;
                        }

                    }
                    if (Lslot2 == true)
                    {
                        if (Ltime2 == 0)
                        {
                            Plop(Lnote2, mic);
                            if (Lnote2.Contains("S-")) Ltime2 = Peeps(30, 120);
                            if (Lnote2.Contains("M-")) Ltime2 = Peeps(80, 200);
                            if (Lnote2.Contains("L-")) Ltime2 = Peeps(150, 300);
                        }
                        else
                        {
                            Ltime2--;
                        }
                    }
                    if (Lslot3 == true)
                    {
                        if (Ltime3 == 0)
                        {
                            Plop(Lnote3, mic);
                            if (Lnote3.Contains("S-")) Ltime3 = Peeps(30, 120);
                            if (Lnote3.Contains("M-")) Ltime3 = Peeps(80, 200);
                            if (Lnote3.Contains("L-")) Ltime3 = Peeps(150, 300);
                        }
                        else
                        {
                            Ltime3--;
                        }
                    }
                    chordstopwatch--;
                }
            }
            //Debug("Done with Playingchord");

            if (EntryRequest == true && entryriff == true)
            {
                EntryRequest = false;
                entryriff = false;
                PushModulation();
                theline = riffline.Split(',');
                // take { "Yooo", "Entry", "3-1,2,3-2,2,3-5 3-7,4,3-5 3-7,4,3-5 3-7,6,3-5 3-7,6,3-5 3-7,8,!,3-6", "Triad"} for example
                riffindex = 0;
                rifflength = theline.Length;
                playingriff = true;
            }

            if (playingriff)
            {
                if (inwaitmode)
                {
                    riffstopwatch--;//just to double check but 0 is the same as 1, you're delaying it whatever
                    if (riffstopwatch <= 0) inwaitmode = false; // :3
                }
                else
                {
                    if (riffindex < rifflength)
                    {
                        //if (pushingindex) { riffindex = queuedindex; pushingindex = false; }
                        //Debug("Started they thing");
                        //Debug("hullo");
                        //randomise it, if it's an array, then also remove extras if else
                        //Debug($"{riffindex}, {rifflength}, {riffcurrentvar}, {theline}");
                        //Debug(splitvar[0]);
                        //Debug(splitvar.Length);
                        riffcurrentvar = theline[riffindex];
                        Debug("Currently treating " + riffindex + ". With currentvar: " + riffcurrentvar);
                        string[] splitvar = riffcurrentvar.Split(' ');
                        int whichofthese = UnityEngine.Random.Range(0, splitvar.Length);
                        string treatedvar = splitvar[whichofthese];

                        //Debug("hello");
                        //testing if it's just a number
                        int intivarp;
                        bool umitsanumber = int.TryParse(treatedvar, out intivarp);
                        if (umitsanumber)
                        {
                            riffstopwatch = intivarp;
                            inwaitmode = true;
                        }
                        else
                        {
                            Debug(treatedvar);
                            if (treatedvar.Contains("loop"))
                            {
                                Debug("Matched it as a loop");
                                if (islooping)
                                {
                                    loopcountdown--;
                                    if (loopcountdown > 0)
                                    {
                                        //queuedindex = riffindex - tilestasked;
                                        //pushingindex = true;
                                        riffindex -= tilestasked + 1;
                                        Debug($"Went backwards {tilestasked} to {riffindex}");
                                    }
                                    if (loopcountdown <= 0)
                                    {
                                        islooping = false;
                                    }
                                    Debug("Done with islooping, looping countdown is " + loopcountdown);
                                }
                                //finish the timeloop by not doin anythin
                                else
                                {
                                    //start the timeloop of the things
                                    string[] Supdude = treatedvar.Split(new string[] { "loop" }, StringSplitOptions.None);

                                    tilestasked = int.Parse(Supdude[0]);
                                    loopcountdown = int.Parse(Supdude[1]);
                                    islooping = true;
                                    riffindex -= tilestasked + 1; //the extra 1 is to compensate for riffindex being ++;'d at the end, it goes 5 backwards FROM this one, 1 will be 1 back
                                    Debug($"He thinks he's {riffindex}, {tilestasked}");
                                }
                            }
                            if (treatedvar.Contains("d"))
                            {
                                char lollollol = treatedvar[1];

                                switch (lollollol)
                                {
                                    case '=':
                                        riffd = float.Parse(treatedvar.Substring(2));
                                        break;
                                    case '+':
                                        riffd += float.Parse(treatedvar.Substring(2));
                                        break;
                                    case '-':
                                        riffd -= float.Parse(treatedvar.Substring(2));
                                        if (riffd < 0)
                                            riffd = 0;
                                        break;
                                    case '*':
                                        //hehehehe hellothere fuck uuu >:))))))
                                        riffd *= float.Parse(treatedvar.Substring(2));
                                        break;
                                    case '/':
                                        if (riffd != 0 || float.Parse(treatedvar.Substring(2)) != 0.0f)
                                            riffd /= float.Parse(treatedvar.Substring(2));
                                        break;
                                    default:
                                        break;
                                }
                                riffstopwatch = (int)Math.Round((double)riffd, 0);
                                Debug($"Matched it as a Delta, waiting for {riffd}, {riffstopwatch}");
                                inwaitmode = true;
                            }

                            if (treatedvar.Contains("!"))
                            {
                                Debug("Matched it as a chorder, the leadups are");
                                EntryRequest = true;
                                //Debug(riffleadups);
                                string[] leadups = riffleadups.Split('|');
                                Debug("Splits it up");
                                //for (int i = 0; i < leadups.Length - 1; i++)
                                //{
                                //    Debug(leadups[i]);
                                //}
                                int butwhatnowboss = UnityEngine.Random.Range(0, leadups.Length);
                                //Debug("Picks a random one");
                                string leadup = leadups[butwhatnowboss];
                                //Debug("Picks " + leadup);
                                UpcomingEntry = leadup;
                                //Debug(riffleadups + " " + leadups + " "+ butwhatnowboss + " " + leadup + " " + UpcomingEntry);
                            }
                            if (treatedvar.Contains("L-") || treatedvar.Contains("M-") || treatedvar.Contains("S-"))
                            {
                                Debug("Matched it as a noter");
                                //will assume its a note for now
                                treatedvar = treatedvar.ToString();
                                Plop(treatedvar, mic);
                            }
                            if (treatedvar.Contains("D-"))
                            {

                                Debug("Matched it as a Dynamic noter");
                                var riffnextvar = theline[riffindex + 1];
                                Debug("Predicting future index to be " + riffindex + "+1. With thenextvar being: " + riffnextvar);
                                string[] splitnextvar = riffnextvar.Split(' ');
                                int whichofthesenexts = UnityEngine.Random.Range(0, splitnextvar.Length);
                                string treatednextvar = splitnextvar[whichofthesenexts];

                                int intinextvarp;
                                bool umnextanumber = int.TryParse(treatednextvar, out intinextvarp);
                                if (umnextanumber == true)
                                {
                                    upcomingdelay = intinextvarp;
                                }
                                else
                                {
                                    if (treatednextvar.Contains("d"))
                                    {
                                        {
                                            char lollollol = treatednextvar[1];
                                            float dummyriffd = riffd;
                                            switch (lollollol)
                                            {
                                                case '=':
                                                    dummyriffd = float.Parse(treatednextvar.Substring(2));
                                                    break;
                                                case '+':
                                                    dummyriffd += float.Parse(treatednextvar.Substring(2));
                                                    break;
                                                case '-':
                                                    dummyriffd -= float.Parse(treatednextvar.Substring(2));
                                                    if (dummyriffd < 0)
                                                        dummyriffd = 0;
                                                    break;
                                                case '*':
                                                    //hehehehe hellothere fuck uuu >:))))))
                                                    dummyriffd *= float.Parse(treatednextvar.Substring(2));
                                                    break;
                                                case '/':
                                                    if (dummyriffd != 0 || float.Parse(treatednextvar.Substring(2)) != 0.0f)
                                                        dummyriffd /= float.Parse(treatednextvar.Substring(2));
                                                    break;
                                                default:
                                                    break;
                                            }
                                            upcomingdelay = (int)Math.Round((double)dummyriffd, 0);
                                            Debug($"Matched it as a Delta, waiting for {riffd}, {riffstopwatch}");
                                        }
                                    }
                                }
                                treatedvar = treatedvar.Substring(1);
                                int currentsounds = mic.soundObjects.Count;
                                Debug("I have calculated upcomingdelay to be " + upcomingdelay + " and the amount of currently to be " + currentsounds);
                                if ((upcomingdelay < 3.5f) || currentsounds > 22)//either 3 or 2
                                {
                                    treatedvar = "S" + treatedvar;
                                }
                                else if (((upcomingdelay >= 3) && (upcomingdelay < 55)) || currentsounds > 17) //either 75 or 40, or 55
                                {
                                    treatedvar = "M" + treatedvar;
                                }
                                else //(upcomingdelay >= 75)
                                {
                                    treatedvar = "L" + treatedvar;
                                }
                                //Debug(treatedvar);
                                Plop(treatedvar, mic);
                            }
                        }
                        //Debug("HEY THIS ONE DOES THE THING IT*S COOL");
                        riffindex++;
                    }
                    else
                    {
                        playingriff = false;
                        //Debug("it is OVER");
                    }
                }
            }


            if (EntryRequest == true && entrysample == true)
            {
                EntryRequest = false;
                entrysample = false;
                PushModulation();
                theinfo = sampleinfo.Split(',');
                // take { "Firstsample", "Entry", "Lol,1,200", "Triad"} for example
                SoundID whichsample = FetchSoundID(theinfo[0]);
                indexofsample = int.Parse(theinfo[1]);
                samplestopwatch = int.Parse(theinfo[2]);

                sampletransposition = IndexTOCKInt(indexofsample);
                playingsample = true;
                speeedofsample = 1;

                speeedofsample *= Mathf.Pow(magicnumber, sampletransposition);

                PlayThing(whichsample, mic, speeedofsample);
            }

            if (playingsample == true)
            {
                if (samplestopwatch == 0)
                {
                    playingsample = false;
                    //Debug(riffleadups);
                    string[] leadups = sampleleadups.Split('|');
                    int butwhatnowboss = UnityEngine.Random.Range(0, leadups.Length);
                    string leadup = leadups[butwhatnowboss];
                    UpcomingEntry = leadup;
                    EntryRequest = true;
                }
                else
                {
                    samplestopwatch--;
                }
            }
        }

        private SoundID FetchSoundID(string soundid)
        {
            switch (soundid)
            {
                case "HelloA":
                    return HelloA;
                default://add as many as you want here lol just remember to have them match
                    return HelloB;
            }
        }
        private void AmbientSoundPlayer_TryInitiation(On.AmbientSoundPlayer.orig_TryInitiation orig, AmbientSoundPlayer self)
        {
            //Debug("fuckoff");
        }


        private void PlayThing(SoundID Note, VirtualMicrophone virtualMicrophone, float speed)
        {

            //virtualMicrophone.PlaySound(Note, 0f, intensity*0.5f, speed);

            float pan = 0;
            float vol = intensity * 0.5f;
            float pitch = speed;

            //Debug($"Trying to play a {Note}");
            try
            {
                if (virtualMicrophone.visualize)
                {
                    virtualMicrophone.Log(Note);
                }

                if (!virtualMicrophone.AllowSound(Note))
                {
                    Debug($"Too many sounds playing, denying a {Note}");
                    return;
                }
                SoundLoader.SoundData soundData = virtualMicrophone.GetSoundData(Note, -1);
                if (virtualMicrophone.SoundClipReady(soundData))
                {

                    var thissound = new VirtualMicrophone.DisembodiedSound(virtualMicrophone, soundData, pan, vol, pitch, false, 0);

                    /*
                    var reverb = thissound.gameObject.AddComponent<AudioReverbFilter>();
                    reverb.reverbPreset = thepresets[lel];


                    //reverb.room             = 10000*((float)Math.Pow(intensity, 0.75)-1);
                    //reverb.reflectionsLevel = 10000*((float)Math.Pow(intensity, 0.75)-1);
                    //reverb.dryLevel         = 10000*((float)Math.Pow((-intensity+1.0), 0.75)-1);
                    
                    reverb.decayHFRatio         = revbvalues[0];
                    reverb.decayTime            = revbvalues[1];
                    reverb.density              = revbvalues[2];
                    reverb.diffusion            = revbvalues[3];
                    reverb.dryLevel             = revbvalues[4];
                    reverb.hfReference          = revbvalues[5];
                    reverb.lfReference          = revbvalues[6];
                    reverb.reflectionsDelay     = revbvalues[7];
                    reverb.reflectionsLevel     = revbvalues[8];
                    reverb.reverbDelay          = revbvalues[9];
                    reverb.reverbLevel          = revbvalues[10];
                    reverb.reverbPreset         = AudioReverbPreset.User;
                    reverb.room                 = revbvalues[12];
                    reverb.roomHF               = revbvalues[13];
                    reverb.roomLF               = revbvalues[14];
                    */


                    //Debug(10000*((float)Math.Pow(intensity, 0.75)-1));
                    //Debug(10000*((float)Math.Pow((-intensity+1.0), 0.75)-1));


                    //var delay = thissound.gameObject.AddComponent<AudioEchoFilter>();


                    virtualMicrophone.soundObjects.Add(thissound);
                }
                else
                {
                    Debug($"Soundclip not ready");
                    return;
                }

                if (RainWorld.ShowLogs)
                {
                    //Debug($"the note that played: {Note} at {speed}");
                }
            }
            catch (Exception e)
            {
                Debug($"Log {e}");
            }

        }


        //Needs a rework, should check up with henp about creating and setting buffers and shit
        //i want to be able to go like,, when going through the notes i can go like "ok,, i pick you up and you up"
        //and when at the end of it i can deliver them like "alright, these notes will be the liaisons, fix em up for me"
        //then it shall set it up under me to make that going (remember to remove the ones from previously), and then have them be the played notes now then.

        //but now that i think about it, maybe it would be cool if it could sometimes arpegiate stuffs too.
        //picture this, a wholey new liaison method (machinery), which you can add notes (only add removing will be hard and idk why) or clear all notes
        //everytime you add a new thingy, it'll Analyse all the notes when a new one gets added, and assign a pitchindex 0 to x from lowest to highest
        //i'll call this the idle notes
        //you can switch its mode to be between arping all the notes or notes individually
        // when arping as a collective it can pick between it can also arpegiate randomly, up and/or down
        // randomly
        //      totally randomly, picking one of the notes
        // in order of melodic index. 
        //      upwards
        //      downwards
        //      upwards-downwards-upwards-downwards-upwards-downwards-upwards
        // 
        // in order index
        // individually 
        // give each one a random float between 0 and 1 that is multiplied by something and made into an int, that's everyone's delay
        struct Liaison
        {
            public Liaison(string note, int timer, int yoffset)
            {
                this.note = note;
                this.timer = timer;
                this.yoffset = yoffset;
            //    string[] hey = note.Substring(2).Split('-');//maybe this'll fuck up in the future :3
            //    freqnumb = int.Parse(hey[0]) * 100 + int.Parse(hey[1]);
            }
            public string note;
            public int timer;
            public int yoffset;
            //public int freqnumb; obsolete as they were only used once one place and therefore i can replace it with a better thing 
        
        }
        //List<string[]> listtho = new List<string[]>();
        public static class IdleFetter
        {
            //public static void constructor(){}
            static List<Liaison> LiaisonList = []; //list of the Liaison(s) currently playing
            static int[] liaisonrace = new int[0]; //arp pitch sorted array that will be remade with the analyze function
            static int maxliaisons = 8; //self imposed limit on the amount of notes
            static public bool isindividualistic = false; //setting for whether it'll treat things as individualistic
            static bool upperswitch = true;
            static int Idletimer = 0;
            static int uniqueyoffset = 0;
            static public string arpingmode = "upwards";
            static int arpstep = 0;
            static bool arpgoingupwards = false;
            static int arpcountdown = 20;
            static List<int> randomsetsacrificeboard = [];
            

            //public Liaison slot3; //public Liaison slot4; //public Liaison slot5; //public Liaison slot6; //public Liaison slot7; //public Liaison slot8;

            public static void Update(VirtualMicrophone mic, PlopMachine plopmachine)
            {
                //This method will presumably be the one to be called every frame when this is active, it'll thus be the one to update the timers
                // but it won't update, well, timers *per sae*. this thing when call will then activate the method that's fitting, but....
                // a revelation has befallen me that its JUST methods called in here, NOT the clocks
                // 
                //General notes:
                // when switching over to collective mode, prompt an analyze
                //
                //will check what mode it is
                //
                

                Idletimer++;
                if (isindividualistic) //upperswitch is true here
                {
                    Anarchy(mic, plopmachine);
                    upperswitch = true;
                }
                else //shall be false here
                {
                    if (upperswitch)
                    {
                        Analyze(plopmachine);
                        upperswitch = false;
                    }
                    arpcountdown--;
                    if (arpcountdown <= 0)
                    {
                        if (LiaisonList.Count != 0) //bruh why should it ever be less than zero lmao (that's the joke here)
                        {
                            arpcountdown = (int)(Math.Cos(UnityEngine.Mathf.PerlinNoise(Idletimer / 400f, 7f + (Idletimer / 1600f)) * Math.PI) * -23 + 30);
                            CollectiveArpStep(mic, plopmachine);
                        }
                    }
                }

            }

            private static void Anarchy(VirtualMicrophone mic, PlopMachine plopMachine)
            {
                for (int i = 0; i < LiaisonList.Count; i++)
                {
                    Liaison liaison = LiaisonList[i];
                    if (liaison.timer > 0)
                    {
                        liaison.timer--;
                        LiaisonList[i] = new Liaison(liaison.note, liaison.timer, liaison.yoffset);
                    }
                    else
                    {
                        plopMachine.Plop(liaison.note, mic);
                        int moneydym1 = (int)(Math.Cos(UnityEngine.Mathf.PerlinNoise(Idletimer / 400f, liaison.yoffset + (Idletimer / 1600f)) * Math.PI) * -100 + 110);
                        moneydym1 = plopMachine.Peep(moneydym1);
                        LiaisonList[i] = new Liaison(liaison.note, moneydym1, liaison.yoffset);
                        Debug($"We're so here, playing a {liaison.note}, and their {liaison.yoffset} makes a delay of {moneydym1}");
                    }
                }
            }

            //https://www.ableton.com/en/manual/live-midi-effect-reference/
            //private static void PlayNote()
            //{
            //    if (Lnote3.Contains("S-")) Ltime3 = Peeps(30, 120);
            //    if (Lnote3.Contains("M-")) Ltime3 = Peeps(80, 200);
            //    if (Lnote3.Contains("L-")) Ltime3 = Peeps(150, 300);
            //}



            //int moneydym1 = (int)(Math.Cos(UnityEngine.Mathf.PerlinNoise(debugtimer / 400f, 00f + (debugtimer / 1600f)) * Math.PI) * -100 + 110);

            //collective mode
            public static void Analyze(PlopMachine plopmachine)
            {
                //will get all the notes of the liaison list
                //then make each of them into a number, the higher the note, the higher the number, all inserted into a list 
                //make another array which is created by turning all the notes into a "first place" in being lowest, lowest being 0,
                //a new array will be made, which sorts by placement(1st, 2nd, 3rd) the indexes of anotherarray
                //this array is liaisonrace, and is used when arpegiating as a collective
                //this should always be called when the list is updated (add or wipe), because an old list is decrepit
                //this is usefull for arping melodically
                List<int> LiaisonsFreqNumbs = [];
                List<int> LiaisonsIndex = [];
                int index = 0;
                foreach (Liaison heyo in LiaisonList)
                {
                    string[] hey = heyo.note.Substring(2).Split('-');//maybe this'll fuck up in the future :3
                    int freqnumb = int.Parse(hey[0]) * 100 + plopmachine.IndexTOCKInt(int.Parse(hey[1]));
                    LiaisonsFreqNumbs.Add(freqnumb);
                    LiaisonsIndex.Add(index);
                    Debug($"Car warranty {freqnumb}, It's index in the LiaisonList: {index}");
                    index++;
                }//there's ceraintly a better and less costly ways of going about but :PPPPPP

                int[] LiaisonsFreqNumbsArray = LiaisonsFreqNumbs.ToArray();
                int[] LiaisonsIndexArrayThatllBeSwayed = LiaisonsIndex.ToArray();
                Array.Sort(LiaisonsFreqNumbsArray, LiaisonsIndexArrayThatllBeSwayed);
                liaisonrace = LiaisonsIndexArrayThatllBeSwayed;
            
            }
            public static void PrintRace()
            {
                Debug("Liaisonrace being printed individually from left to right. The number is the index, the latter is what it represents.");
                Debug("Remember that the sequence they're PRINTED in is the order of the liaisonrace, NOT the index shown(as that is just the pointer)");
                foreach (int i in liaisonrace)
                {
                    Debug(i + " " + LiaisonList[i].note);
                }
            }

            public static void Add(string note, PlopMachine plopmachine)
            {
                string mynote = "M-" + note;

                Liaison helo = new Liaison(mynote, plopmachine.Peeps(30, 80), uniqueyoffset);
                LiaisonList.Add(helo);
                uniqueyoffset += 10;
                //makes a new liaison with the note string
                //give it a cordinate that's unique
                //adds a liaison to the liaison
                //IF IN COLLECTIVE MODE, prompts an Analyze
                if (!isindividualistic) { Analyze(plopmachine); }
                if (!isindividualistic) { Debug($"Added {mynote}, a {helo.note} with analysis"); } else { Debug($"Added {mynote}, a {helo.note} without analysis"); }
            }
            public static void Wipe(PlopMachine plopmachine)
            { 
                //clears the liaisonlist
                //resets the CollectiveArpStep's step to 0
                //IF IN COLLECTIVE MODE, prompts an analyze
                LiaisonList.Clear();
                arpstep = 0;
                if (!isindividualistic) { Analyze(plopmachine); }
            }
            public static void RandomMode()
            {
                //switch statement that takes a number and changes
                //arpingmode to be: "upwards" "downwards" "switchwards" "random" "randomset"
                int sowhichoneboss = UnityEngine.Random.Range(0, 5);
                switch (sowhichoneboss)
                {
                    case 0:
                        arpingmode = "upwards";
                        break;
                    case 1:
                        arpingmode = "downwards";
                        break;
                    case 2:
                        arpingmode = "switchwards";
                        break;
                    case 3:
                        arpingmode = "random";
                        break;
                    case 4:
                        arpingmode = "randomset";
                        break;
                }
            }
            public static void CollectiveArpStep(VirtualMicrophone mic, PlopMachine plopMachine)
            {
                //uses the logic of the mode selected by the string of arpingmode to *arp* between the notes,
                //plays the note that it's selected, then selects the next one
                //LiaisonList.Count();  arpstep     liasonrace
                //so, arpstep is the current step in the arpegio, normal
                //liaisonrace interprets the number and gives back another number which is the index of the note in liaison
                //when picking an index from the liaisonlist, it returns a Liaison, that liaison has got properties, one of them is its note, which'll be a string.

                //Debug($"it plays a thing at uhhhh   {arpstep},,,,   then it's the index  {liaisonrace[arpstep]}.. .  ..  {LiaisonList[liaisonrace[arpstep]].note}");
                plopMachine.Plop(LiaisonList[liaisonrace[arpstep]].note, mic); //so it plays the previous one
                //Debug("Hello so this one works" + Idletimer);
                

                switch (arpingmode)
                {
                    case "upwards":
                        arpstep++;
                        if (arpstep >= LiaisonList.Count) { arpstep = 0; }
                        break;

                    case "downwards":
                        arpstep--;
                        if (arpstep < 0) { arpstep = LiaisonList.Count-1; }
                        break;

                    case "switchwards":
                        if (arpgoingupwards)
                        {
                            arpstep++;
                            if (arpstep >= LiaisonList.Count) 
                            { //will have already played the top one, so back down it go
                                arpstep = LiaisonList.Count - 2;
                                arpgoingupwards = false;
                            }
                        }
                        else
                        {
                            arpstep--;
                            if (arpstep < 0)
                            {
                                arpstep = 1;
                                arpgoingupwards = true;
                            }
                        }
                        break;

                    case "random":
                        arpstep = UnityEngine.Random.Range(0, LiaisonList.Count);
                        break;

                    case "randomset":
                        if (randomsetsacrificeboard.Count == 0)
                        {
                            foreach (int i in liaisonrace)
                            {
                                randomsetsacrificeboard.Add(i);
                            }
                        }
                        //Debug("sodiditevengethere");
                        //Debug("when the count is "+randomsetsacrificeboard.Count);
                        //foreach (int i in randomsetsacrificeboard)
                        //{
                        //    Debug("Ummmm there's " + i);
                        //}
                        int thesacrifice = UnityEngine.Random.Range(0, randomsetsacrificeboard.Count);
                        //Debug($"SO WE'RE SACRIFICING THE {thesacrifice}, in which there is a {randomsetsacrificeboard[thesacrifice]} at");
                        arpstep = liaisonrace[randomsetsacrificeboard[thesacrifice]];
                        randomsetsacrificeboard.RemoveAt(thesacrifice);
                        //Debug("So it's here");
                        //Debug("arpstep given is=" + arpstep);
                        break;


                }
            }
        }
            
            //.cameras[0].virtualMicrophone

        //private void Player_Update(On.Player.orig_Update orig, Player self, bool eu)
        private void RainWorldGame_Update(On.RainWorldGame.orig_Update orig, RainWorldGame self)
        {
            orig(self);
            debugtimer++;
            var mic = self.cameras[0].virtualMicrophone;
            CurrentRegion = self.world.region.name;
            

            //PlayEntry(mic);

            //Debug($"CurrentRegion is: {CurrentRegion}");
            if (CurrentRegion == null)
            {
                CurrentRegion = "sl";
            }



            //if (debugtimer % 160 == 00) { PlayThing(TriangleC4, mic, 1); }
            //if (debugtimer % 160 == 20) { PlayThing(TriangleC4, mic, (float)Math.Pow(magicnumber, 4)); }
            //if (debugtimer % 160 == 40) { PlayThing(TriangleC4, mic, (float)Math.Pow(magicnumber, 7)); }
            //if (debugtimer % 160 == 60) { PlayThing(TriangleC4, mic, (float)Math.Pow(magicnumber, 11)); }

            if (PatchTest)
            {
                if (debugtimer % 3000 == 000) { Plop("L-1-1", mic); }
                if (debugtimer % 3000 == 015) { Plop("L-1-2", mic); }
                if (debugtimer % 3000 == 030) { Plop("L-1-3", mic); }
                if (debugtimer % 3000 == 045) { Plop("L-1-4", mic); }
                if (debugtimer % 3000 == 060) { Plop("L-1-5", mic); }
                if (debugtimer % 3000 == 075) { Plop("L-1-6", mic); }
                if (debugtimer % 3000 == 090) { Plop("L-1-7", mic); }

                if (debugtimer % 3000 == 200) { Plop("L-2-1", mic); }
                if (debugtimer % 3000 == 215) { Plop("L-2-2", mic); }
                if (debugtimer % 3000 == 230) { Plop("L-2-3", mic); }
                if (debugtimer % 3000 == 245) { Plop("L-2-4", mic); }
                if (debugtimer % 3000 == 260) { Plop("L-2-5", mic); }
                if (debugtimer % 3000 == 275) { Plop("L-2-6", mic); }
                if (debugtimer % 3000 == 290) { Plop("L-2-7", mic); }

                if (debugtimer % 3000 == 400) { Plop("L-3-1", mic); }
                if (debugtimer % 3000 == 415) { Plop("L-3-2", mic); }
                if (debugtimer % 3000 == 430) { Plop("L-3-3", mic); }
                if (debugtimer % 3000 == 445) { Plop("L-3-4", mic); }
                if (debugtimer % 3000 == 460) { Plop("L-3-5", mic); }
                if (debugtimer % 3000 == 475) { Plop("L-3-6", mic); }
                if (debugtimer % 3000 == 490) { Plop("L-3-7", mic); }

                if (debugtimer % 3000 == 600) { Plop("L-4-1", mic); }
                if (debugtimer % 3000 == 615) { Plop("L-4-2", mic); }
                if (debugtimer % 3000 == 630) { Plop("L-4-3", mic); }
                if (debugtimer % 3000 == 645) { Plop("L-4-4", mic); }
                if (debugtimer % 3000 == 660) { Plop("L-4-5", mic); }
                if (debugtimer % 3000 == 675) { Plop("L-4-6", mic); }
                if (debugtimer % 3000 == 690) { Plop("L-4-7", mic); }

                if (debugtimer % 3000 == 800) { Plop("L-5-1", mic); }
                if (debugtimer % 3000 == 815) { Plop("L-5-2", mic); }
                if (debugtimer % 3000 == 830) { Plop("L-5-3", mic); }
                if (debugtimer % 3000 == 845) { Plop("L-5-4", mic); }
                if (debugtimer % 3000 == 860) { Plop("L-5-5", mic); }
                if (debugtimer % 3000 == 875) { Plop("L-5-6", mic); }
                if (debugtimer % 3000 == 890) { Plop("L-5-7", mic); }

                if (debugtimer % 3000 == 1000) { Plop("L-6-1", mic); }
                if (debugtimer % 3000 == 1015) { Plop("L-6-2", mic); }
                if (debugtimer % 3000 == 1030) { Plop("L-6-3", mic); }
                if (debugtimer % 3000 == 1045) { Plop("L-6-4", mic); }
                if (debugtimer % 3000 == 1060) { Plop("L-6-5", mic); }
                if (debugtimer % 3000 == 1075) { Plop("L-6-6", mic); }
                if (debugtimer % 3000 == 1090) { Plop("L-6-7", mic); }

                if (debugtimer % 3000 == 1200) { Plop("L-7-1", mic); }
                if (debugtimer % 3000 == 1215) { Plop("L-7-2", mic); }
                if (debugtimer % 3000 == 1230) { Plop("L-7-3", mic); }
                if (debugtimer % 3000 == 1245) { Plop("L-7-4", mic); }
                if (debugtimer % 3000 == 1260) { Plop("L-7-5", mic); }
                if (debugtimer % 3000 == 1275) { Plop("L-7-6", mic); }
                if (debugtimer % 3000 == 1290) { Plop("L-7-7", mic); }

                if (debugtimer % 3000 > 1600) { PlayEntry(mic); }
            }
            else
            {
                //PlayEntry(mic);
                IdleFetter.isindividualistic = false;
                //Debug("We got into here yo");

                if (debugtimer % 1000000 == 201) IdleFetter.Add("4-3", this); //4 
                if (debugtimer % 1000000 == 210) IdleFetter.Add("4-7", this); //4 
                if (debugtimer % 1000000 == 235) IdleFetter.Add("3-5", this); //4 
                if (debugtimer % 1000000 == 250) IdleFetter.Add("3-1", this); //4 
                if (debugtimer % 1000000 == 275) IdleFetter.Add("5-3", this); //4 
                if (debugtimer % 1000000 == 279) //4
                {
                    IdleFetter.Add("5-7", this); 
                    IdleFetter.Analyze(this);
                    IdleFetter.PrintRace();
                }
                IdleFetter.Update(mic, this);
                //if (debugtimer % 1000000 == 1495) { IdleFetter.arpingmode = "downwards"; Debug("SWITCH"); }
                //if (debugtimer % 1000000 == 2295) { IdleFetter.arpingmode = "switchwards"; Debug("SWITCH"); }
                //if (debugtimer % 1000000 == 2995) { IdleFetter.arpingmode = "random"; Debug("SWITCH"); }
                //if (debugtimer % 1000000 == 3305) { IdleFetter.arpingmode = "randomset"; Debug("SWITCH"); } 
                //if (debugtimer % 1000000 == 4095) { IdleFetter.isindividualistic = true; Debug("BIG SWITCH"); }


            }


            

            //yoyo = Input.GetKey("1");
            //if (Input.GetKey("1") && !yoyo)
            //{
            //    //agora -= 1;
            //    lel++;
            //    if (lel > thepresets.Length) { lel = 0; }
            //    Debug("Reverb selected: " + thepresets[lel]);
            //}

            if (Input.GetKey("1") && !yoyo)
            {
                QueuedModulation = -2;
                PushModulation();
            }
            yoyo = Input.GetKey("1");
            if (Input.GetKey("2") && !yoyo2)
            {
                QueuedModulation = 2;
                PushModulation();
            }
            yoyo2 = Input.GetKey("2");

            if (Input.GetKey("5") && !yoyo3)
            {
                revbvalues[lel2] = revbvalues[lel2] + RangeAdjs[lel3];
                Debug($"Currently: {revbvalues[lel2]}");
            }
            yoyo3 = Input.GetKey("5");
            if (Input.GetKey("6") && !yoyo4)
            {
                //] RangeAdjs
                if (lel3 == thepresets.Length-1) { lel3 = 0; }
                else
                {
                    lel3++;
                }
                Debug(RangeAdjs[lel3]);
                //  revbvalues
                //  revbnames  this one switches the amount of shit
            }
            yoyo4 = Input.GetKey("6");
            if (Input.GetKey("7") && !yoyo5)
            {
                if (lel2 == thepresets.Length-1) { lel2 = 0; }
                else
                {
                    lel2++;
                }
                Debug(revbnames[lel2]);
                Debug($"Currently: {revbvalues[lel2]}");
                //switches them around, this one to the right as lel3
            }
            yoyo5 = Input.GetKey("7");
            if (Input.GetKey("t") && !yoyo6)
            {
                revbvalues[lel2] = revbvalues[lel2] - RangeAdjs[lel3];
                Debug($"Currently: {revbvalues[lel2]}");
            }
            yoyo6 = Input.GetKey("t");
            if (Input.GetKey("y") && !yoyo7)
            {
                if (lel3 == 0) { lel3 = thepresets.Length-1; }
                else
                {
                    lel3--;
                }
                Debug($"Adjusts by: {RangeAdjs[lel3]}");
            }
            yoyo7 = Input.GetKey("y");
            if (Input.GetKey("u") && !yoyo8)
            {
                if (lel2 == 0) { lel2 = thepresets.Length - 1; }
                else
                {
                    lel2--;
                }
                Debug(revbnames[lel2]);
                Debug($"Currently: {revbvalues[lel2]}");
            }
            yoyo8 = Input.GetKey("u"); 
            if (Input.GetKey("p") && !yoyo9)
            {
                Debug("This preset's values are");
                for (int i = 0; i < thepresets.Length-1; i++)
                {
                    Debug(revbnames[i] + " " + revbvalues[i]);
                }
            }
            yoyo9 = Input.GetKey("p");
        }


        public static readonly SoundID HelloC = new SoundID("HelloC", register: true);
        public static readonly SoundID HelloD = new SoundID("HelloD", register: true);
        public static readonly SoundID HelloE = new SoundID("HelloE", register: true);
        public static readonly SoundID HelloF = new SoundID("HelloF", register: true);
        public static readonly SoundID HelloG = new SoundID("HelloG", register: true);
        public static readonly SoundID HelloA = new SoundID("HelloA", register: true);
        public static readonly SoundID HelloB = new SoundID("HelloB", register: true);


        public static readonly SoundID TriangleC1 = new SoundID("TriangleC1", register: true);
        public static readonly SoundID TriangleC2 = new SoundID("TriangleC2", register: true);
        public static readonly SoundID TriangleC3 = new SoundID("TriangleC3", register: true);
        public static readonly SoundID TriangleC4 = new SoundID("TriangleC4", register: true);
        public static readonly SoundID TriangleC5 = new SoundID("TriangleC5", register: true);
        public static readonly SoundID TriangleC6 = new SoundID("TriangleC6", register: true);
        public static readonly SoundID TriangleC7 = new SoundID("TriangleC7", register: true);

        public static readonly SoundID LongswavC1 = new SoundID("LongswavC1", register: true);
        public static readonly SoundID LongswavC2 = new SoundID("LongswavC2", register: true);
        public static readonly SoundID LongswavC3 = new SoundID("LongswavC3", register: true);
        public static readonly SoundID LongswavC4 = new SoundID("LongswavC4", register: true);
        public static readonly SoundID LongswavC5 = new SoundID("LongswavC5", register: true);
        public static readonly SoundID LongswavC6 = new SoundID("LongswavC6", register: true);
        public static readonly SoundID LongswavC7 = new SoundID("LongswavC7", register: true);


        public static readonly SoundID C1LongSine = new SoundID("C1LongSine", register: true);
        public static readonly SoundID C2LongSine = new SoundID("C2LongSine", register: true);
        public static readonly SoundID C3LongSine = new SoundID("C3LongSine", register: true);
        public static readonly SoundID C4LongSine = new SoundID("C4LongSine", register: true);
        public static readonly SoundID C5LongSine = new SoundID("C5LongSine", register: true);
        public static readonly SoundID C6LongSine = new SoundID("C6LongSine", register: true);
        public static readonly SoundID C7LongSine = new SoundID("C7LongSine", register: true);
        public static readonly SoundID C1MediumSine = new SoundID("C1MediumSine", register: true);
        public static readonly SoundID C2MediumSine = new SoundID("C2MediumSine", register: true);
        public static readonly SoundID C3MediumSine = new SoundID("C3MediumSine", register: true);
        public static readonly SoundID C4MediumSine = new SoundID("C4MediumSine", register: true);
        public static readonly SoundID C5MediumSine = new SoundID("C5MediumSine", register: true);
        public static readonly SoundID C6MediumSine = new SoundID("C6MediumSine", register: true);
        public static readonly SoundID C7MediumSine = new SoundID("C7MediumSine", register: true);
        public static readonly SoundID C1ShortSine = new SoundID("C1ShortSine", register: true);
        public static readonly SoundID C2ShortSine = new SoundID("C2ShortSine", register: true);
        public static readonly SoundID C3ShortSine = new SoundID("C3ShortSine", register: true);
        public static readonly SoundID C4ShortSine = new SoundID("C4ShortSine", register: true);
        public static readonly SoundID C5ShortSine = new SoundID("C5ShortSine", register: true);
        public static readonly SoundID C6ShortSine = new SoundID("C6ShortSine", register: true);
        public static readonly SoundID C7ShortSine = new SoundID("C7ShortSine", register: true);
        public static readonly SoundID C1LongLitri = new SoundID("C1LongLitri", register: true);
        public static readonly SoundID C2LongLitri = new SoundID("C2LongLitri", register: true);
        public static readonly SoundID C3LongLitri = new SoundID("C3LongLitri", register: true);
        public static readonly SoundID C4LongLitri = new SoundID("C4LongLitri", register: true);
        public static readonly SoundID C5LongLitri = new SoundID("C5LongLitri", register: true);
        public static readonly SoundID C6LongLitri = new SoundID("C6LongLitri", register: true);
        public static readonly SoundID C7LongLitri = new SoundID("C7LongLitri", register: true);
        public static readonly SoundID C1MediumLitri = new SoundID("C1MediumLitri", register: true);
        public static readonly SoundID C2MediumLitri = new SoundID("C2MediumLitri", register: true);
        public static readonly SoundID C3MediumLitri = new SoundID("C3MediumLitri", register: true);
        public static readonly SoundID C4MediumLitri = new SoundID("C4MediumLitri", register: true);
        public static readonly SoundID C5MediumLitri = new SoundID("C5MediumLitri", register: true);
        public static readonly SoundID C6MediumLitri = new SoundID("C6MediumLitri", register: true);
        public static readonly SoundID C7MediumLitri = new SoundID("C7MediumLitri", register: true);
        public static readonly SoundID C1ShortLitri = new SoundID("C1ShortLitri", register: true);
        public static readonly SoundID C2ShortLitri = new SoundID("C2ShortLitri", register: true);
        public static readonly SoundID C3ShortLitri = new SoundID("C3ShortLitri", register: true);
        public static readonly SoundID C4ShortLitri = new SoundID("C4ShortLitri", register: true);
        public static readonly SoundID C5ShortLitri = new SoundID("C5ShortLitri", register: true);
        public static readonly SoundID C6ShortLitri = new SoundID("C6ShortLitri", register: true);
        public static readonly SoundID C7ShortLitri = new SoundID("C7ShortLitri", register: true);
        public static readonly SoundID C1LongBell = new SoundID("C1LongBell", register: true);
        public static readonly SoundID C2LongBell = new SoundID("C2LongBell", register: true);
        public static readonly SoundID C3LongBell = new SoundID("C3LongBell", register: true);
        public static readonly SoundID C4LongBell = new SoundID("C4LongBell", register: true);
        public static readonly SoundID C5LongBell = new SoundID("C5LongBell", register: true);
        public static readonly SoundID C6LongBell = new SoundID("C6LongBell", register: true);
        public static readonly SoundID C7LongBell = new SoundID("C7LongBell", register: true);
        public static readonly SoundID C1MediumBell = new SoundID("C1MediumBell", register: true);
        public static readonly SoundID C2MediumBell = new SoundID("C2MediumBell", register: true);
        public static readonly SoundID C3MediumBell = new SoundID("C3MediumBell", register: true);
        public static readonly SoundID C4MediumBell = new SoundID("C4MediumBell", register: true);
        public static readonly SoundID C5MediumBell = new SoundID("C5MediumBell", register: true);
        public static readonly SoundID C6MediumBell = new SoundID("C6MediumBell", register: true);
        public static readonly SoundID C7MediumBell = new SoundID("C7MediumBell", register: true);
        public static readonly SoundID C1ShortBell = new SoundID("C1ShortBell", register: true);
        public static readonly SoundID C2ShortBell = new SoundID("C2ShortBell", register: true);
        public static readonly SoundID C3ShortBell = new SoundID("C3ShortBell", register: true);
        public static readonly SoundID C4ShortBell = new SoundID("C4ShortBell", register: true);
        public static readonly SoundID C5ShortBell = new SoundID("C5ShortBell", register: true);
        public static readonly SoundID C6ShortBell = new SoundID("C6ShortBell", register: true);
        public static readonly SoundID C7ShortBell = new SoundID("C7ShortBell", register: true);
        public static readonly SoundID C1LongClar = new SoundID("C1LongClar", register: true);
        public static readonly SoundID C2LongClar = new SoundID("C2LongClar", register: true);
        public static readonly SoundID C3LongClar = new SoundID("C3LongClar", register: true);
        public static readonly SoundID C4LongClar = new SoundID("C4LongClar", register: true);
        public static readonly SoundID C5LongClar = new SoundID("C5LongClar", register: true);
        public static readonly SoundID C6LongClar = new SoundID("C6LongClar", register: true);
        public static readonly SoundID C7LongClar = new SoundID("C7LongClar", register: true);
        public static readonly SoundID C1MediumClar = new SoundID("C1MediumClar", register: true);
        public static readonly SoundID C2MediumClar = new SoundID("C2MediumClar", register: true);
        public static readonly SoundID C3MediumClar = new SoundID("C3MediumClar", register: true);
        public static readonly SoundID C4MediumClar = new SoundID("C4MediumClar", register: true);
        public static readonly SoundID C5MediumClar = new SoundID("C5MediumClar", register: true);
        public static readonly SoundID C6MediumClar = new SoundID("C6MediumClar", register: true);
        public static readonly SoundID C7MediumClar = new SoundID("C7MediumClar", register: true);
        public static readonly SoundID C1ShortClar = new SoundID("C1ShortClar", register: true);
        public static readonly SoundID C2ShortClar = new SoundID("C2ShortClar", register: true);
        public static readonly SoundID C3ShortClar = new SoundID("C3ShortClar", register: true);
        public static readonly SoundID C4ShortClar = new SoundID("C4ShortClar", register: true);
        public static readonly SoundID C5ShortClar = new SoundID("C5ShortClar", register: true);
        public static readonly SoundID C6ShortClar = new SoundID("C6ShortClar", register: true);
        public static readonly SoundID C7ShortClar = new SoundID("C7ShortClar", register: true);
        public static readonly SoundID C1LongTrisaw = new SoundID("C1LongTrisaw", register: true);
        public static readonly SoundID C2LongTrisaw = new SoundID("C2LongTrisaw", register: true);
        public static readonly SoundID C3LongTrisaw = new SoundID("C3LongTrisaw", register: true);
        public static readonly SoundID C4LongTrisaw = new SoundID("C4LongTrisaw", register: true);
        public static readonly SoundID C5LongTrisaw = new SoundID("C5LongTrisaw", register: true);
        public static readonly SoundID C6LongTrisaw = new SoundID("C6LongTrisaw", register: true);
        public static readonly SoundID C7LongTrisaw = new SoundID("C7LongTrisaw", register: true);
        public static readonly SoundID C1MediumTrisaw = new SoundID("C1MediumTrisaw", register: true);
        public static readonly SoundID C2MediumTrisaw = new SoundID("C2MediumTrisaw", register: true);
        public static readonly SoundID C3MediumTrisaw = new SoundID("C3MediumTrisaw", register: true);
        public static readonly SoundID C4MediumTrisaw = new SoundID("C4MediumTrisaw", register: true);
        public static readonly SoundID C5MediumTrisaw = new SoundID("C5MediumTrisaw", register: true);
        public static readonly SoundID C6MediumTrisaw = new SoundID("C6MediumTrisaw", register: true);
        public static readonly SoundID C7MediumTrisaw = new SoundID("C7MediumTrisaw", register: true);
        public static readonly SoundID C1ShortTrisaw = new SoundID("C1ShortTrisaw", register: true);
        public static readonly SoundID C2ShortTrisaw = new SoundID("C2ShortTrisaw", register: true);
        public static readonly SoundID C3ShortTrisaw = new SoundID("C3ShortTrisaw", register: true);
        public static readonly SoundID C4ShortTrisaw = new SoundID("C4ShortTrisaw", register: true);
        public static readonly SoundID C5ShortTrisaw = new SoundID("C5ShortTrisaw", register: true);
        public static readonly SoundID C6ShortTrisaw = new SoundID("C6ShortTrisaw", register: true);
        public static readonly SoundID C7ShortTrisaw = new SoundID("C7ShortTrisaw", register: true);

        private static string LogTime() { return ((int)(Time.time * 1000)).ToString(); }
        public static void Debug(object data, [CallerMemberName] string callerName = "")
        {
            UnityEngine.Debug.Log($"{LogTime()}|{callerName}:{data}");
        }

        private void IntroRollMusic_ctor(On.Music.IntroRollMusic.orig_ctor orig, Music.IntroRollMusic self, Music.MusicPlayer musicPlayer)
        {
            orig(self, musicPlayer);
            var TheTracktm = self.subTracks[1];
            self.subTracks.Remove(TheTracktm);
            self.subTracks.Add(new Music.MusicPiece.SubTrack(self, 1, "RW_18 - The Captain"));


            // self.meter.hud.PlaySound(SoundID.HUD_Food_Meter_Fill_Plop_A);

            if (self.musicPlayer.manager.menuMic != null)
            {
                self.musicPlayer.manager.menuMic.PlaySound(PlopMachine.HelloC);
            }
        }
    }
}