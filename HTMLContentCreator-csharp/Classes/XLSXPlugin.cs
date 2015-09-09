using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace HTMLContentCreator_csharp
{
    class XLSXPlugin : ContentFormatPlugin, IContentFormat
    {
        private XSSFWorkbook workBook;
        private ISheet sheet;
        
        public XLSXPlugin(string contentFormat, string contentEncoding, string currentFile, string currentWorkingDirectory)
        {
            this.contentFormat = new ContentFormat(contentFormat, contentEncoding);
            this.currentFile = currentFile;
            this.fileInput = new FileStream(Path.Combine(currentWorkingDirectory, @"..\..\", this.currentFile), FileMode.Open, FileAccess.Read);
            this.workBook = new XSSFWorkbook(this.fileInput);
            this.currentPageName = currentFile.Substring(this.currentFile.LastIndexOf("/") + 1, this.currentFile.LastIndexOf("."));
            this.currentWorkingDirectory = currentWorkingDirectory;
            this.sheet = this.workBook.GetSheet("Sheet1");
            processDataRows();
        }

        public void processDataRows()
        {
            try
            {
                for (int row = 0; row <= this.sheet.LastRowNum; row++)
                {
                    IRow r = this.sheet.GetRow(row);
                    if (row == 0)
                    {
                        this.getLanguages(r.Cells);
                    }
                    else
                    {
                        this.processDataCells(r.Cells);
                    }
                }
                this.getCMSBlocks();
            } catch(Exception exception)
            {
                Console.WriteLine("Error - " + exception.ToString());
            }
        }

        public void getLanguages(IEnumerable enumerable)
        {
            if (enumerable != null)
            {
                int i = 0;
                foreach (XSSFCell cell in enumerable)
                {
                    if(i > 0)
                    { 
                        this.languages.Add(new CMSLanguage(cell.StringCellValue));
                    }
                    i++;
                }
            }
        }

        public void processDataCells(IEnumerable enumerable)
        {
            if (enumerable != null)
            {
                int i = 0;
                string placeholder = "";
                foreach (XSSFCell cell in enumerable)
                {
                    if (i > 0)
                    {
                        CMSLanguage currentLanguage = this.languages[i - 1];
                        currentLanguage.ContentPieces.Add(new ContentPieces(placeholder, cell.StringCellValue));
                    }
                    else
                    {
                        placeholder = cell.StringCellValue;
                    }
                    i++;
                }

            }
        }
    }
}
