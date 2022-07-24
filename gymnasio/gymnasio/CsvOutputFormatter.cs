using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.Text;

namespace gymnasio
{
    public class CsvOutputFormatter : TextOutputFormatter
    {

        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);

        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            if (context.Object is System.Collections.IEnumerable && !(context.Object is string))
            {
                foreach (var item in (System.Collections.IEnumerable)context.Object)
                {
                    FormatCsv(buffer,item);
                }
            }
            else {
                FormatCsv(buffer, context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }

        public static void FormatCsv(StringBuilder buffer, object dtoObject) {
            if (dtoObject == null) return;

            var properties=dtoObject.GetType().GetProperties();
            foreach (var property in properties)
            {
                buffer.Append($"{property.GetValue(dtoObject)},"); 
            }
            buffer.Remove(buffer.Length-1,1);
            buffer.AppendLine();



        }
    }
}
