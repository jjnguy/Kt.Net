using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kt.Net
{
    public class Examples
    {
        public void Apply()
        {
            var client = new HttpClient().Apply(it =>
            {
                it.DefaultRequestHeaders.Add("Example", "value");
            });
        }
    }
}
