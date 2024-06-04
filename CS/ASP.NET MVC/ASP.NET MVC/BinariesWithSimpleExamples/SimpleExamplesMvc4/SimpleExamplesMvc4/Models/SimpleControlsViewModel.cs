using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVCControlsToolkit.DataAnnotations;
namespace SimpleExamples.Models
{
    public class SimpleControlsViewModel
    {
        public static List<RoleInBlog> AllRoles = new List<RoleInBlog>
        {
           new RoleInBlog{Code=1, Name="Administrator", GroupCode=null, GroupName=null},
           new RoleInBlog{Code=2, Name="Editor" , GroupCode=1, GroupName="Internal"},
           new RoleInBlog{Code=3, Name="Revisor" , GroupCode=2, GroupName="External"},
           new RoleInBlog{Code=4, Name="Contributor" , GroupCode=2, GroupName="External"},

        };
        [DisplayName("Roles in Blog")]
        public List<int> Roles { get; set; }

        [DisplayName("Roles in Blog")]
        public List<int> Roles1 { get; set; }

        [DisplayName("Roles in Blog"), Required]
        public List<int> Roles2 { get; set; }

        [Display(Name = "Roles in Blog", Prompt = "Choose a Role"), Format(NullDisplayText = "No Role selected", Prefix = "Selected Role is: ")]
        public int SingleRole { get; set; }

        public string Selection { get; set; }

        [DateRange(DynamicMaximum = "Stop", RangeAction = RangeAction.Propagate,
            DynamicMaximumDelay = "Delay", SMaximum = "2015-1-1", SMinimum = "2008-1-1"), DisplayFormat(DataFormatString = "{0:G}")]
        public DateTime Start { get; set; }

        [MileStone]
        public TimeSpan Delay { get; set; }
        public TimeSpan InvDelay { get { return -Delay; } }

        [DateRange(DynamicMinimum = "Start", SMaximum = "2016-1-1", SMinimum = "2008-1-1", DynamicMinimumDelay = "InvDelay", RangeAction = RangeAction.Propagate)]
        public DateTime Stop { get; set; }

        public PersonalInfos PersonalData { get; set; }
    }
}