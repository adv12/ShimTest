using System.Reflection;


var tpas = (string?)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES");
Console.WriteLine("CSharpApp: Trusted platform assemblies:");
Console.WriteLine(tpas.Replace(";", "\r\n"));
Console.WriteLine();

Assembly assembly = Assembly.Load("System.Security");
Console.WriteLine($"CSharpApp: Loaded {assembly.FullName} from {assembly.Location}");

Console.WriteLine();

FrameworkLib.ProtectedMemoryConsumer.ConsumeProtectedMemory();
