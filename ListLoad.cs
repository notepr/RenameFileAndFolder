using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rename_File_Or_Foder
{
    class ListLoad
    {
        public Boolean Select { get; set; }
        public string Path { get; set; }
        public DateTime DateModified { get; set; }
        public string FileName { get; set; }
        public string NewFileName { get; set; }
        public string Status { get; set; }
        public DateTime DateCreate { get; set; }
        public void SetValueByName(string byName, string value)
        {
            if (value is null)
                return;
            switch (byName)
            {
                case "Path":
                    this.Path = value;
                    try
                    {
                        this.FileName = value.Split('\\').Last();
                    }
                    catch
                    {
                        this.Status = "Path Error";
                        //nothing!!!!!!
                    }
                    break;
                case "DateModified":
                    try
                    {
                        double d = double.Parse(value);
                        this.DateModified = DateTime.FromOADate(d);
                    }
                    catch
                    {

                    }
                    break;
                case "FileName":
                    //this.FileName = value;
                    break;
                case "NewFileName":
                    this.NewFileName = value;
                    break;
                case "Status":
                    if (this.Status is null)
                    {
                        //nothing!!!!!!
                    }
                    else
                    {
                        this.Status = value;
                    }
                    break;
                case "Select":
                    this.Select = Convert.ToBoolean(value);
                    break;
                case "DateCreate":
                    try
                    {
                        double d = double.Parse(value);
                        this.DateCreate = DateTime.FromOADate(d);
                    }
                    catch( Exception ex)
                    {
                        Console.WriteLine(value);
                    }
                    break;
            }
        }
    }
}
