using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace EmpleoDotNet
{
    public class LessTransform : IBundleTransform
    {
        private string path;

        public LessTransform(string path)
        {
            this.path = path;
        }

        public void Process(BundleContext context, BundleResponse response)
        {
            Directory.SetCurrentDirectory(path);

            response.Content = dotless.Core.Less.Parse(response.Content);
            response.ContentType = "text/css";
        }
    }
}
