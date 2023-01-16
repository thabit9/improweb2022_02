using System;
using System.Data;
using System.Configuration;
using System.Web;
/*using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;*/
using System.IO;
using System.Text;

namespace improweb2022_02.Helpers
{
    public class Base64
    {
        private int bufferSize = 1048576;
        public int BufferSize
        {
            get { return bufferSize; }
            set { bufferSize = value; }
        }

        private string B64Encode(byte[] binaryData)
        {
            return System.Convert.ToBase64String(binaryData).Replace("=", "");
        }

        private byte[] B64Decode(string encodedString)
        {
            return System.Convert.FromBase64String(encodedString);
        }

        public string Encode(Stream streamToEncode, int lineLength)
        {
            if (lineLength > 76)
                lineLength = 76;
            else if (lineLength % 4 > 0)
                lineLength = (lineLength / 4) * 4;

            int readSize = (lineLength * 3) / 4;
            StringBuilder returnString = new StringBuilder();
            int totalCharacters = 0;
            StreamReader charReader = new StreamReader(streamToEncode, Encoding.Default, true, BufferSize);
            char[] charArr = new char[readSize];
            string encodedString = "";
            int readBytes = charReader.ReadBlock(charArr, 0, readSize);

            while (readBytes != 0)
            {
                //Raise progress event
                encodedString = B64Encode(Encoding.Default.GetBytes(charArr, 0, readBytes));
                totalCharacters += encodedString.Length;
                returnString.Append(encodedString + "\r\n");
                readBytes = charReader.ReadBlock(charArr, 0, readSize);
            }
            returnString.Remove(returnString.Length - 2, 2);
            if (totalCharacters % 4 > 0) returnString.Append(new string('=', 4 - (totalCharacters % 4)));

            return returnString.ToString();
        }

        public void Decode(Stream streamToDecode, string filename)
        {
            StreamReader charReader = new StreamReader(streamToDecode, Encoding.Default, true, BufferSize);
            FileStream outStream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, BufferSize);
            string line = charReader.ReadLine();
            byte[] byteArray;
            while (line != null)
            {
                //Raise progress event
                byteArray = B64Decode(line);
                outStream.Write(byteArray, 0, byteArray.Length);
                line = charReader.ReadLine();
            }
            outStream.Close();
        }
    }
}
