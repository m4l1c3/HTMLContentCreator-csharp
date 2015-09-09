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
        //private FormulaEvaluator evaluator;
        //private DataFormatter dataFormatter = new DataFormatter();


        public XLSXPlugin(string contentFormat, string contentEncoding, string currentFile, string currentWorkingDirectory)
        {
            this.contentFormat = new ContentFormat(contentFormat, contentEncoding);
            this.fileInput = new FileStream(Path.Combine(currentWorkingDirectory, @"..\..\", currentFile), FileMode.Open, FileAccess.Read);
            this.workBook = new XSSFWorkbook(this.fileInput);
            this.currentPageName = currentFile.Substring(currentFile.LastIndexOf("/") + 1, currentFile.LastIndexOf("."));
            this.currentWorkingDirectory = currentWorkingDirectory;
            this.sheet = this.workBook.GetSheet("Sheet1");
            this.processDataRows();
        }

        public void getCMSBlocks()
        {
            if (this.languages.Count() > 0)
            {
                foreach(CMSLanguage currentLanguage in this.languages)
                {
                    CMSBlock cmsBlock = new CMSBlock(this.currentPageName, currentLanguage);
                    this.cmsBlocks.Add(cmsBlock);
                }
            }
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
            else
            {
                throw new NotImplementedException();
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
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
