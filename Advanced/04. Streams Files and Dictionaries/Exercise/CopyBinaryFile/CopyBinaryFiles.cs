using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";
            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream readear = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream writer = new FileStream(outputFilePath, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        int countBytes = readear.Read(buffer, 0, buffer.Length);

                        if (countBytes == 0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, countBytes);
                    }
                }
            }
        }
    }
}
