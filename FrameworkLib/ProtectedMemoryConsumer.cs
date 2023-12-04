using System;
using System.Reflection;
using System.Security.Cryptography;

namespace FrameworkLib
{
   public class ProtectedMemoryConsumer
   {
      public static void ConsumeProtectedMemory()
      {
         Assembly assembly = typeof(ProtectedMemory).Assembly;
         Console.WriteLine($"FrameworkLib: Loaded {assembly.FullName} from {assembly.Location}");
         Console.WriteLine();
      }
   }
}
