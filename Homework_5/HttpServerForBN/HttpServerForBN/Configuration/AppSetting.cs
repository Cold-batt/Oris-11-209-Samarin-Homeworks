namespace HttpServerForBN.Configuration;


public class AppSetting
{
    public string Address { get; set; }
    public int Port { get; set; }
    
    public string StaticFilesPath { get; set; }
    
    public int EmailPort { get; set; }
    
}