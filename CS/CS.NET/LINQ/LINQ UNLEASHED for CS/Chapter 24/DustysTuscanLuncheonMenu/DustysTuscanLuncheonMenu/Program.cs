using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using www.dustyscellar.com.TuscanLuncheon;

namespace DustysTuscanLuncheonMenu
{
  class Program
  {
    static void Main(string[] args)
    {
      var dustys = Dustys.Load("../../Menu.xml");
      var menu = from lunchMenu in dustys.Luncheon
                 from item in lunchMenu.Item
                 let cost = lunchMenu.Price * 8 * 1.06
                 let days = lunchMenu.LimitedByDays
                 where days.LimitedByDayOfWeek.Contains("Sunday")
                 select new {MenuItem=item.Name, 
                   Description=item.Description, 
                   Cost=string.Format("{0:C}", cost)};


      Array.ForEach(menu.ToArray(), m=>Console.WriteLine(m));
      Console.ReadLine();

    }
  }
}
