using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class Result : IResult
    {
        // mesaj yazdirilmasi isteniyorsa calisir
        // this deme sebebi ovveride edilen constructori calistirmak
        public Result(bool success, string message):this(success)
        {
            Messages = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public string Messages { get; }
    }
}
