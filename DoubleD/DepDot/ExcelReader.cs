using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Excel;

namespace DepDot
{
    public class ExcelReader
    {
        public ExcelReader() { }

        public static List<LineItem> Read(string inputFile, bool noFrom, bool includePast)
        {
            //if the date filter is enabled, enable past dependencies
            //if (filterDate) includePast = true;

            try
            {
                FileStream testStream = File.Open(inputFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                testStream.Close();
                testStream.Dispose();
            }
            catch (Exception e)
            {
                throw new ApplicationException("ERROR: Couldn't open " + inputFile + " - " + e.Message);
            }

            FileStream stream = File.Open(inputFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            IExcelDataReader excelReader;
            int row = 0;
            List<LineItem> lines = new List<LineItem>();

            if (inputFile.ToLower().Contains("xlsx"))
            {
                //Reading from a OpenXml Excel file (2007 format; *.xlsx)
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }
            else
            {
                //Reading from a binary Excel file ('97-2003 format; *.xls)
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }

            try
            {
                excelReader.IsFirstRowAsColumnNames = true;
                DataSet result = excelReader.AsDataSet(new List<string> { "Specific" });

                while (excelReader.Read())
                {
                    if (row > 0)
                    {
                        #region File Columns
                        //Owner 0
                        //Last Update 1
                        //Follow up 2
                        //Schedule 3
                        //Version 4
                        //To prod 5
                        //Strategic 6
                        //Project Name 7
                        //ID 8
                        //Direction 9
                        //Ref. # 10
                        //Dependency 11
                        //Impact size 12
                        //Control 13
                        //Status 14
                        //Display comment 15
                        //Internal Comment 16
                        #endregion

                        LineItem li = new LineItem();

                        li.Owner = excelReader.GetString(0);
                        li.LastUpdate = excelReader.GetDateTime(1);
                        
                        li.Schedule = excelReader.GetString(3);
                        li.Version = excelReader.GetString(4);
                        if (!string.IsNullOrEmpty(li.Version))
                        {
                            if (li.Version.Contains("0999999999999996"))
                            {
                                li.Version = li.Version.Replace("0999999999999996", "1");
                            }
                        }
                        
                        li.ToProduction = excelReader.GetDateTime(5);
                        
                        //if the date is invalid, set it to tomorrow so it's included in results
                        if (li.ToProduction.Year==1)
                        {
                            li.ToProduction = DateTime.Now.AddDays(1);
                        }
                        li.Strategic = excelReader.GetString(6);
                        li.ProjectName = excelReader.GetString(7);
                        li.Id = excelReader.GetInt32(8);
                        li.Direction = excelReader.GetString(9);
                        li.Reference = excelReader.GetString(10);
                        li.Dependency = excelReader.GetString(11);

                        if (!string.IsNullOrEmpty(excelReader.GetString(12)))
                        {
                            li.Impact = (Impact)Enum.Parse(typeof(Impact), excelReader.GetString(12));
                        }
                        else
                        {
                            li.Impact = Impact.S;
                        }

                        if (!string.IsNullOrEmpty(excelReader.GetString(13)))
                        {
                            li.Control = (Control)Enum.Parse(typeof(Control), excelReader.GetString(13));
                        }
                        else
                        {
                            li.Control = Control.UNKNOWN;
                        }



                        //Console.WriteLine(li.LastUpdate.ToShortDateString());

                        if (noFrom && li.Direction == "FROM")
                        {
                            row++;
                            continue;
                        }

                        //ignore empty lines in the spreadsheet
                        if (string.IsNullOrEmpty(excelReader.GetString(7)) && string.IsNullOrEmpty(excelReader.GetString(8)))
                        {
                            //Console.WriteLine("WARNING: ignoring line " + row.ToString() + " because it's empty");
                            row++;
                            continue;
                        }

                        

                        //if the dependency isn't closed, add the row
                        if (li.Control != Control.CLOSED)
                        {
                            lines.Add(li);
                        }
                    }
                    row++;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("ERROR: Could not process Excel file (must contain Tab called 'Specific' and be well formed)"); //... " + e.Message);
            }
            finally
            {
                excelReader.Close();
            }

            return lines;
        }
    }
}
