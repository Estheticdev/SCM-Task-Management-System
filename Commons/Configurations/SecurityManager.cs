using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Commons.Configuration
{
    public class SecurityManager
    {
        //private static TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        //the following keys should be kept same in this config utility and in DISC.
        private static string myKey = "TemporarySecretKey";

        private static string myVector = "TemporaryVector";
        private static byte[] Key
        {
            get { return Encoding.Default.GetBytes(myKey.PadRight(24)); }
        }
        private static byte[] Vector
        {
            get { return Encoding.Default.GetBytes(myVector.PadRight(8)); }
        }

        public static string Encrypt(string Text)
        {
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            string a = null;

            if (Text.Trim() == "")
                return "";

            try
            {
                ICryptoTransform CryptoTransform = null;
                CryptoTransform = des.CreateEncryptor(Key, Vector);

                MemoryStream stream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(stream, CryptoTransform, CryptoStreamMode.Write);
                byte[] Input = Encoding.Default.GetBytes(Text);

                cryptoStream.Write(Input, 0, Input.Length);
                cryptoStream.FlushFinalBlock();

                a = System.Convert.ToBase64String(stream.ToArray());
                return a;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string Decrypt(string encryptedText)
        {
            //Return Transform(encryptedText, des.CreateDecryptor(Key, Vector))
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            if (encryptedText.Trim() == "")
                return "";

            try
            {
                ICryptoTransform CryptoTransform = null;
                CryptoTransform = des.CreateDecryptor(Key, Vector);
                MemoryStream stream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(stream, CryptoTransform, CryptoStreamMode.Write);

                byte[] Input = System.Convert.FromBase64String(encryptedText);

                cryptoStream.Write(Input, 0, Input.Length);
                cryptoStream.FlushFinalBlock();

                return Encoding.Default.GetString(stream.ToArray());
            }
            catch (Exception)
            {
                throw;
            }
        }


        private static string Transform(string Text, ICryptoTransform CryptoTransform)
        {
            MemoryStream stream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(stream, CryptoTransform, CryptoStreamMode.Write);

            byte[] Input = Encoding.Default.GetBytes(Text);

            cryptoStream.Write(Input, 0, Input.Length);
            cryptoStream.FlushFinalBlock();

            return Encoding.Default.GetString(stream.ToArray());
        }

        public static string EncryptAndSaveFile(Stream inputFilename, string filePath)
        {
            try
            {
                using (inputFilename)
                {
                    byte[] theKey;
                    byte[] theVector;

                    string configVector = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["vect64bit"]);
                    string configKey = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["key128bit"]);

                    if (!string.IsNullOrEmpty(configKey))
                        theKey = Encoding.Default.GetBytes(configKey.PadRight(16));
                    else
                        theKey = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38 };  //must 24 bytes

                    if (!string.IsNullOrEmpty(configVector))
                        theVector = Encoding.Default.GetBytes(configVector.PadRight(8));
                    else
                        theVector = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48 };

                    using (FileStream fsOutput = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        TripleDESCryptoServiceProvider oTDES = new TripleDESCryptoServiceProvider();
                        oTDES.Mode = CipherMode.CBC;
                        oTDES.Padding = PaddingMode.PKCS7;

                        oTDES.Key = theKey;
                        oTDES.IV = theVector;

                        // Now create a crypto stream through which we are going
                        // to be pumping data.
                        // The fsOutput is going to be receiving the encrypted bytes.
                        CryptoStream oCryptoStream = new CryptoStream(fsOutput, oTDES.CreateEncryptor(), CryptoStreamMode.Write);
                        // Now will will initialize a buffer and will be processing the input file in chunks.
                        // This is done to avoid reading the whole file (which can be huge) into memory.
                        int bufferLen = 4096;
                        byte[] buffer = new byte[bufferLen];
                        int bytesRead;

                        do
                        {
                            // read a chunk of data from the input file
                            bytesRead = inputFilename.Read(buffer, 0, bufferLen);
                            // encrypt it
                            oCryptoStream.Write(buffer, 0, bytesRead);
                        }
                        while (bytesRead != 0);
                        oCryptoStream.Close();
                        oTDES.Clear();
                    }
                }

                return "Success";
            }
            catch (CryptographicException cex)
            {
                throw cex;
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Remian Open the input stream in case of Zip stream encryption
        /// </summary>
        /// <param name="inputFilename"></param>
        /// <param name="filePath"></param>
        /// <param name="doCloseStream"></param>
        /// <returns></returns>
        public static string EncryptAndSaveFile(Stream inputFilename, string filePath, bool doCloseStream)
        {
            try
            {
                //  using (inputFilename)
                //  {
                byte[] theKey;
                byte[] theVector;

                string configVector = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["vect64bit"]);
                string configKey = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["key128bit"]);

                if (!string.IsNullOrEmpty(configKey))
                    theKey = Encoding.Default.GetBytes(configKey.PadRight(16));
                else
                    theKey = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38 };  //must 24 bytes

                if (!string.IsNullOrEmpty(configVector))
                    theVector = Encoding.Default.GetBytes(configVector.PadRight(8));
                else
                    theVector = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48 };

                using (FileStream fsOutput = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    TripleDESCryptoServiceProvider oTDES = new TripleDESCryptoServiceProvider();
                    oTDES.Mode = CipherMode.CBC;
                    oTDES.Padding = PaddingMode.PKCS7;
                    oTDES.Key = theKey;
                    oTDES.IV = theVector;

                    // Now create a crypto stream through which we are going
                    // to be pumping data.
                    // The fsOutput is going to be receiving the encrypted bytes.
                    CryptoStream oCryptoStream = oCryptoStream = new CryptoStream(fsOutput, oTDES.CreateEncryptor(), CryptoStreamMode.Write);
                    // Now will will initialize a buffer and will be processing the input file in chunks.
                    // This is done to avoid reading the whole file (which can be huge) into memory.
                    int bufferLen = 4096;
                    byte[] buffer = new byte[bufferLen];
                    int bytesRead;

                    do
                    {
                        // read a chunk of data from the input file
                        bytesRead = inputFilename.Read(buffer, 0, bufferLen);
                        // encrypt it
                        oCryptoStream.Write(buffer, 0, bytesRead);
                    }
                    while (bytesRead != 0);
                    oCryptoStream.Close();
                    oTDES.Clear();
                    //  }
                }
                return "Success";
            }
            catch (CryptographicException cex)
            {
                throw cex;
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string EncryptAndSaveFile(string inputFilepath, string filePath)
        {
            try
            {
                byte[] theKey;
                byte[] theVector;

                string configVector = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["vect64bit"]);
                string configKey = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["key128bit"]);

                if (!string.IsNullOrEmpty(configKey))
                    theKey = Encoding.Default.GetBytes(configKey.PadRight(16));
                else
                    theKey = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38 };  //must 24 bytes

                if (!string.IsNullOrEmpty(configVector))
                    theVector = Encoding.Default.GetBytes(configVector.PadRight(8));
                else
                    theVector = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48 };

                using (FileStream inputFilename = new FileStream(inputFilepath, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream fsOutput = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        TripleDESCryptoServiceProvider oTDES = new TripleDESCryptoServiceProvider();
                        oTDES.Mode = CipherMode.CBC;
                        oTDES.Padding = PaddingMode.PKCS7;
                        oTDES.Key = theKey;
                        oTDES.IV = theVector;

                        // Now create a crypto stream through which we are going
                        // to be pumping data.
                        // The fsOutput is going to be receiving the encrypted bytes.
                        CryptoStream oCryptoStream = new CryptoStream(fsOutput, oTDES.CreateEncryptor(), CryptoStreamMode.Write);
                        // Now will will initialize a buffer and will be processing the input file in chunks.
                        // This is done to avoid reading the whole file (which can be huge) into memory.
                        int bufferLen = 4096;
                        byte[] buffer = new byte[bufferLen];
                        int bytesRead;

                        do
                        {
                            // read a chunk of data from the input file
                            bytesRead = inputFilename.Read(buffer, 0, bufferLen);
                            // encrypt it
                            oCryptoStream.Write(buffer, 0, bytesRead);
                        }
                        while (bytesRead != 0);
                        oCryptoStream.Close();
                        oTDES.Clear();
                    }
                }
                return "Success";
            }
            catch (CryptographicException cex)
            {
                throw cex;
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string DecryptAndSaveFile(string inputFilename, string destinationFilePath)
        {
            try
            {
                byte[] filecontent = DecryptAndGetFileContents(inputFilename);
                using (FileStream fsOutput = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
                {
                    fsOutput.Write(filecontent, 0, filecontent.Length);
                }
                return "success";

            }
            catch (CryptographicException cex)
            {
                throw cex;
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Decrypt the given file at same path as of given file
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="fileNamePrefix"></param>
        /// <returns></returns>
        public static bool DecryptFile(string inputFilePath)
        {
            string message = string.Empty;
            try
            {
                string tempFilePath = string.Empty;
                string filename = filename = Path.GetFileName(inputFilePath);

                if (File.Exists(inputFilePath))
                {
                    tempFilePath = Path.GetDirectoryName(inputFilePath) + Path.DirectorySeparatorChar + Guid.NewGuid() + "_" + filename;

                    File.Move(inputFilePath, tempFilePath);

                    File.Delete(inputFilePath);

                    message = DecryptAndSaveFile(tempFilePath, inputFilePath);

                    try
                    {
                        File.Delete(tempFilePath);
                    }
                    catch (Exception)
                    {

                        // Do Nothing
                    }

                    return true;
                }
                else
                    throw new ApplicationException("Decryption failed; File not found at:" + inputFilePath);



            }
            catch (CryptographicException cex)
            {
                throw cex;
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Stream DecryptAndGetFileStream(string inputFilename)
        {
            Stream sReader;
            try
            {
                sReader = new MemoryStream(DecryptAndGetFileContents(inputFilename));
                return sReader;
            }
            catch (CryptographicException cex)
            {
                throw cex;
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public static byte[] DecryptFileStream(Stream fsInput)
        {
            byte[] readBuffer = new byte[4096];
            CryptoStream oCryptoStream;
            StreamReader sReader;
            try
            {
                byte[] theKey;
                byte[] theVector;

                string configVector = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["vect64bit"]);
                string configKey = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["key128bit"]);

                if (!string.IsNullOrEmpty(configKey))
                    theKey = Encoding.Default.GetBytes(configKey.PadRight(16));
                else
                    theKey = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38 };  //must 16 bytes
                if (!string.IsNullOrEmpty(configVector))
                    theVector = Encoding.Default.GetBytes(configVector.PadRight(8));
                else
                    theVector = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48 };

                // using (FileStream fsInput = new FileStream(inputFilename, FileMode.Open, FileAccess.Read))
                //                {
                TripleDESCryptoServiceProvider oTDES = new TripleDESCryptoServiceProvider();
                oTDES.Mode = CipherMode.CBC;
                oTDES.Padding = PaddingMode.PKCS7;
                oTDES.Key = theKey;
                oTDES.IV = theVector;

                // Now create a crypto stream through which we are going
                // to be pumping data.
                // The fsOutput is going to be receiving the encrypted bytes.
                oCryptoStream = new CryptoStream(fsInput, oTDES.CreateDecryptor(), CryptoStreamMode.Read);
                // Now will will initialize a buffer and will be processing the input file in chunks.
                // This is done to avoid reading the whole file (which can be huge) into memory.

                // Create a StreamReader using the CryptoStream.
                sReader = new StreamReader(oCryptoStream);
                readBuffer = ReadToEnd(sReader.BaseStream);
                oCryptoStream.Close();
                oTDES.Clear();
                sReader.Close();

                //   }
                return readBuffer;
            }
            catch (CryptographicException cex)
            {
                throw cex;
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        }

        public static byte[] DecryptAndGetFileContents(string inputFilename)
        {
            byte[] readBuffer = new byte[4096];
            CryptoStream oCryptoStream;
            StreamReader sReader;
            try
            {
                byte[] theKey;
                byte[] theVector;

                string configVector = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["vect64bit"]);
                string configKey = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["key128bit"]);

                if (!string.IsNullOrEmpty(configKey))
                    theKey = Encoding.Default.GetBytes(configKey.PadRight(16));
                else
                    theKey = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38 };  //must 24 bytes

                if (!string.IsNullOrEmpty(configVector))
                    theVector = Encoding.Default.GetBytes(configVector.PadRight(8));
                else
                    theVector = new byte[] { 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48 };

                using (FileStream fsInput = new FileStream(inputFilename, FileMode.Open, FileAccess.Read))
                {
                    TripleDESCryptoServiceProvider oTDES = new TripleDESCryptoServiceProvider();
                    oTDES.Mode = CipherMode.CBC;
                    oTDES.Padding = PaddingMode.PKCS7;
                    oTDES.Key = theKey;
                    oTDES.IV = theVector;

                    // Now create a crypto stream through which we are going
                    // to be pumping data.
                    // The fsOutput is going to be receiving the encrypted bytes.
                    oCryptoStream = new CryptoStream(fsInput, oTDES.CreateDecryptor(), CryptoStreamMode.Read);
                    // Now will will initialize a buffer and will be processing the input file in chunks.
                    // This is done to avoid reading the whole file (which can be huge) into memory.

                    // Create a StreamReader using the CryptoStream.
                    sReader = new StreamReader(oCryptoStream);
                    readBuffer = ReadToEnd(sReader.BaseStream);

                    oCryptoStream.Close();
                    oTDES.Clear();
                    sReader.Close();

                }
                return readBuffer;
            }
            catch (CryptographicException cex)
            {
                throw cex;
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        }

        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            //  long originalPosition = stream.Position;
            //  stream.Position = 0;

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                // stream.Position = originalPosition;
            }
        }

        public static byte[] GetFileContents(string inputFilename)
        {
            byte[] readBuffer = new byte[4096];
            StreamReader sReader;
            try
            {
                using (FileStream fsInput = new FileStream(inputFilename, FileMode.Open, FileAccess.Read))
                {
                    sReader = new StreamReader(fsInput);
                    readBuffer = ReadToEnd(sReader.BaseStream);
                    sReader.Close();

                }
                return readBuffer;
            }
            catch (IOException ioe)
            {
                throw ioe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        }
    }
}
