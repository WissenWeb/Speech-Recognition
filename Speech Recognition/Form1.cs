using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Speech_Recognition
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine algilamaMotoru = new SpeechRecognitionEngine();
        public Form1()
        {

            InitializeComponent();
            algilamaMotoru.SetInputToDefaultAudioDevice();
            Choices sesGrubu = new Choices("hello", "hi", "bye", "how are you");

            GrammarBuilder gramerYapilandirici = new GrammarBuilder(sesGrubu);
            gramerYapilandirici.Culture = System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag("en-US");
            Grammar gramer = new Grammar(gramerYapilandirici);

            algilamaMotoru.SpeechRecognized += ses_Duyuldu;
            algilamaMotoru.RecognizeAsync(RecognizeMode.Multiple);


            algilamaMotoru.LoadGrammar(gramer);
        }
        void ses_Duyuldu(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (RecognizedWordUnit kelime in e.Result.Words)
            {

                textBox1.Text += kelime.Text + " ";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SpeechRecognitionEngine algilamaMotoru = new SpeechRecognitionEngine();
            algilamaMotoru.SetInputToDefaultAudioDevice();
            Choices sesGrubu = new Choices("hello", "hi", "bye", "how are you");
            GrammarBuilder gramerYapilandirici = new GrammarBuilder(sesGrubu);
            gramerYapilandirici.Culture = System.Globalization.CultureInfo.GetCultureInfoByIetfLanguageTag("en-US");
            Grammar gramer = new Grammar(gramerYapilandirici);
            algilamaMotoru.LoadGrammar(gramer); algilamaMotoru.SpeechRecognized += ses_Duyuldu;
            algilamaMotoru.RecognizeAsync(RecognizeMode.Multiple);
        }
    }
}
