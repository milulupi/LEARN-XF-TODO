﻿using Android.Speech.Tts;
using Xamarin.Forms;
using LEARNXFTODO;
using Java.Lang;
using System;

[assembly:Dependency(typeof(TextToSpeech_Android))]
namespace LEARNXFTODO
{
    public class TextToSpeech_Android: object, ITextToSpeech, 
                TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;

        public TextToSpeech_Android()
        {
        }

        public IntPtr Handle => throw new NotImplementedException();

        public void Dispose()
        {
           // throw new NotImplementedException();
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);   
            }
        }

        public void Speak(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                toSpeak = text;
                if (speaker == null)
                    speaker = new TextToSpeech(MainActivity.Instance, this);
                else
                {
                    speaker.Speak(toSpeak, QueueMode.Flush, null, null);
                }
            }
        }
    }
}
