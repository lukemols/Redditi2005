using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redditi2005.DB
{
    internal class DatabaseHandler
    {
        private string dbName = "redditi2005.db";
        private SQLiteConnection db;

        public DatabaseHandler(string folderName = "") 
        {
            string processDir = Path.GetDirectoryName(Environment.ProcessPath);
            string path = Path.Combine(processDir, folderName);
            
            Directory.CreateDirectory(path);
            path = Path.Combine(path, dbName);
            // remove existing db
            File.Delete(path);
            db = new SQLiteConnection(path);
            db.CreateTable<Record>();
        }

        public void AddRecords(List<Record> records)
        {
            if (records.Count > 0)
            {
                db.InsertAll(records);
            }
        }

        ~DatabaseHandler()
        {
            db.Close();
        }
    }
}
