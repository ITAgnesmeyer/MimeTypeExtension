using System.IO;
using MimeTypeExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestMimeTypeExtension
{
    [TestClass]
    public class MainTest
    {

        [TestMethod]
        public void TestUrl()
        {
            string url = "http://localhost/test.jpg";
            Uri uri = new Uri(url);
            string mimeType = uri.MimeType();
            Assert.AreEqual("image/jpeg", mimeType);
        }

        [TestMethod]
        public void TestLoadExtension()
        {
            string fileName = "test.jpg";
            FileInfo fi = new FileInfo(fileName);
            string mimeType = fi.MimeType();
            Assert.AreEqual("image/jpeg", mimeType);
        }
        [TestMethod]
        public void TestJpegExtension()
        {
            FileInfo fi = new FileInfo("test.jpeg");
            string mimeType = fi.MimeType();
            Assert.AreEqual("image/jpeg", mimeType, "cannot find MimeType for JPEG");
        }
        [TestMethod]
        public void TestPPTExtension()
        {
            FileInfo fi = new FileInfo("test.pptx");
            string mimeType = fi.MimeType();
            Assert.AreEqual("application/vnd.openxmlformats-officedocument.presentationml.presentation", mimeType, "Cannot find MIME-Type for PPTX");
           
        }

        [TestMethod]
        public void TestWasmExtension()
        {
            FileInfo fi = new FileInfo("test.wasm");
            string mimeType = fi.MimeType();
            Assert.AreEqual("application/wasm", mimeType, "Cannot find webassembly");
        }

        [TestMethod]
        public void TestMarkDown()
        {
            FileInfo fi = new FileInfo("test.md");
            string mimeType = fi.MimeType();
            Assert.AreEqual("text/markdown", mimeType, "Cannot find markdown");

            fi = new FileInfo("test.markdown");
            mimeType = fi.MimeType();
            Assert.AreEqual("text/markdown", mimeType, "Cannot find markdown");

            fi = new FileInfo("test.mdown");
            mimeType = fi.MimeType();
            Assert.AreEqual("text/markdown", mimeType, "Cannot find markdown");

            fi = new FileInfo("test.mkd");
            mimeType = fi.MimeType();
            Assert.AreEqual("text/markdown", mimeType, "Cannot find markdown");

            fi = new FileInfo("test.mkdn");
            mimeType = fi.MimeType();
            Assert.AreEqual("text/markdown", mimeType, "Cannot find markdown");
        }

        [TestMethod]
        public void TestNotFound()
        {
            FileInfo fi = new FileInfo("test.notfound");
            string mimeType = fi.MimeTypeOrDefault();
            Assert.AreEqual("application/octet-stream", mimeType, "Cannot find default");
        }

        [TestMethod]
        public void TestAddOrUpdateMime()
        {
            FileInfo fi = new FileInfo("test.aa");
            string orgMime = fi.MimeTypeOrDefault();
            Assert.AreEqual("application/octet-stream", orgMime);
            var b =MimeTypeExtension.MimeTypeExtension.AddOrUpdateMimeType(".aa", "audio/audible");
            Assert.IsTrue(b);
            string newMime = fi.MimeTypeOrDefault();
            Assert.AreNotEqual(orgMime, newMime);
            Assert.AreEqual("audio/audible", newMime);

            
            Assert.Throws<ArgumentNullException>(() =>
            {
                MimeTypeExtension.MimeTypeExtension.AddOrUpdateMimeType(null, "audio/audible");
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                MimeTypeExtension.MimeTypeExtension.AddOrUpdateMimeType(".aa", null);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                MimeTypeExtension.MimeTypeExtension.AddOrUpdateMimeType("aa", "audio/audible");
            });

            Assert.Throws<ArgumentException>(() =>
            {
                MimeTypeExtension.MimeTypeExtension.AddOrUpdateMimeType(".aa", "application");
            });


        }
        
    }
}
