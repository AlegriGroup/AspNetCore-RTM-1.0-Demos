using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore_Mvc_ViewComponents_CoreFx.Services
{
    public class DemoService : IDemoService
    {
        private const string DefaultChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly Random Random = new Random(Guid.NewGuid().GetHashCode());

        public Task<string> GetRandomStringAsync(int length)
        {
            return Task.Run(() => GetRandomString(length));
        }

        public string GetRandomString(int length)
        {
            IEnumerable<char> randomChars = Enumerable.Repeat(DefaultChars, length)
                .Select(s => s[Random.Next(s.Length)]);

            return String.Concat(randomChars);
        }
    }
}
