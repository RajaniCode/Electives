using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;

namespace QueryOutlook
{
  class Program
  {
    static void Main(string[] args)
    {
      _Application outlook = new Application();
      if (outlook.ActiveExplorer() == null)
      {
        Console.WriteLine("open outlook and try again");
        Console.ReadLine();
        return;
      }

      MAPIFolder inbox = 
        outlook.ActiveExplorer().Session
          .GetDefaultFolder(OlDefaultFolders.olFolderInbox);
      MAPIFolder contacts = 
        outlook.ActiveExplorer().Session
          .GetDefaultFolder(OlDefaultFolders.olFolderContacts);

      var emails = from email in inbox.Items.OfType<MailItem>()
                   select email;

      var contactList = from contact in contacts.Items.OfType<ContactItem>()
                   select contact;

      var emailsToAdd = (from email in emails
                        let existingContacts = from contact in contactList
                                               select contact.Email1Address
                        where !existingContacts.Contains(email.SenderEmailAddress)
                        orderby email.SenderName
                        select new { email.SenderName, email.SenderEmailAddress }).Distinct();


      Array.ForEach(emailsToAdd.ToArray(), e => 
        {
          ContactItem contact = (ContactItem)outlook.CreateItem(OlItemType.olContactItem);
          contact.Email1Address = e.SenderEmailAddress;
          contact.Email1DisplayName = e.SenderName;
          contact.FileAs = e.SenderName;
          try
          {
            contact.Save();
          }
          catch (COMException ex)
          {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
          }
          Console.WriteLine("Adding: {0}", e.SenderName);
        }
      );
      Console.ReadLine();
    }
  }
}
