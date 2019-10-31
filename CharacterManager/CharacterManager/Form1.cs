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
using System.Xml;
using System.Xml.Serialization;

namespace CharacterManager
{
    public partial class Form1 : Form
    {
        private TextBoxWriter myWriter;
        private PlayerCharacter activeCharacter = null;
        private CharacterFactory myFactory;

        public Form1()
        {
            InitializeComponent();
            myWriter = new TextBoxWriter(this.richTextBox1);

            myWriter.WriteColoredLine("Hello World", ConsoleColor.DarkRed);
            //myFactory = new CharacterFactory();
            myFactory = new CharacterFactory(myWriter);
            myFactory.Initialize();
        }


        /************* private methods*****************/


        private void updateCharacterAttributes()
        {
            if (this.activeCharacter != null)
            {
                this.textBoxName.Text = activeCharacter.CharacterName;
                
                this.AttributeDisplaySTR.AttributeValue = activeCharacter.StrengthAttribute;
                this.AttributeDisplayINT.AttributeValue = activeCharacter.IntAttribute;
                this.AttributeDisplayDEX.AttributeValue = activeCharacter.DexAttribute;
                this.AttributeDisplayCON.AttributeValue = activeCharacter.ConAttribute;
                this.AttributeDisplayWIS.AttributeValue = activeCharacter.WisAttribute;
                this.AttributeDisplayCHA.AttributeValue = activeCharacter.CharAttribute;
            }
        }

        /*************** Button functions *************/
        private void button1_Click(object sender, EventArgs e)
        {
            /* New character creation - TODO, this is only a placeholder. */
            CharacterCreatorForm f2 = new CharacterCreatorForm(this.myFactory);
            
            if (f2.ShowDialog() == DialogResult.OK)
            {
                activeCharacter = f2.CreatedCharacter;
                updateCharacterAttributes();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /** Load a file. */
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                activeCharacter = myFactory.LoadFromXml(openFileDialog1.FileName);
                updateCharacterAttributes();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(activeCharacter != null)
            {
                /* Lets test saving the character into an xml format. */

                XmlSerializer xSubmit = new XmlSerializer(typeof(PlayerCharacter));

                using (var sww = new StreamWriter("test.xml"))
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.OmitXmlDeclaration = true;
                    settings.Indent = true;
                    settings.NewLineOnAttributes = true;

                    using(XmlWriter writer = XmlWriter.Create(sww, settings))
                    {
                        xSubmit.Serialize(writer, activeCharacter);
                        sww.Flush();
                    }
                }
            }
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }

    /// <summary>
    /// Helper class for directing console output to the rich textbox.
    /// </summary>
    public class TextBoxWriter
    {
        RichTextBox _output = null;

        public TextBoxWriter(RichTextBox output)
        {
            _output = output;
        }

        public void WriteColoredLine(string str, ConsoleColor color)
        {
            if (_output.InvokeRequired)
            {
                _output.Invoke(new Action<string, Color>(_output.AppendText), new object[] { str + Environment.NewLine, ConvertConsoleColorToColor(color) });
                return;
            }
            else
            {
                _output.AppendText(str, ConvertConsoleColorToColor(color));
            }
        }

        public void Write(char value)
        {
            if (_output.InvokeRequired)
            {
                _output.Invoke(new Action<char>(Write), new object[] { value });
                return;
            }
            _output.AppendText(value.ToString());
        }

        public void WriteLine(String msg)
        {
            if (_output.InvokeRequired)
            {
                _output.Invoke(new Action<String>(WriteLine), new object[] { msg });
                return;
            }

            _output.AppendText(msg + Environment.NewLine);
        }

        public Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }


        private static Color ConvertConsoleColorToColor(ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Black:
                    return Color.Black;
                case ConsoleColor.Blue:

                    return Color.Blue;
                case ConsoleColor.Cyan:

                    return Color.Cyan;
                case ConsoleColor.DarkBlue:

                    return Color.DarkBlue;
                case ConsoleColor.DarkGray:

                    return Color.DarkGray;
                case ConsoleColor.DarkGreen:

                    return Color.DarkGreen;
                case ConsoleColor.DarkMagenta:

                    return Color.DarkMagenta;
                case ConsoleColor.DarkRed:

                    return Color.DarkRed;
                case ConsoleColor.DarkYellow:

                    return Color.FromArgb(255, 128, 128, 0);
                case ConsoleColor.Gray:

                    return Color.Gray;
                case ConsoleColor.Green:

                    return Color.Green;
                case ConsoleColor.Magenta:

                    return Color.Magenta;
                case ConsoleColor.Red:

                    return Color.Red;
                case ConsoleColor.White:

                    return Color.White;
                default:
                    return Color.Yellow;
            }
        }
    }
}
