using System.Text;
using System.Xml;
using Microsoft.XmlDiffPatch;

namespace XmlCompare
{
    public class XmlDiffGramGenerator
    {
        public static bool Comapare(string sourcePath, string targetPath, out string diffGram)
        {
            var dg = new StringBuilder();
            var diff = new XmlDiff(XmlDiffOptions.IgnoreChildOrder | XmlDiffOptions.IgnoreWhitespace | XmlDiffOptions.IgnoreComments | XmlDiffOptions.IgnorePrefixes);

            bool same;
            using (var diffGramWriter = XmlWriter.Create(dg))
            {
                same = diff.Compare(sourcePath, targetPath, false, diffGramWriter);
            }

            diffGram = dg.ToString();

            return same;
        }
    }
}