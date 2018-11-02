using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TextToSpeech
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private object readText;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnTextToSpeech_Click(object sender, RoutedEventArgs e)
        {
            readText.(txtContent.Text);
        }
        

        private async void readText(string text)
        {
            var voice = SpeechSynthesizer.AllVoices;

           using (var speech = new SpeechSynthesizer())
           {
                speech.Voice = voice.First(gender => gender.Gender == VoiceGender.Female);
               await speech.SynthesizeTextToStreamAsync(text);
            }
        }
    }
}
