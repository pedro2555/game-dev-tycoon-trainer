using System;
using System.IO;
using System.Diagnostics;

namespace GameDevTycoon
{
    public static class gdtDBHelper
    {

        public static string CurrentSlot = "slot_auto";
        /// <summary>
        /// Local database file default location.
        /// </summary>
        public static string Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Game Dev Tycoon\Local Storage\file__0.localstorage";
        /// <summary>
        /// Used to convert the experience values from database to corresponding in game values.
        /// For:
        ///     Design
        ///     Tecnology
        ///     Speed
        ///     Research
        /// </summary>
        /// <param name="factor"></param>
        /// <returns></returns>
        public static double FactorToInt(double factor)
        {
            return (factor / 2) * 1000;
        }
        /// <summary>
        /// Used to convert the experience values from given int values to corresponding database double values.
        /// For:
        ///     Design
        ///     Tecnology
        ///     Speed
        ///     Research
        /// </summary>
        /// <param name="factor"></param>
        /// <returns></returns>
        public static double FactorToDouble(double gameValue)
        {
            return (gameValue / 1000) * 2;
        }

        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetSaveSlot(string path)
        {
            return new string[0];
        }
        /// <summary>
        /// Creates a DB connection if none is existent
        /// </summary>
        private static void TryConnect()
        {
            if (Database.dbConnection == "" || Database.dbConnection == null)
                Database.SetDatabase(gdtDBHelper.Path);
        }
        /// <summary>
        /// String to byte[]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        /// <summary>
        /// Byte[] to string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        /// <summary>
        /// Checks if Game Dev Tycoon executable is listed in the running processes list
        /// </summary>
        /// <returns></returns>
        public static bool isGameRunning()
        {
            foreach (Process clsProcess in Process.GetProcesses())
                if (clsProcess.ProcessName == "GameDevTycoon")
                    return true;
            return false;
        }

        /// <summary>
        /// Returns the blob file for the currentSlot.
        /// </summary>
        /// <returns></returns>
        public static string getBlob()
        {
            TryConnect();
            string res = "";
            try
            {
                res = GetString((byte[])Database.ExecuteScalar(String.Format("SELECT value from ItemTable WHERE key=\"{0}\"", gdtDBHelper.CurrentSlot)));
            }
            catch (Exception)
            {
                return "";
            }
            return res;
        }
        /// <summary>
        /// Saves the blob file
        /// </summary>
        /// <param name="newBlob"></param>
        /// <returns></returns>
        public static int setBlob(string newBlob)
        {
            TryConnect();

            string hex = BitConverter.ToString(GetBytes(newBlob));
            hex = hex.Replace("-", "");
            //UPDATE "main"."ItemTable" SET "value" = ?1 WHERE  "rowid" = 1689
            // Create the SQL string.
            string sql = String.Format("UPDATE ItemTable SET value=X'{0}' WHERE (key=\"{1}\")", hex, gdtDBHelper.CurrentSlot);
            return Database.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// Backups file file__0.localstorage to file__0.localstorage.backup
        /// backup file is overwritten
        /// </summary>
        public static bool BackupDB()
        {
            if (isGameRunning())
                return false;
            try
            {
                if (File.Exists(gdtDBHelper.Path.Replace("file__0.localstorage", "file__0.localstorage.backup")))
                    File.Delete(gdtDBHelper.Path.Replace("file__0.localstorage", "file__0.localstorage.backup"));
                File.Copy(gdtDBHelper.Path, gdtDBHelper.Path.Replace("file__0.localstorage", "file__0.localstorage.backup"));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static void RestoreDB()
        {
            if (isGameRunning())
                return;
            if (!File.Exists(gdtDBHelper.Path.Replace("file__0.localstorage", "file__0.localstorage.backup")))
                return;
            File.Delete(gdtDBHelper.Path);
            File.Copy(gdtDBHelper.Path.Replace("file__0.localstorage", "file__0.localstorage.backup"), gdtDBHelper.Path);
        }
    }
}
