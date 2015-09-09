using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class ContentFormatPluginFactory
    {
        public IContentFormat getContentFormat(string contentFormat, string currentConfigFile, string currentWorkingDirectory)
        {
            if ("JSON" == contentFormat.ToUpper())
            {
                return new JSONPlugin(contentFormat, "UTF-8", currentConfigFile, currentWorkingDirectory);
            }
            else if ("XML" == contentFormat.ToUpper())
            {
                return new XMLPlugin(contentFormat, "UTF-8", currentConfigFile, currentWorkingDirectory);
            }
            else
            {
                return new XLSXPlugin(contentFormat, "UTF-8", currentConfigFile, currentWorkingDirectory);
            }
        }
    }
}
