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
  public class DirectoryEntity : INotifyPropertyChanged
  {
    /// <summary>
    /// Wrapped DirectoryEntry.
    /// </summary>
    private DirectoryEntry directoryEntry;

    /// <summary>
    /// Gets/sets the underlying DirectoryEntry.
    /// </summary>
    protected internal DirectoryEntry DirectoryEntry
    {
      get { return directoryEntry; }
      set { directoryEntry = value; }
    }

    /// <summary>
    /// Event raised when a property on a subclass (= strongly typed entity) has been changed.
    /// This is used for change tracking.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Raises the PropertyChanged event for the specified entity property.
    /// </summary>
    /// <param name="propertyName">Entity property that has been changed.</param>
    protected void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}