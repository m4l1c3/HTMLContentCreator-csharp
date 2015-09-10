using System;
using System.Collections;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace HTMLContentCreator_csharp
{
    class XLSXPlugin : IContentFormat
    {
        private XSSFWorkbook workBook;
        private ISheet sheet;
        public string CurrentPageSection { get; set; }
        public IContentType contentFormat { get; set; }
        public string currentFile { get; set; }
        public FileStream fileInput { get; set; }
        public string currentPageName { get; set; }
        public string currentWorkingDirectory { get; set; }
        public ICMSDataParser cmsBlockFactory { get; set; }
        public XLSXPlugin(string contentFormat, string contentEncoding, string currentFile, string currentWorkingDirectory)
        {
        
            this.contentFormat = new ContentType(contentFormat, contentEncoding);
            this.currentFile = currentFile;
            fileInput = new FileStream(Path.Combine(currentWorkingDirectory, this.currentFile), FileMode.Open, FileAccess.Read);
            workBook = new XSSFWorkbook(this.fileInput);
            currentPageName = currentFile.Substring(this.currentFile.LastIndexOf("/") + 1, this.currentFile.LastIndexOf("."));
            this.currentWorkingDirectory = currentWorkingDirectory;
            sheet = workBook.GetSheet("Sheet1");
            cmsBlockFactory = new CMSBlockFactory(currentPageName);
            processDataRows();
        }
        
        public void processDataRows()
        {
            try
            {
                for (int row = 0; row <= sheet.LastRowNum; row++)
                {
                    IRow r = this.sheet.GetRow(row);
                    if (row == 0)
                    {
                        getLanguages(r.Cells);
                    }
                    else
                    {
                        processDataCells(r.Cells);
                    }
                }
                cmsBlockFactory.getCMSBlocks();
            } catch(Exception exception)
            {
                Console.WriteLine("Error - " + exception.ToString());
            }
        }

        public void getLanguages(IEnumerable enumerable)
        {
            if (enumerable != null)
            {
                try {
                    int i = 0;
                    foreach (XSSFCell cell in enumerable)
                    {
                        if (i > 0)
                        {
                            cmsBlockFactory.languages.Add(new CMSLanguage(cell.StringCellValue));
                        }
                        i++;
                    }
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
            }
        }

        public void processDataCells(IEnumerable enumerable)
        {
            if (enumerable != null)
            {
                try
                {
                    int i = 0;
                    string placeholder = "";
                    foreach (XSSFCell cell in enumerable)
                    {
                        if (i > 0)
                        {
                            CMSLanguage currentLanguage = cmsBlockFactory.languages[i - 1];
                            currentLanguage.ContentPieces.Add(new ContentPieces(placeholder, cell.StringCellValue));
                        }
                        else
                        {
                            placeholder = cell.StringCellValue;
                        }
                        i++;
                    }
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.ToString());
                }
            }
        }
    }
}
