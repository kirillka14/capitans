using Csezar;

namespace TestProject1
{
    public class Tests
    {

        
        public class EncryptionTests
        {
            private string path;

            [SetUp]
            public void Setup ()
            {
                path = "test.txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write("тестовая строка");
                }
            }

            [Test]
            public void Crypt_FileExists_FileIsEncrypted ()
            {
                int key = 3;
                string expected = "Файл зашифрован";

                string result = Encryption.Cesar.Crypt(key, path);

                Assert.AreEqual(expected, result);

                using (StreamReader sr = new StreamReader(path))
                {
                    string str = sr.ReadToEnd();
                    Assert.AreNotEqual("тестовая строка", str);
                }
            }

            [Test]
            public void Crypt_FileNotExists_ReturnsFileNotFound ()
            {
                int key = 3;
                string expected = "Файл не найден";

                string result = Encryption.Cesar.Crypt(key, "fake.txt");

                Assert.AreEqual(expected, result);
            }

            [Test]
            public void Decrypt_FileExists_FileIsDecrypted ()
            {
                int key = 3;
                string expected = "Файл расшифрован";

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write("эхъёлщйн фхэфхфн");
                }

                string result = Encryption.Cesar.Decrypt(key, path);

                Assert.AreEqual(expected, result);

                using (StreamReader sr = new StreamReader(path))
                {
                    string str = sr.ReadToEnd();
                    Assert.AreEqual("тестовая строка", str);
                }
            }

            [Test]
            public void Decrypt_FileNotExists_ReturnsFileNotFound ()
            {
                int key = 3;
                string expected = "Файл не найден";

                string result = Encryption.Cesar.Decrypt(key, "fake.txt");

                Assert.AreEqual(expected, result);
            }

            [TearDown]
            public void TearDown ()
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
        }


    }
}