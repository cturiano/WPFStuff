using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using T = System.Threading.Thread;

namespace Thread
{
    internal class Program
    {
        #region Private Methods

        private static async Task<string> Download()
        {
            var hc = new HttpClient();
            return await hc.GetStringAsync(new Uri("http://angelsix.com"));
        }

        private static void Main(string[] args)
        {
            var tcs = new TaskCompletionSource<long>();
            var t1 = new T(async () =>
                           {
                               var sw = new Stopwatch();
                               sw.Start();
                               var html = await Download();
                               sw.Stop();

                               Console.WriteLine(html);
                               tcs.SetResult(sw.ElapsedMilliseconds);
                           });

            t1.Start();

            // block
            t1.Join();

            Console.WriteLine($"The download took {tcs.Task.Result} milliseconds");
            Console.ReadLine();
        }

        #endregion
    }
}