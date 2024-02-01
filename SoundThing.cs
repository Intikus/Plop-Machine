using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UnityEngine;
using System.Globalization;
using System.Collections;
using System.Security.Cryptography;
using System.Runtime.ExceptionServices;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace SoundThing
{
    [BepInPlugin("Intikus.soundthing", "SoundThing", "0.0.1")]
    public class SoundThing : BaseUnityPlugin
    {

        readonly float magicnumber = 1.0594630776202568303519954093385f;
        int CurrentKey = 0;
        int QueuedModulation = 0;
        int debugtimer = 0;

        string[,] notesinkey =
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



        int lel = 0;
        int lel2 = 0;
        bool yoyo = true;
        bool yoyo2 = true;
        bool yoyo3 = true;

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


        int chordstopwatch = 0;
        string chordqueuedentry = "yeah";

        bool inwaitmode = false;
        int riffstopwatch = 0;
        string UpcomingEntry = "Yooo";
        string[] theline;
        int riffindex;
        int rifflength;
        string riffcurrentvar;


        string sampleinfo = "hehe";
        string sampleleadups = "lel";
        string[] theinfo;
        int indexofsample;
        string noteofsample = "hi";
        int pitchofsample = 1;
        float speeedofsample = 1;
        int sampletransposition;
        int samplestopwatch;

        readonly bool firstchordevahhhhhhasbeenplayedd = false;

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


        public void OnEnable()
        {
            On.Music.IntroRollMusic.ctor += IntroRollMusic_ctor;

            //On.Player.Update += Player_Update;

            On.RainWorldGame.Update += RainWorldGame_Update;
        }

        
        private string IntTOCKNote(int integer)
        {
            int treatedkey = CurrentKey + 6;

            string Note = notesinkey[treatedkey, integer - 1];

            return Note;
        }

        private SoundID[] SampDict(string key)
        {
            SoundID[] library = new SoundID[7]; //to do:  make better
            //switch the samples over to be categorised by short-medium-or-long, and region
            switch (key)
            {
                case "T":
                    library = [TriangleC1, TriangleC2, TriangleC3, TriangleC4, TriangleC5, TriangleC6, TriangleC7];
                    break;

                case "L":
                    library = [LongswavC1, LongswavC2, LongswavC3, LongswavC4, LongswavC5, LongswavC6, LongswavC7];
                    break;

                default:
                    library = [TriangleC1, TriangleC2, TriangleC3, TriangleC4, TriangleC5, TriangleC6, TriangleC7];
                    break;
            }
            return library;
        }
        private int Peeps(int low, int high)
        {
            
            int tlow = Peep(low);
            int thigh = Peep(high);

            if (tlow == thigh) { thigh++; }

            int lol = RXRandom.Range(tlow, thigh);

            return lol;
        }


        private int Peep(int value)
        {
            //take 10 as an example, agora being.... 2-3 people? 
            // i can follow a 2.5 people rule
            //agora then has to be changed (from being just an int to
            //be the result of a method)

            if (agora <= 1) { phob = 1; }
            //if (agora > 1) { phob = (float)((Mathf.Log((float)(agora * 0.7)) / 3.8) + 1); }
            if (agora > 1) { phob = (float)((Mathf.Log((float)(agora * 0.8)) / 4.5) + 1); }

            //Debug.Log(phob);
            float fvalue = value;
            //Debug.Log(fvalue);

            float avalue = fvalue / phob;
            //Debug.Log(avalue);




            string st1 = avalue.ToString();
            Debug.Log(st1);

            //Debug.Log(st1);
            int PointPos = st1.IndexOf('.');

            Debug.Log(PointPos);
            if (PointPos == -1) { st1 += ".00000"; }
            else
            {
                //Debug.Log("A");
                string lettersafterpoint = st1.Substring(PointPos);
                //Debug.Log("B");
                int lettersamount = lettersafterpoint.Length - 1;

                //Debug.Log("C");
                //Debug.Log(lettersamount);


                if (lettersamount < 5)
                {
                    if (lettersamount == 4) { st1 += "0"; }
                    else if (lettersamount == 3) { st1 += "00"; }
                    else if (lettersamount == 2) { st1 += "000"; }
                    else if (lettersamount == 1) { st1 += "0000"; }
                    else if (lettersamount == 0) { Debug.Log("what"); st1 += "00000"; }
                }
                Debug.Log("D");
                Debug.Log(st1);
            }

            string[] parts = st1.Split('.');
            //if (parts.Length == 1)
            //{
            //
            //}

            int former = int.Parse(parts[0]);
            string latter = parts[1].Substring(0, 5);
            int latterint = int.Parse(latter);

            int dicedint = RXRandom.Range(0, 100000);
            //1.99999 latter
            //  44246 diced
            if (latterint > dicedint) { former++; }
            return former;

        }

        private void IntiN(string input, VirtualMicrophone mic)
        {
            string s = input.ToString();
            

            string[] parts = s.Split('-');


            string slib = parts[0];
            int oct = int.Parse(parts[1]);
            int ind = int.Parse(parts[2]);

            //Debug.Log($"So the string is {s}, which counts as {parts.Length} amounts of parts. {slib}, {oct}, {ind}");

            SoundID[] slopb = SampDict(slib);

            SoundID sampleused = slopb[oct - 1];

            string NoteNow = IntTOCKNote(ind);
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


            float speeed = 1;

            speeed *= Mathf.Pow(magicnumber, transposition);

            // get intensity and turn that into too 
            // (which will also be reverb effect here then)

            if (RainWorld.ShowLogs)
            {
                //Debug.Log($"the note that played: {NoteNow}, {transposition} at {CurrentKey}");
            }

            PlayThing(sampleused, mic, speeed);

        }

        private void PlayThing(SoundID Note, VirtualMicrophone virtualMicrophone, float speed)
        {
            virtualMicrophone.PlaySound(Note, 0f, 0.42f, speed);

            if (RainWorld.ShowLogs)
            {
                //    Debug.Log($"the note that played: {Note} at {speed}");
            }
        }

        private void PushModulation()
        {
            CurrentKey += QueuedModulation;
            QueuedModulation = 0;
            if (CurrentKey == -7) { CurrentKey = 5; }
            if (CurrentKey == -8) { CurrentKey = 4; }
            if (CurrentKey == -9) { CurrentKey = 3; }
            if (CurrentKey == 7) { CurrentKey = -5; }
            if (CurrentKey == 8) { CurrentKey = -4; }
            if (CurrentKey == 9) { CurrentKey = -3; }
        }

        //bear with me as i struggle to figure out how to 
        //catalogue the information of a chord entry
        string[,] ChordInfos =
        {
            { "Triad", "Chord", "L-4-1 L-4-3 L-4-5,L-3-1 L-3-3 L-2-5 L-2-6 L-2-4", "Triad,40,50,T-4-6 T-4-5,0|Triad,40,50,T-4-3,0|Balaboo,40,50,T-4-3 T-3-4,0|Finga,60,90,T-4-5,0"},
            { "Balaboo", "Chord", "L-4-2 L-4-3 L-4-6,L-3-2 L-2-6 L-2-5", "Triad,40,60,0,0|Routsi,40,60,T-4-5,0"},
            { "Finga", "Chord", "L-4-3 L-4-5 L-4-7,L-3-4 L-3-5 L-3-6 L-2-1", "Triad,40,50,0,0|Balaboo,100,120,T-5-3 T-4-7 T-4-5,+1"},
            { "Routsi", "Chord", "L-4-3 L-4-5 L-4-6,L-2-5 L-2-6 L-3-1 L-3-3", "Balaboo,30,60,T-4-5 T-5-1,0|Balaboo,30,60,T-5-1,+2"},
            { "Grast", "Chord", "L-4-4 L-4-5 L-5-1,L-3-2 L-3-4 L-3-5", "Finga,45,70,T-5-3 T-4-5,0|Grast,30,60,T-5-1,-2|Rhast,20,30,T-4-6,0"},
            { "Rhast", "Chord", "L-4-1 L-4-4 L-4-6,L-3-4 L-3-2 L-3-1 L-2-6 L-2-4", "Balaboo,40,59,T-4-5,0|Rhast,40,50,T-4-7,+1|Triad,50,60,T-5-1,0" },
            { "Yooo", "Riff", "T-4-1,T-4-2,T-4-5 T-4-7,25,T-4-5 T-4-7,T-4-5 T-4-7,1,T-5-3 T-4-4,T-5-7 T-5-3,21,!,30,T-4-3,T-4-7,T-5-3", "Triad" }
            //{ "Firstsample", "Entry", "Lol,2,200", "Triad" }
        };

        private void PlayEntry(VirtualMicrophone mic)
        {
            
            // string[] CurrentChordLol = new string[3];

            //string sowhatwasthechorddude = "yo";                obsolete
            // Debug.Log("yo sup dude");

            // this part will check if it's a chord or entry, and seperate it to be one of the two

            if (EntryRequest == true)
                for (int i = 0; i < ChordInfos.GetLength(0); i++)
                {
                    //Debug.Log($"Nuclear {UpcomingEntry} vs Coughing {ChordInfos[i, 0]}... Round {i}, begin!");

                    Debug.Log("ummm");
                    if (UpcomingEntry == ChordInfos[i, 0])
                    {
                        Debug.Log($"so it tested with {UpcomingEntry}");
                        Debug.Log($"{ChordInfos[i, 0]},{ChordInfos[i, 1]},{ChordInfos[i, 2]},{ChordInfos[i, 3]}");

                        switch (ChordInfos[i, 1])
                        {
                            case "Chord":
                                //sowhatwasthechorddude = UpcomingEntry;
                                chordnotes = ChordInfos[i, 2];
                                chordleadups = ChordInfos[i, 3];
                                entrychord = true;
                                break;
                            case "Riff":
                                riffline = ChordInfos[i, 2];
                                riffleadups = ChordInfos[i, 3];
                                //Debug.Log(ChordInfos[i, 3] +" " + riffleadups);
                                entryriff = true;
                                break;
                            case "Sample":
                                sampleinfo = ChordInfos[i, 2];
                                sampleleadups = ChordInfos[i, 3];
                                entrysample = true;
                                break;
                        }
                    }
                }

            if (EntryRequest == true && entrychord == true)
            {
                //playing a chord
                PushModulation();
                EntryRequest = false;
                entrychord = false;
                string[] inst = chordnotes.Split(',');

                string chord = inst[0];
                string bass = inst[1];

                string[] notes = chord.Split(' ');
            
                for (int i = 0; i < notes.Length; i++ )
                {
                    IntiN(notes[i], mic);
                    //Debug.Log($"It is playing the Notes?{chord},{notes.Length},{i}, {notes[i]}... {debugtimer}");    
                }
                //Debug.Log($"done playing them???{EntryRequest}");                                  !!!!!!!!!!
                string[] bassnotes = bass.Split(' ');
                int sowhichoneisitboss = RXRandom.Range(0, bassnotes.Length);
           
                IntiN(bassnotes[sowhichoneisitboss], mic); //THIS is where it fucked up, which was because it had a space before the comma
                Debug.Log("And i played a Bass note");


                //all notes have been played, moving onto liason

                string[] leadups = chordleadups.Split('|');
                int butwhatnowboss = RXRandom.Range(0, leadups.Length);
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
                    
                    switch (thebabes.Length)
                    {
                        case 1:
                            Lslot1 = true;
                            Ltime1 = Peeps(6, 39);
                            Lnote1 = thebabes[0];
                            Lslot2 = false;
                            Lslot3 = false;
                            break;
                        case 2:
                            Lslot1 = true;
                            Ltime1 = Peeps(6, 36);
                            Lnote1 = thebabes[0];
                            Lslot2 = true;
                            Ltime2 = Peeps(9, 39);
                            Lnote2 = thebabes[1];
                            Lslot3 = false;
                            break;
                        case 3:
                            Lslot1 = true;
                            Ltime1 = Peeps(3, 49);
                            Lnote1 = thebabes[0];
                            Lslot2 = true;
                            Ltime2 = Peeps(9, 59);
                            Lnote2 = thebabes[1];
                            Lslot3 = true;
                            Ltime3 = Peeps(12, 55);
                            Lnote3 = thebabes[2];
                            break;
                    }
                }
                playingchord = true;
                Debug.Log($"Info given of: Timer: {low} {high}, {chordstopwatch}, And times: {Ltime1}, {Ltime2}, {Ltime3}, and Key {CurrentKey} of chord (put another name here)... {debugtimer}");

            }

            if (playingchord == true)
            {
                if (chordstopwatch == 0)
                {
                    EntryRequest = true;
                    UpcomingEntry = chordqueuedentry;
                    //Debug.Log($"{UpcomingEntry} will play");       
                    playingchord = false;
                }
                else
                {
                    if (Lslot1 == true)
                    {
                        if (Ltime1 == 0)
                        {
                            IntiN(Lnote1, mic);
                            Ltime1 = Peeps(30, 150);
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
                            IntiN(Lnote2, mic);
                            Ltime2 = Peeps(30, 150);
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
                            IntiN(Lnote3, mic);
                            Ltime3 = Peeps(30, 150);
                        }
                        else
                        {
                            Ltime3--;
                        }
                    }
                    chordstopwatch--;
                }
            }



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

            if (playingriff == true)
            {
                if (inwaitmode == true)
                {
                    riffstopwatch--;
                    if (riffstopwatch == 0)
                    {
                        inwaitmode = false;
                    }
                }
                else
                {
                    if (riffindex < rifflength)
                    {
                        riffcurrentvar = theline[riffindex];
                        string[] splitvar = riffcurrentvar.Split(' ');
                        //Debug.Log("hullo");
                        //randomise it, if it's an array, then also remove extras if else

                        //Debug.Log($"{riffindex}, {rifflength}, {riffcurrentvar}, {theline}");
                        //Debug.Log(splitvar[0]);
                        //Debug.Log(splitvar.Length);
                        int whichofthese = RXRandom.Range(0, splitvar.Length);
                        string treatedvar = splitvar[whichofthese];


                        Debug.Log("hello");
                        //testing if it's just a number
                        bool umitsanumber = true;
                        try
                        {
                            int intivaryo = int.Parse(treatedvar);
                        }
                        catch
                        {
                            //ok i guess it's not a number :steamsad:
                            umitsanumber = false;
                        }

                        if (umitsanumber == true)
                        {
                            int intivaryo = int.Parse(treatedvar);
                            riffstopwatch = intivaryo;
                            inwaitmode = true;
                        }
                        else
                        {
                            switch (treatedvar)
                            {
                                case "!":
                                    EntryRequest = true;
                                    //Debug.Log(riffleadups);
                                    string[] leadups = riffleadups.Split('|');
                                    int butwhatnowboss = RXRandom.Range(0, leadups.Length);
                                    string leadup = leadups[butwhatnowboss];
                                    UpcomingEntry = leadup;
                                    //Debug.Log(riffleadups + " " + leadups + " "+ butwhatnowboss + " " + leadup + " " + UpcomingEntry);
                                    break;
                                default: //will assume its a note for now
                                    treatedvar = treatedvar.ToString();
                                    IntiN(treatedvar, mic);
                                    break;
                            }
                        }
                        //Debug.Log("HEY THIS ONE DOES THE THING IT*S COOL");
                        riffindex++;
                    }
                    else
                    {
                        playingriff = false;
                        //Debug.Log("it is OVER");
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

                noteofsample = IntTOCKNote(indexofsample);
                switch (noteofsample)
                {
                    case "C":
                        sampletransposition = 0;
                        break;

                    case "C#" or "Db":
                        sampletransposition = 1;
                        break;

                    case "D":
                        sampletransposition = 2;
                        break;

                    case "D#" or "Eb":
                        sampletransposition = 3;
                        break;

                    case "E":
                        sampletransposition = 4;
                        break;

                    case "F":
                        sampletransposition = 5;
                        break;

                    case "F#" or "Gb":
                        sampletransposition = 6;
                        break;

                    case "G":
                        sampletransposition = 7;
                        break;

                    case "G#" or "Ab":
                        sampletransposition = 8;
                        break;

                    case "A":
                        sampletransposition = 9;
                        break;

                    case "A#" or "Bb":
                        sampletransposition = 10;
                        break;

                    case "B":
                        sampletransposition = 11;
                        break;
                }
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
                    //Debug.Log(riffleadups);
                    string[] leadups = sampleleadups.Split('|');
                    int butwhatnowboss = RXRandom.Range(0, leadups.Length);
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
            switch(soundid)
            {
                case "HelloA":
                    return HelloA; 
                default://add as many as you want here lol just remember to have them match
                    return HelloB;
            }
        }



        //private void Player_Update(On.Player.orig_Update orig, Player self, bool eu)
        private void RainWorldGame_Update(On.RainWorldGame.orig_Update orig, RainWorldGame self)
        {
            orig(self);
            var mic = self.cameras[0].virtualMicrophone;

            debugtimer++;

            PlayEntry(mic);

            // if (RainWorld.ShowLogs)
            // {
            //     lel = Peep(100);
            //     lel2 = Peeps(2000, 3000);
            //     Debug.Log($"{lel}, {lel2}");
            //     Debug.Log(agora);
            // }
            // 
            // 
            // if (Input.GetKey("1") && !yoyo)
            // {
            //     agora -= 1;
            // 
            // }
            // yoyo = Input.GetKey("1");
            // 
            // if (Input.GetKey("2") && !yoyo2)
            // {
            //     agora += 1;
            // }
            // yoyo2 = Input.GetKey("2"); 
            // 
            // if (Input.GetKey("3") && !yoyo3)
            // {
            //     agora = 0;
            // }
            // yoyo3 = Input.GetKey("3");

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


        public static readonly SoundID C1_LongBell = new SoundID("C1_LongBell.wav", register: true);
        public static readonly SoundID C1_LongClar = new SoundID("C1_LongClar.wav", register: true);
        public static readonly SoundID C1_LongLitri = new SoundID("C1_LongLitri.wav", register: true);
        public static readonly SoundID C1_LongSine = new SoundID("C1_LongSine.wav", register: true);
        public static readonly SoundID C1_LongTrisaw = new SoundID("C1_LongTrisaw.wav", register: true);
        public static readonly SoundID C1_MediumBell = new SoundID("C1_MediumBell.wav", register: true);
        public static readonly SoundID C1_MediumClar = new SoundID("C1_MediumClar.wav", register: true);
        public static readonly SoundID C1_MediumLitri = new SoundID("C1_MediumLitri.wav", register: true);
        public static readonly SoundID C1_MediumSine = new SoundID("C1_MediumSine.wav", register: true);
        public static readonly SoundID C1_MediumTrisaw = new SoundID("C1_MediumTrisaw.wav", register: true);
        public static readonly SoundID C1_ShortBell = new SoundID("C1_ShortBell.wav", register: true);
        public static readonly SoundID C1_ShortClar = new SoundID("C1_ShortClar.wav", register: true);
        public static readonly SoundID C1_ShortLitri = new SoundID("C1_ShortLitri.wav", register: true);
        public static readonly SoundID C1_ShortSine = new SoundID("C1_ShortSine.wav", register: true);
        public static readonly SoundID C1_ShortTrisaw = new SoundID("C1_ShortTrisaw.wav", register: true);
        public static readonly SoundID C2_LongBell = new SoundID("C2_LongBell.wav", register: true);
        public static readonly SoundID C2_LongClar = new SoundID("C2_LongClar.wav", register: true);
        public static readonly SoundID C2_LongLitri = new SoundID("C2_LongLitri.wav", register: true);
        public static readonly SoundID C2_LongSine = new SoundID("C2_LongSine.wav", register: true);
        public static readonly SoundID C2_LongTrisaw = new SoundID("C2_LongTrisaw.wav", register: true);
        public static readonly SoundID C2_MediumBell = new SoundID("C2_MediumBell.wav", register: true);
        public static readonly SoundID C2_MediumClar = new SoundID("C2_MediumClar.wav", register: true);
        public static readonly SoundID C2_MediumLitri = new SoundID("C2_MediumLitri.wav", register: true);
        public static readonly SoundID C2_MediumSine = new SoundID("C2_MediumSine.wav", register: true);
        public static readonly SoundID C2_MediumTrisaw = new SoundID("C2_MediumTrisaw.wav", register: true);
        public static readonly SoundID C2_ShortBell = new SoundID("C2_ShortBell.wav", register: true);
        public static readonly SoundID C2_ShortClar = new SoundID("C2_ShortClar.wav", register: true);
        public static readonly SoundID C2_ShortLitri = new SoundID("C2_ShortLitri.wav", register: true);
        public static readonly SoundID C2_ShortSine = new SoundID("C2_ShortSine.wav", register: true);
        public static readonly SoundID C2_ShortTrisaw = new SoundID("C2_ShortTrisaw.wav", register: true);
        public static readonly SoundID C3_LongBell = new SoundID("C3_LongBell.wav", register: true);
        public static readonly SoundID C3_LongClar = new SoundID("C3_LongClar.wav", register: true);
        public static readonly SoundID C3_LongLitri = new SoundID("C3_LongLitri.wav", register: true);
        public static readonly SoundID C3_LongSine = new SoundID("C3_LongSine.wav", register: true);
        public static readonly SoundID C3_LongTrisaw = new SoundID("C3_LongTrisaw.wav", register: true);
        public static readonly SoundID C3_MediumBell = new SoundID("C3_MediumBell.wav", register: true);
        public static readonly SoundID C3_MediumClar = new SoundID("C3_MediumClar.wav", register: true);
        public static readonly SoundID C3_MediumLitri = new SoundID("C3_MediumLitri.wav", register: true);
        public static readonly SoundID C3_MediumSine = new SoundID("C3_MediumSine.wav", register: true);
        public static readonly SoundID C3_MediumTrisaw = new SoundID("C3_MediumTrisaw.wav", register: true);
        public static readonly SoundID C3_ShortBell = new SoundID("C3_ShortBell.wav", register: true);
        public static readonly SoundID C3_ShortClar = new SoundID("C3_ShortClar.wav", register: true);
        public static readonly SoundID C3_ShortLitri = new SoundID("C3_ShortLitri.wav", register: true);
        public static readonly SoundID C3_ShortSine = new SoundID("C3_ShortSine.wav", register: true);
        public static readonly SoundID C3_ShortTrisaw = new SoundID("C3_ShortTrisaw.wav", register: true);
        public static readonly SoundID C4_LongBell = new SoundID("C4_LongBell.wav", register: true);
        public static readonly SoundID C4_LongClar = new SoundID("C4_LongClar.wav", register: true);
        public static readonly SoundID C4_LongLitri = new SoundID("C4_LongLitri.wav", register: true);
        public static readonly SoundID C4_LongSine = new SoundID("C4_LongSine.wav", register: true);
        public static readonly SoundID C4_LongTrisaw = new SoundID("C4_LongTrisaw.wav", register: true);
        public static readonly SoundID C4_MediumBell = new SoundID("C4_MediumBell.wav", register: true);
        public static readonly SoundID C4_MediumClar = new SoundID("C4_MediumClar.wav", register: true);
        public static readonly SoundID C4_MediumLitri = new SoundID("C4_MediumLitri.wav", register: true);
        public static readonly SoundID C4_MediumSine = new SoundID("C4_MediumSine.wav", register: true);
        public static readonly SoundID C4_MediumTrisaw = new SoundID("C4_MediumTrisaw.wav", register: true);
        public static readonly SoundID C4_ShortBell = new SoundID("C4_ShortBell.wav", register: true);
        public static readonly SoundID C4_ShortClar = new SoundID("C4_ShortClar.wav", register: true);
        public static readonly SoundID C4_ShortLitri = new SoundID("C4_ShortLitri.wav", register: true);
        public static readonly SoundID C4_ShortSine = new SoundID("C4_ShortSine.wav", register: true);
        public static readonly SoundID C4_ShortTrisaw = new SoundID("C4_ShortTrisaw.wav", register: true);
        public static readonly SoundID C5_LongBell = new SoundID("C5_LongBell.wav", register: true);
        public static readonly SoundID C5_LongClar = new SoundID("C5_LongClar.wav", register: true);
        public static readonly SoundID C5_LongLitri = new SoundID("C5_LongLitri.wav", register: true);
        public static readonly SoundID C5_LongSine = new SoundID("C5_LongSine.wav", register: true);
        public static readonly SoundID C5_LongTrisaw = new SoundID("C5_LongTrisaw.wav", register: true);
        public static readonly SoundID C5_MediumBell = new SoundID("C5_MediumBell.wav", register: true);
        public static readonly SoundID C5_MediumClar = new SoundID("C5_MediumClar.wav", register: true);
        public static readonly SoundID C5_MediumLitri = new SoundID("C5_MediumLitri.wav", register: true);
        public static readonly SoundID C5_MediumSine = new SoundID("C5_MediumSine.wav", register: true);
        public static readonly SoundID C5_MediumTrisaw = new SoundID("C5_MediumTrisaw.wav", register: true);
        public static readonly SoundID C5_ShortBell = new SoundID("C5_ShortBell.wav", register: true);
        public static readonly SoundID C5_ShortClar = new SoundID("C5_ShortClar.wav", register: true);
        public static readonly SoundID C5_ShortLitri = new SoundID("C5_ShortLitri.wav", register: true);
        public static readonly SoundID C5_ShortSine = new SoundID("C5_ShortSine.wav", register: true);
        public static readonly SoundID C5_ShortTrisaw = new SoundID("C5_ShortTrisaw.wav", register: true);
        public static readonly SoundID C6_LongBell = new SoundID("C6_LongBell.wav", register: true);
        public static readonly SoundID C6_LongClar = new SoundID("C6_LongClar.wav", register: true);
        public static readonly SoundID C6_LongLitri = new SoundID("C6_LongLitri.wav", register: true);
        public static readonly SoundID C6_LongSine = new SoundID("C6_LongSine.wav", register: true);
        public static readonly SoundID C6_LongTrisaw = new SoundID("C6_LongTrisaw.wav", register: true);
        public static readonly SoundID C6_MediumBell = new SoundID("C6_MediumBell.wav", register: true);
        public static readonly SoundID C6_MediumClar = new SoundID("C6_MediumClar.wav", register: true);
        public static readonly SoundID C6_MediumLitri = new SoundID("C6_MediumLitri.wav", register: true);
        public static readonly SoundID C6_MediumSine = new SoundID("C6_MediumSine.wav", register: true);
        public static readonly SoundID C6_MediumTrisaw = new SoundID("C6_MediumTrisaw.wav", register: true);
        public static readonly SoundID C6_ShortBell = new SoundID("C6_ShortBell.wav", register: true);
        public static readonly SoundID C6_ShortClar = new SoundID("C6_ShortClar.wav", register: true);
        public static readonly SoundID C6_ShortLitri = new SoundID("C6_ShortLitri.wav", register: true);
        public static readonly SoundID C6_ShortSine = new SoundID("C6_ShortSine.wav", register: true);
        public static readonly SoundID C6_ShortTrisaw = new SoundID("C6_ShortTrisaw.wav", register: true);
        public static readonly SoundID C7_LongBell = new SoundID("C7_LongBell.wav", register: true);
        public static readonly SoundID C7_LongClar = new SoundID("C7_LongClar.wav", register: true);
        public static readonly SoundID C7_LongLitri = new SoundID("C7_LongLitri.wav", register: true);
        public static readonly SoundID C7_LongSine = new SoundID("C7_LongSine.wav", register: true);
        public static readonly SoundID C7_LongTrisaw = new SoundID("C7_LongTrisaw.wav", register: true);
        public static readonly SoundID C7_MediumBell = new SoundID("C7_MediumBell.wav", register: true);
        public static readonly SoundID C7_MediumClar = new SoundID("C7_MediumClar.wav", register: true);
        public static readonly SoundID C7_MediumLitri = new SoundID("C7_MediumLitri.wav", register: true);
        public static readonly SoundID C7_MediumSine = new SoundID("C7_MediumSine.wav", register: true);
        public static readonly SoundID C7_MediumTrisaw = new SoundID("C7_MediumTrisaw.wav", register: true);
        public static readonly SoundID C7_ShortBell = new SoundID("C7_ShortBell.wav", register: true);
        public static readonly SoundID C7_ShortClar = new SoundID("C7_ShortClar.wav", register: true);
        public static readonly SoundID C7_ShortLitri = new SoundID("C7_ShortLitri.wav", register: true);
        public static readonly SoundID C7_ShortSine = new SoundID("C7_ShortSine.wav", register: true);
        public static readonly SoundID C7_ShortTrisaw = new SoundID("C7_ShortTrisaw.wav", register: true);




        private void IntroRollMusic_ctor(On.Music.IntroRollMusic.orig_ctor orig, Music.IntroRollMusic self, Music.MusicPlayer musicPlayer)
        {
            orig(self, musicPlayer);
            var TheTracktm = self.subTracks[1];
            self.subTracks.Remove(TheTracktm);
            self.subTracks.Add(new Music.MusicPiece.SubTrack(self, 1, "RW_18 - The Captain"));


            // self.meter.hud.PlaySound(SoundID.HUD_Food_Meter_Fill_Plop_A);

            if (self.musicPlayer.manager.menuMic != null)
            {
                self.musicPlayer.manager.menuMic.PlaySound(SoundThing.HelloC);
            }


        }



        /*
        int[] xarr = new int[2];

        Dictionary<int, string> DOW = new();

        DOW[5] = "Friday";
        Debug.Log(DOW[5]);

        if (DOW.TryGetValue(4, out var Result))
        {
            Debug.Log(Result);
        }
        */

    }
}
