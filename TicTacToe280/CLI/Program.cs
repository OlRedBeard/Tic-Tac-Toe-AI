using System;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;
using System.Text;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(@"E:\PublicKeys"))
            {
                Directory.CreateDirectory(@"E:\PublicKeys");
            }

            if (!Directory.Exists(@"E:\PrivateKeys"))
            {
                Directory.CreateDirectory(@"E:\PrivateKeys");
            }

            if (!File.Exists(@"E:\PrivateKeys\private.key"))
                GenerateNewKeys();

            switch (args[0])
            {
                case ("--encrypt"):
                    Encrypt(args[1], args[2]);
                    break;
                case ("--decrypt"):
                    Decrypt(args[1], args[2]);
                    break;
            }
        }

        static void GenerateNewKeys()
        {
            // Create the path for the private key file
            string myPrivateKeyFile = @"E:\PrivateKeys\private.key";

            // Path to the public key
            string partial = myPrivateKeyFile.Replace("Private", "Public");
            string myPublicKey = partial.Replace("private", "public");

            // Generate a new key pair
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048); // Sets the key size            
            string privateKeyText = rsa.ToXmlString(true); // Get the private key            
            string publicKeyText = rsa.ToXmlString(false); // Get the public key

            // Write the keys to disc
            File.WriteAllText(myPrivateKeyFile, privateKeyText);
            File.WriteAllText(myPublicKey, publicKeyText);
        }

        static void Encrypt(string keypath, string filepath)
        {
            // Make sure there's a public key, otherwise report to user
            if (!File.Exists(keypath))
            {
                Console.WriteLine("No public key available.");
                return;
            }

            // Load the public key
            string publicKey = File.ReadAllText(keypath);

            // Create an RSA object based on the existing key
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            // Load
            rsa.FromXmlString(publicKey);
            string contents = File.ReadAllText(filepath);

            // Encrypt message
            byte[] output = rsa.Encrypt(Encoding.ASCII.GetBytes(contents), true);

            // Write the encrypted file and add enc to filename
            File.WriteAllBytes(filepath + ".enc", output);
        }

        static void Decrypt(string keypath, string filepath)
        {
            try
            {
                // Load the private key
                if (!File.Exists(keypath))
                {
                    Console.WriteLine("No private key found.");
                    return;
                }

                string myPrivateKey = File.ReadAllText(keypath);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(myPrivateKey);

                // Read all bytes
                byte[] input = File.ReadAllBytes(filepath);

                // Convert byte array into plain, decrypted text
                string plainText = Encoding.Default.GetString(rsa.Decrypt(input, true));

                File.WriteAllText(filepath + "dec", plainText);
            }
            catch
            {
                Console.WriteLine("Unable to decrypt file.");
            }
        }
    }
}
