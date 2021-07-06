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
            Assert.AreEqual(mimeType, "image/jpeg");
        }

        [TestMethod]
        public void TestLoadExtension()
        {
            string fileName = "test.jpg";
            FileInfo fi = new FileInfo(fileName);
            string mimeType = fi.MimeType();
            Assert.AreEqual(mimeType, "image/jpeg");
        }
        [TestMethod]
        public void TestJpegExtension()
        {
            FileInfo fi = new FileInfo("test.jpeg");
            string mimeType = fi.MimeType();
            Assert.AreEqual(mimeType, "image/jpeg","cannot find MimeType for JPEG");
        }
        [TestMethod]
        public void TestPPTExtension()
        {
            FileInfo fi = new FileInfo("test.pptx");
            string mimeType = fi.MimeType();
            Assert.AreEqual(mimeType, "application/vnd.openxmlformats-officedocument.presentationml.presentation", "Cannot find MIME-Type for PPTX");
           
        }

        [TestMethod]
        public void TestWasmExtension()
        {
            FileInfo fi = new FileInfo("test.wasm");
            string mimeType = fi.MimeType();
            Assert.AreEqual(mimeType, "application/wasm", "Cannot find webassembly");
        }

        [TestMethod]
        public void TestNotFound()
        {
            FileInfo fi = new FileInfo("test.notfound");
            string mimeType = fi.MimeTypeOrDefault();
            Assert.AreEqual(mimeType, "application/octet-stream", "Cannot find default");
        }

        [TestMethod]
        public void TestAddOrUpdateMime()
        {
            FileInfo fi = new FileInfo("test.aa");
            string orgMime = fi.MimeTypeOrDefault();
            Assert.AreEqual(orgMime, "application/octet-stream");
            var b =MimeTypeExtension.MimeTypeExtension.AddOrUpdateMimeType(".aa", "audio/audible");
            Assert.IsTrue(b);
            string newMime = fi.MimeTypeOrDefault();
            Assert.AreNotEqual(orgMime, newMime);
            Assert.AreEqual(newMime, "audio/audible");
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                MimeTypeExtension.MimeTypeExtension.AddOrUpdateMimeType(null, "audio/audible");
            });

            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                MimeTypeExtension.MimeTypeExtension.AddOrUpdateMimeType(".aa", null);
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                MimeTypeExtension.MimeTypeExtension.AddOrUpdateMimeType("aa", "audio/audible");
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                MimeTypeExtension.MimeTypeExtension.AddOrUpdateMimeType(".aa", "application");
            });


        }
        
    }
}
