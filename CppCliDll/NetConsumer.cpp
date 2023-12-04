#include "pch.h"
#include "NetConsumer.h"

using namespace System;
using namespace IO;
using namespace Reflection;
using namespace Security::Cryptography;

void NetConsumer::DoSomething()
{
   try
   {
      String^ tpas = safe_cast<String^>(AppContext::GetData(L"TRUSTED_PLATFORM_ASSEMBLIES"));
      Console::WriteLine(L"CppCliDll: Trusted platform assemblies:");
      Console::WriteLine(tpas->Replace(L";", L"\r\n"));
      Console::WriteLine();

      Assembly^ thisAssembly = Assembly::GetExecutingAssembly();
      String^ dirPath = IO::Path::GetDirectoryName(thisAssembly->Location);
      tpas = Path::Combine(dirPath, "System.Security.dll") + L";" + tpas;
      AppContext::SetData(L"TRUSTED_PLATFORM_ASSEMBLIES", tpas);

      Assembly^ assembly = Assembly::Load(L"System.Security");
      Console::WriteLine(L"CppCliDll: Loaded " + assembly->FullName + L" from " + assembly->Location);
      Console::WriteLine();

      FrameworkLib::ProtectedMemoryConsumer::ConsumeProtectedMemory();
   }
   catch (Exception^ ex)
   {
      Console::WriteLine(ex);
   }
}
