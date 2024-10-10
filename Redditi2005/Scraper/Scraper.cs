using Redditi2005.DB;
using Redditi2005.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redditi2005.Scraper
{
    internal class Scraper
    {
        static int idCount = 0;

        public static void ScrapeFile(FileInfo fileInfo, out List<Record> records)
        {
            records = new List<Record>();

            using (StreamReader reader = new StreamReader(fileInfo.FullName))
            {
                string cityName = "";
                do
                {
                    string line = reader.ReadLine();

                    if (line != null)
                    {
                        try
                        {
                            line = line.Trim();
                            string[] splitted = line.Split("  ", StringSplitOptions.RemoveEmptyEntries);
                            // minumum entries count for a record
                            if (splitted.Length < 7)
                            {
                                if (line.StartsWith("COMUNE DI "))
                                {
                                    cityName = line.Replace("COMUNE DI ", "");
                                }
                            }
                            else
                            {
                                if (line.StartsWith("COGNOME E NOME"))
                                {
                                    continue;
                                }
                                /* Sample data: 
                                 * [0]             [1]             [2]        [3]            [4]         [5]            [6]         [7]   [8]
                                 * SURNAME NAME    1929-07-16      RC         52210        9.476       2.153             0           0    UNICOPF
                                 * 
                                 * [0]             [1]             [2]                       [3]         [4]            [5]         [6]   [7]
                                 * SURNAME NAME    1981-11-29      RH                     91.056      30.902             0           0    UNICOPF
                                 * 
                                 * [0]             [1]                                       [2]         [3]            [4]         [5]   [6]
                                 * SURNAME NAME    1943-05-05                                  0           0             0           0    CUD
                                 */
                                Record record = new Record();
                                //record.Id = ++idCount;
                                record.CityCode = cityName;
                                record.Name = splitted[0].Trim(); // always first two datas
                                record.Birthday = splitted[1].Trim();
                                // filter gibberish
                                if (!record.Name.IsNameSurname() || !record.Birthday.IsBirthday())
                                {
                                    continue;
                                }
                                int index = 2;

                                if (splitted[index].IsRedditCategory())
                                {
                                    record.RedditCategory = splitted[index].Trim();
                                    index++;
                                }

                                if (splitted[index].IsCompanyCategory())
                                {
                                    record.CompanyCategory = splitted[index].Trim();
                                    index++;
                                }

                                record.Gross = splitted[index].ParseReddit();
                                index++;

                                record.NetTax = splitted[index].ParseReddit();
                                index++;

                                record.CompanyReddit = splitted[index].ParseReddit();
                                index++;

                                record.Turnover = splitted[index].ParseReddit();
                                index++;

                                record.ModelType = splitted[index].Trim();

                                records.Add(record);
                            }
                        }
                        catch
                        {
                            Console.WriteLine($"Errore nell'aggiungere la seguente riga:\n{line}");
                        }
                    }
                }
                while (!reader.EndOfStream);
            }
        }
    }
}
