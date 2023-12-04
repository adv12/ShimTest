using System.Reflection;
using dnlib.DotNet;
using TypeAttributes = dnlib.DotNet.TypeAttributes;

string stringPath = typeof(string).Assembly.Location;
string? dirPath = Path.GetDirectoryName(stringPath);
if (dirPath == null)
{
   return;
}

string securityPath = Path.Combine(dirPath, "System.Security.dll");

var mod = ModuleDefMD.Load(securityPath);
var classesMod = ModuleDefMD.Load(typeof(System.Security.Cryptography.ProtectedMemory).Assembly.Location);
string ns = "System.Security.Cryptography";
var mpsTypeDef = classesMod.Types.First(t => t.Namespace == ns && t.Name == "MemoryProtectionScope");
var pmTypeDef = classesMod.Types.First(t => t.Namespace == ns && t.Name == "ProtectedMemory");

var impl = new AssemblyRefUser(classesMod.Assembly);
mod.ExportedTypes.Add(new ExportedTypeUser(classesMod, mpsTypeDef.Rid, ns, "MemoryProtectionScope", TypeAttributes.Forwarder, impl));
mod.ExportedTypes.Add(new ExportedTypeUser(classesMod, pmTypeDef.Rid, ns, "ProtectedMemory", TypeAttributes.Forwarder, impl));
mod.Assembly.Version = new Version(5, 0, 0, 0);

string thisLocation = Assembly.GetExecutingAssembly().Location;
string solutionPath = thisLocation.Substring(0, thisLocation.IndexOf(@"ShimBuilder\", StringComparison.InvariantCultureIgnoreCase));
mod.Write(Path.Combine(solutionPath, "System.Security.dll"));