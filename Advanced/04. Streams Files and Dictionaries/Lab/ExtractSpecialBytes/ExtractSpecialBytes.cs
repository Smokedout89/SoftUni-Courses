namespace ExtractBytes
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            const string binaryFilePath = @"..\..\..\Files\example.png";
            const string bytesFilePath = @"..\..\..\Files\bytes.txt";
            const string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader readerBit = new StreamReader(bytesFilePath))
            {
                while (!readerBit.EndOfStream)
                {
                    sb.Append(readerBit.ReadLine() + " ");
                }
            }

            byte[] bytes = sb.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(byte.Parse).ToArray();


            using (FileStream reader = new FileStream(binaryFilePath, FileMode.Open))
            {
                byte[] buff = new byte[reader.Length];

                reader.Read(buff, 0, buff.Length);

                using (FileStream write = new FileStream(outputPath, FileMode.OpenOrCreate))
                {
                    foreach (byte item in buff)
                    {
                        if (bytes.Contains(item))
                        {
                            write.WriteByte(item);
                        }
                    }
                }
            }
        }
    }
}
