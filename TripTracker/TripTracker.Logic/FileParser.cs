using System;
using System.IO;
using System.Security;
using TripTracker.Logic.BusinessObjects;
using TripTracker.Logic.Interfaces;

namespace TripTracker.Logic
{
    public static class FileParser
    {
        public static IFileCommandResponse Parse(string path)
        {
            var response = new FileCommandResponse();
            try
            {
                response.Lines = Get(path);
                response.Success = true;
            }
            catch (Exception ex) when (ex is ArgumentException ||
                                       ex is SecurityException ||
                                       ex is PathTooLongException ||
                                       ex is NotSupportedException ||
                                       ex is FileNotFoundException ||
                                       ex is DirectoryNotFoundException ||
                                       ex is IOException ||
                                       ex is UnauthorizedAccessException)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        private static string[] Get(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
