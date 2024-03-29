﻿using System;
using System.IO;
using System.Linq;
using EasyXMLSerializer;
using MimeTypeExtension;

//using ZeroDep;

namespace MimeExtensionCompere
{
    class Program
    {
        static void Main(string[] args)
        {
            EasyXMLSerializer.SerializeTool serTool = new SerializeTool("Default.xml");

            StaticContent context = serTool.ReadXmlFile<StaticContent>();
            string allString = File.ReadAllText("otherTypes.json");
            MimeTypeList list = null;//Json.Deserialize<MimeTypeList>(allString);

            foreach (MimeMap mimeMap in context.MimeMap)
            {
                if (!list.MimeTypes.Any(x => x.Type == mimeMap.FileExtension))
                {
                    list.MimeTypes.Add(new MimeType(){Mime=mimeMap.MimeType, Type = mimeMap.FileExtension});
                }
                else
                {
                    var item = list.MimeTypes.Find(x => x.Type == mimeMap.FileExtension);
                    if (item.Mime != mimeMap.MimeType)
                    {
                        Console.WriteLine($"type:{item.Type} => source={mimeMap.MimeType} => dest={item.Mime}");
                    }

                }
            }




            MimeType[] mt = list.MimeTypes.ToArray();
            var ol = mt.OrderBy(x => x.Type);
            var  olist = ol.ToList();
            list.MimeTypes = olist;

            string output = string.Empty;//Json.Serialize(list);
            File.WriteAllText("output.json", output);

            Console.ReadLine();

        }
    }
}
