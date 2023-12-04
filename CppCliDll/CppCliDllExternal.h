#pragma once
#ifndef CppCliDll_DllAccess
#ifdef _EXPORTMAPPING
#define CppCliDll_DllAccess _declspec(dllexport)
#else
#define CppCliDll_DllAccess _declspec(dllimport)
#endif 
#endif
