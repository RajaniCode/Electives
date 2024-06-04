using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml.Linq;
using System.Data.Metadata.Edm;
using System.Data.Entity.Design;
using System.Data.Mapping;
using NorthWind.Business.EF.EagerLoading;
namespace LinqCookBook.ViewGeneration
{
    public class Example1
    {
        static string csdlNamespace = "http://schemas.microsoft.com/ado/2006/04/edm";
        static string ssdlNamespace = "http://schemas.microsoft.com/ado/2006/04/edm/ssdl";
        static string mslNamespace = "urn:schemas-microsoft-com:windows:storage:mapping:CS";
        public static void Run()
        {
            GeneratingViewsProgramatically();
            DummyQuery();
        }

        private static void DummyQuery()
        {
            var db = new IncludeTPTEntities();
            db.Contacts.First();
            Stopwatch watch = new Stopwatch();
            watch.Start();
            //orignal query
            var gunsmiths = db.Contacts.OfType<GunSmith>()
                              .Include("Company.Phone")
                              .Include("Company.Departments").ToList();
            watch.Stop();
            Console.WriteLine("Gunsmith Time taken:{0}", watch.ElapsedMilliseconds);
        }

        private static void GeneratingViewsProgramatically()
        {
            var edmx = XElement.Load(@"..\..\IncludeTPT.edmx");
            var csdl = GetCsdl(edmx);
            var ssdl = GetSsdl(edmx);
            var msl = GetMsl(edmx);
            IList<EdmSchemaError> cerrors, serrors, merrors = null;
            EdmItemCollection edmitems = MetadataItemCollectionFactory.CreateEdmItemCollection(new[] { csdl.CreateReader() }, out cerrors);

            StoreItemCollection sitems = MetadataItemCollectionFactory.CreateStoreItemCollection(new[] { ssdl.CreateReader() }, out serrors);

            StorageMappingItemCollection mapping = MetadataItemCollectionFactory.CreateStorageMappingItemCollection
                (edmitems, sitems, new[] { msl.CreateReader() }, out merrors);

            EntityViewGenerator evg = new EntityViewGenerator(LanguageOption.GenerateCSharpCode);
            evg.GenerateViews(mapping, "Views.cs");
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var db = new IncludeTPTEntities();
            var gunsmiths = db.Contacts.OfType<GunSmith>()
                              .Include("Company.Phone")
                              .Include("Company.Departments").ToList();
            watch.Stop();
            Console.WriteLine("Gunsmith Time taken:{0}", watch.ElapsedMilliseconds);
        }
        private static XElement GetMsl(XElement edmx)
        {
            return (from item in edmx.Descendants(
                      XName.Get("Mapping", mslNamespace))
                    select item).First();
        }

        private static XElement GetSsdl(XElement edmx)
        {
            return (from item in edmx.Descendants(
                       XName.Get("Schema", ssdlNamespace))
                    select item).First();
        }

        private static XElement GetCsdl(XElement edmx)
        {

            return (from item in edmx.Descendants(XName.Get("Schema", csdlNamespace))
                    select item).First();
        }
    }
}
