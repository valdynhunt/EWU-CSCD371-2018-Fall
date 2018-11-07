using System;
using System.IO;

namespace ResourceManager
{
    public class ResourceManager : IDisposable
    {
        public StreamReader FileChecker { get; }
        public int Count { get; set; } = 0;

        public ResourceManager(string fileName)
        {
            FileChecker = new StreamReader(fileName);
            Count++;
        }

        public int GetInstanceCount()
        {
            return Count;
        }

        public void Dispose()
        {
            // if the programmer remembers to call Dispose, this code will fire
            FileChecker?.Dispose();
            Count--;
        }

        ~ResourceManager()
        {
            // if the programmer does not remember to call Dispose, this finalizer will fire, 
            // and so the Dispose method and decrementer will fire event if they forget
            // or don't realize that IDisposable is supported.

            Dispose();
        }

        public static void Main(string[] args)
        {

        }

    }
}
