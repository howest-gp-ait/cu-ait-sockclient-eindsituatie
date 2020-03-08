using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Data;
using System.IO;
namespace SockClient.Lib
{
    public class Helper
    {
        public static DataTable ReadConfigFile()
        {
            string XMLBestand = Directory.GetCurrentDirectory() + "/config.xml";
            if (!File.Exists(XMLBestand))
            {
                MakeConfigFile();
            }
            DataSet ds = new DataSet();
            ds.ReadXml(XMLBestand, XmlReadMode.ReadSchema);
            return ds.Tables[0];
        }
        public static void UpdateConfigFile(string ServerIp, int ServerPort)
        {
            string XMLBestand = Directory.GetCurrentDirectory() + "/config.xml";
            if (!File.Exists(XMLBestand))
            {
                MakeConfigFile();
            }
            DataSet ds = new DataSet();
            ds.ReadXml(XMLBestand, XmlReadMode.ReadSchema);
            ds.Tables[0].Rows[0][0] = ServerIp;
            ds.Tables[0].Rows[0][1] = ServerPort;
            ds.WriteXml(XMLBestand, XmlWriteMode.WriteSchema);

        }
        private static void MakeConfigFile()
        {
            DataSet ds = new DataSet();
            DataTable dt = ds.Tables.Add();
            DataColumn dc;
            dc = new DataColumn();
            dc.ColumnName = "ServerIp";
            dc.DataType = typeof(string);
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "ServerPort";
            dc.DataType = typeof(int);
            dt.Columns.Add(dc);
            DataRow dr = dt.NewRow();
            dr[0] = "127.0.0.1";
            dr[1] = 44000;
            dt.Rows.Add(dr);
            string XMLBestand = Directory.GetCurrentDirectory() + "/config.xml";
            ds.WriteXml(XMLBestand, XmlWriteMode.WriteSchema);
        }
    }
}
