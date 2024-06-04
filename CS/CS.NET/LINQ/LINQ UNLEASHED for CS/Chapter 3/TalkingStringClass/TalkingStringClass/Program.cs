using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeechLib;


namespace TalkingStringClass
{
  class Program
  {
    static void Main(string[] args)
    {
      "Microsoft Surface is Cool!".Say();
      "Press Enter to Quit".Say();
      Console.ReadLine();
    }
  }

  public static class MakeItTalk
  {
    public static void Say(this string s)
    {
       SpVoice voice = new SpVoiceClass();
      // requiredattributes - no attributes are required
      // optionalattributes - non required
      ISpeechObjectTokens tokens = voice.GetVoices("", "");
      voice.Rate = 2;
      voice.Volume = 100;
      voice.Voice = tokens.Item(0);
      voice.Speak(s, SpeechVoiceSpeakFlags.SVSFDefault);
    }
  }

}

