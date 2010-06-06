using System;
using Yahoo.Yui.Compressor;

namespace SquishIt.Framework.JavaScript.Minifiers
{
    public class YuiMinifier: IJavaScriptCompressor
    {
        string IJavaScriptCompressor.Identifier
        {
            get { return Identifier; }
        }
        
        public static string Identifier
        {
            get { return "YuiJavaScriptCompressor"; }
        }

        public string CompressContent(string content)
        {
            string pattern = "(?<!\\\")debugger(?<!\\\");";
            string replacement = "eval(\"debugger;\");";
            var regex = new System.Text.RegularExpressions.Regex(pattern);
            content = regex.Replace(content, replacement);
            return JavaScriptCompressor.Compress(content);
        }
    }
}