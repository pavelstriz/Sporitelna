using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Sporitelna
{
    public class ColumnOrderAndWidth
    {
        
        public static Dictionary<string, int> columnsOriginalWidth1 = new Dictionary<string, int>();
        public static Dictionary<string, int> columnsOriginalWidth2 = new Dictionary<string, int>();
        public static string fileName1 = Application.StartupPath + "/grid users.xml";         public static string fileName2 = Application.StartupPath + "/grid contracts.xml";
        public static void LoadDGVsWidthAndOrder_USERS(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                columnsOriginalWidth1.Add(column.Name, column.Width);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<GridColumn>));
            TextReader reader = null;
            List<GridColumn> xmlColumnCollection1 = new List<GridColumn>();

            if (File.Exists(fileName1))
            {
                try
                {
                    reader = new StreamReader(fileName1);

                    xmlColumnCollection1 = serializer.Deserialize(reader) as List<GridColumn>;

                    foreach (GridColumn xmlColumn in xmlColumnCollection1)
                    {
                        dgv.Columns[xmlColumn.Name1].DisplayIndex = xmlColumn.Index1;
                        dgv.Columns[xmlColumn.Name1].Width = xmlColumn.Width1;
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public static void SaveWidthAndOrder_USERS(DataGridView dgv)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<GridColumn>));

            TextWriter writer = new StreamWriter(fileName1);

            List<GridColumn> xmlColumnCollection = new List<GridColumn>();

            try
            {
                foreach (DataGridViewColumn gridColumn in dgv.Columns)
                {
                    GridColumn xmlColumn = new GridColumn();

                    xmlColumn.Name1 = gridColumn.Name;
                    xmlColumn.Index1 = gridColumn.DisplayIndex;
                    xmlColumn.Width1 = gridColumn.Width;

                    xmlColumnCollection.Add(xmlColumn);
                }

                try
                {
                    serializer.Serialize(writer, xmlColumnCollection);
                }
                catch (Exception ex)
                {
                }
            }
            finally
            {
                writer.Close();

            }
        }
        public static void ResetWidthAndOrder_USERS(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.DisplayIndex = column.Index;
                column.Width = columnsOriginalWidth1[column.Name];
                
            }
                        if (File.Exists(fileName1))
                File.Delete(fileName1);
        }


        public static void LoadDGVsWidthAndOrder_Contracts(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                columnsOriginalWidth2.Add(column.Name, column.Width);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<GridColumn>));
            TextReader reader = null;
            List<GridColumn> xmlColumnCollection = new List<GridColumn>();

            if (File.Exists(fileName2))
            {
                try
                {
                    reader = new StreamReader(fileName2);

                    xmlColumnCollection = serializer.Deserialize(reader) as List<GridColumn>;

                    foreach (GridColumn xmlColumn in xmlColumnCollection)
                    {
                        dgv.Columns[xmlColumn.Name2].DisplayIndex = xmlColumn.Index2;
                        dgv.Columns[xmlColumn.Name2].Width = xmlColumn.Width2;
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public static void SaveWidthAndOrder_CONTRACTS(DataGridView dgv)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<GridColumn>));

            TextWriter writer = new StreamWriter(fileName2);

            List<GridColumn> xmlColumnCollection = new List<GridColumn>();

            try
            {
                foreach (DataGridViewColumn gridColumn in dgv.Columns)
                {
                    GridColumn xmlColumn = new GridColumn();

                    xmlColumn.Name2 = gridColumn.Name;
                    xmlColumn.Index2 = gridColumn.DisplayIndex;
                    xmlColumn.Width2 = gridColumn.Width;

                    xmlColumnCollection.Add(xmlColumn);
                }

                try
                {
                    serializer.Serialize(writer, xmlColumnCollection);
                }
                catch (Exception ex)
                {
                }
            }
            finally
            {
                writer.Close();

            }
        }
        public static void ResetWidthAndOrder_CONTRACTS(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.DisplayIndex = column.Index;
                column.Width = columnsOriginalWidth2[column.Name];

            }
            if (File.Exists(fileName2))
                File.Delete(fileName2);
        }
        /*
        public XmlSerializer CreateOverrider()
        {
                        XmlAttributeOverrides xOver = new XmlAttributeOverrides();
            XmlAttributes xAttrs = new XmlAttributes();

                        XmlArrayAttribute xArray = new XmlArrayAttribute("Staff");
            xArray.Namespace = "http:            xAttrs.XmlArray = xArray;
            xOver.Add(typeof(Group), "Members", xAttrs);

                        return new XmlSerializer(typeof(Group), xOver);
        }
        */

        public class GridColumn
        {
            [XmlElement]
            public String Name1 { get; set; }

            [XmlElement]
            public int Index1 { get; set; }

            [XmlElement]
            public int Width1 { get; set; }

            [XmlElement]
            public int Height1 { get; set; }
            [XmlElement]
            public String Name2 { get; set; }

            [XmlElement]
            public int Index2 { get; set; }

            [XmlElement]
            public int Width2 { get; set; }

            [XmlElement]
            public int Height2 { get; set; }
        }
    }
}
