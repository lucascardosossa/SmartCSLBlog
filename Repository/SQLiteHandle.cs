using SmartCSLBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SmartCSLBlog.Repository
{
    internal class SQLiteHandle
    {
        /// <summary>
        /// The http client.
        /// </summary>
        private HttpClient _client;

        /// <summary>
        /// The size of the buffer.
        /// </summary>
        private int bufferSize = 4095;

        public SQLiteHandle(int filial)
        {

        }

        public SQLiteHandle()
        {
            _client = new HttpClient();
            _databasePath = Session.SqlitePath;
        }

        //private Action<string> _messageUpdateAction;
        public readonly string _databasePath;
        //private IHttpTask DownloadSqliteTask { get; set; }
        public bool DoesLocalDbExists => File.Exists(_databasePath);
    }
}
