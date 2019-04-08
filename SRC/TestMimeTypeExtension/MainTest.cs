using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MimeTypeExtension;


namespace TestMimeTypeExtension
{
    [TestClass]
    public class MainTest
    {
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
        
    }
}
