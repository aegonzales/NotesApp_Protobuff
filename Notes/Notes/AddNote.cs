using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Notebook;
using Google.Protobuf;

namespace Notes
{
    class AddNote
    {
        private static Note SendNote(TextReader input, TextWriter output)
        {
            Note message = new Note();

            output.Write("Enter Title: ");
            message.Title = input.ReadLine();

            output.Write("Enter Message: ");
            string txt = input.ReadLine();
            message.Message = txt;

            return message;
        }

        public static void Main(string fileLog)
        {
            Archieve logNotes;

            if (File.Exists(fileLog))
            {
                using (Stream file = File.OpenRead(fileLog))
                {
                    logNotes = Archieve.Parser.ParseFrom(file);
                }
            }
            else
            {
                Console.WriteLine("{0}: File not found. Creating a new file.", fileLog);
                logNotes = new Archieve();
            }

            //Add Message.
            logNotes.Notes.Add(SendNote(Console.In, Console.Out));

            // Write the new address book back to disk.
            using (Stream output = File.OpenWrite(fileLog))
            {
                logNotes.WriteTo(output);
            }

        }
    }
}
