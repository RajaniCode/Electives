// Functi onPointer.cpp : main project file.

#include "stdafx.h"

using namespace System;

typedef void (*FunctionPointer)(System::String ^str);

void HelloWorld(System::String ^str)
{
    Console::WriteLine(str);
	Console::ReadLine();
}

int main(array<System::String ^> ^args)
{
	FunctionPointer fp = HelloWorld;
	fp(L"Hello World");
	return 0;
}

