using Microsoft.WebPages.Compilation;

namespace MvcApplication2
{
    public static class PreStartCode
    {
        public static void Starting()
        {
            CodeGeneratorSettings.AddGlobalImport("System.Globalization");
        }
    }
}