using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using HttpServerForBN.Attributes;
using HttpServerForBN.Configuration;


namespace HttpServerForBN.Handlers;

public class ControllersHandler: Handler
{
    private string toEmail = "";
    private string toPassword = "";
    public override void HandleRequest(HttpListenerContext _httpContext)
    {
        var uriSegments = _httpContext.Request.Url!.Segments;
        var strParams = uriSegments
            .Skip(1)
            .Select(s => s.Replace("/", ""))
            .ToArray();

        if (strParams.Length < 2)
            throw new ArgumentNullException("мало аргументов");
        var controllerName = strParams[0];
        var methodName = strParams[1];
        
        // string.Equals(c.Name, controllerName, StringComparison.CurrentCultureIgnoreCase)

        var assembly = Assembly.GetExecutingAssembly();
        var controller = assembly
            .GetTypes()
            .Where(t => Attribute.IsDefined(t, typeof(HttpController)))
            .FirstOrDefault(c =>
                ((HttpController)Attribute.GetCustomAttribute(c, typeof(HttpController))!).Name.Equals(controllerName));
        
        if (controller == null) return;
        // var method = controller
        //     .GetMethods()
        //     .FirstOrDefault(t => t.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));
        var method = controller
            .GetMethods()
            .FirstOrDefault(x => x.GetCustomAttributes(true)
                .Any(attr => attr.GetType().Name.Equals($"{_httpContext.Request.HttpMethod}Attribute",
                                 StringComparison.OrdinalIgnoreCase) && 
                             ((HttpMethodAttribute)attr).ActionName.Equals(methodName, StringComparison.OrdinalIgnoreCase)));


        // using var reader = new StreamReader(_httpContext.Request.InputStream);
        // var data = reader.ReadToEnd();
        // Console.WriteLine(data);
        // var formData = HttpUtility.ParseQueryString(data);
        // toEmail = formData["email"];
        // toPassword = formData["password"];
        //
        // var emailParams = new [] {formData["email"], formData["password"]}
        

        object[] queryParams = method.GetParameters()
            .Select((p, i) => Convert.ChangeType(strParams[i], p.ParameterType))
            .ToArray();

        var result  = method.Invoke(Activator.CreateInstance(controller), queryParams);
        var response = _httpContext.Response;
        byte[] buffer = Encoding.UTF8.GetBytes((string)result);
        response.ContentLength64 = buffer.Length;
        using Stream output = response.OutputStream;
        output.Write(buffer);
        output.Flush();
    }
}