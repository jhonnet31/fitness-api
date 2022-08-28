using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;

namespace my_api
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            throw new NotImplementedException();
        }
    }
}
