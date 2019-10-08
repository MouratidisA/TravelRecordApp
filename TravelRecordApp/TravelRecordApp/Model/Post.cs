using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using SQLite;

namespace TravelRecordApp.Model
{
    public class Post
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Experience { get; set; }
    }
}
