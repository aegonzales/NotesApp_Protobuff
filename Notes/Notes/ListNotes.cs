using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Notebook;

namespace Notes
{
    class ListNotes
    {
        private static void Print(Archieve notes)
        {
            int counter = 0;
            foreach (Note note in notes.Notes)
            {
                counter++;
                Console.WriteLine("Note Count: {0}", counter);
                Console.WriteLine("TITLE: {0}", note.Title);
                Console.WriteLine("  MESSAGE: {0}", note.Message);
            }
        }

        /// <summary>
        /// Entry point - loads the addressbook and then displays it.
        /// </summary>
        public static void Main(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine("{0} doesn't exist. Add a message to create the file first.", fileName);
                return;
            }

            // Read the existing address book.
            using (Stream stream = File.OpenRead(fileName))
            {
                Archieve notes = Archieve.Parser.ParseFrom(stream);
                Print(notes);
            }
        }
    }
}
