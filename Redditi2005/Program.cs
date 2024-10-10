using Redditi2005.DB;

namespace Redditi2005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto in Redditi 2005. Incolla la cartella sorgente da cui estrarre i dati.");
            string source = Console.ReadLine();

            if (Directory.Exists(source))
            {
                DateTime startTime = DateTime.Now;

                DatabaseHandler dbHandler = new DatabaseHandler("output");
                DirectoryInfo dir = new DirectoryInfo(source);
                List<FileInfo> files = dir.EnumerateFiles("*.txt").ToList();

                Console.WriteLine($"\nTrovati {files.Count} file di testo, che verranno usati come sorgente.\n");
                for (int i = 0; i < files.Count; ++i)
                {
                    FileInfo file = files[i];
                    Console.WriteLine($"[{i + 1}/{files.Count}]. Elaborando {file.Name}.");
                    Scraper.Scraper.ScrapeFile(file, out List<DB.Record> records);

                    Console.WriteLine($"Trovati {records.Count} records. Inserimento in database in corso.");
                    dbHandler.AddRecords(records);

                    Console.WriteLine($"Inserimento completato. Tempo totale corrente: {DateTime.Now - startTime}.\n");
                }

                Console.WriteLine($"Estrazione completata in {DateTime.Now - startTime}. Grazie per aver usato Redditi 2005!");
            }
        }
    }
}
