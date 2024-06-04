using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Globalization;
namespace LinqToActiveDirectory
{
  public interface IDirectorySource
  {
    TextWriter Log { get; }
    DirectoryEntry Root { get; }
    SearchScope Scope { get; }
    Type OriginalType { get; }
  }
}