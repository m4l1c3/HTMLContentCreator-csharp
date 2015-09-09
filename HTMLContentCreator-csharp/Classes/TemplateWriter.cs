using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLContentCreator_csharp
{
    class TemplateWriter : ITemplateProcessor
    {
        private string templateSuffix = "Template";
        private string templateExtension = ".html";
        private string htmlTemplatePath;

        public TemplateWriter()
        {

        }
        public void writeTemplates(ContentFormatPlugin contentFormatplugin)
        {
            if(contentFormatplugin.cmsBlocks.Count() > 0)
            {
                foreach(CMSBlock currentCMSBlock in contentFormatplugin.cmsBlocks)
                {
                    this.htmlTemplatePath = Path.Combine(contentFormatplugin.currentWorkingDirectory
                        ) + @"\..\..\" + currentCMSBlock.Name + this.templateSuffix + this.templateExtension;

                    try
                    {
                        string currentTemplate = File.ReadAllText(this.htmlTemplatePath);
                        foreach(ContentPieces currentContentPiece in currentCMSBlock.Language.ContentPieces)
                        {
                            currentTemplate = currentTemplate.Replace("%%" + currentContentPiece.SectionName + "%%", 
                                currentContentPiece.SectionContent);
                        }
                        currentTemplate = currentTemplate.Replace("%%language-code%%", currentCMSBlock.Language.Name);
                        string destinationFile = Path.Combine(contentFormatplugin.currentWorkingDirectory) + @"\..\..\" + currentCMSBlock.Language.Name +
                            "-" + currentCMSBlock.Name + this.templateExtension;
                        File.WriteAllText(destinationFile, currentTemplate);

                    } catch(Exception exception)
                    {
                        Console.WriteLine("Error - " + exception.ToString());
                    }
                }
            }
        }
    }
}
