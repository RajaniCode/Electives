using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NorthWind.Business.EF.Miscellaneos
{
    public partial class Candidate
    {
        private XElement candidateresume = null;
        public XElement CandidateResume
        {
            get
            {
                if (candidateresume == null)
                {
                    candidateresume = XElement.Parse(this.Resume);
                    candidateresume.Changed += (sender, eventargs) =>
                    {
                        if (eventargs.ObjectChange == XObjectChange.Add)
                        {
                            this.Resume = candidateresume.ToString();
                        }
                    };    
                }
                return candidateresume;
            }
            set
            {
                candidateresume = value;
                this.Resume = value.ToString();
            }
        }
    }
}
