using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  Entities;

namespace PAF.Web.Models
{
    public class LocalityViewModel
    {
        public LocalityViewModel()
        {
            this.Localities = new List<LocalityViewModel>();
        }

        public LocalityViewModel(Locality locality)
        {
            //this.LocalityId = locality.LocalityID;
            this.Outcode = locality.Outcode;
            this.Incode = locality.Incode;
            this.PostCodeType = locality.PostCodeType;
            this.PostTown = locality.PostTown;
            this.DepLocality = locality.DepLocality;
            this.DoubleDepLocality = locality.DoubleDepLocality;
            this.PostTownTidy = locality.PostTownTidy;
            this.DepLocalityTidy = locality.DepLocalityTidy;
        }

        public void AddLocalities(IList<Locality> entity)
        {
           entity.ToList().ForEach(x=>
               this.Localities.Add(new LocalityViewModel()
               {
                   //LocalityId = x.LocalityID,
                   Outcode =  x.Outcode,
                   Incode =  x.Incode,
                   PostCodeType = x.PostCodeType,
                   PostTown = x.PostTown,
                   DepLocality = x.DepLocality,
                   DoubleDepLocality = x.DoubleDepLocality,
                   PostTownTidy = x.PostTownTidy,
                   DepLocalityTidy = x.DepLocalityTidy
               }));  
        }

        public int? LocalityId { get; set; }

        public String Outcode { get; set; }

        public String Incode { get; set; }

        public String PostCodeType { get; set; }

        public String PostTown { get; set; }

        public String DepLocality { get; set; }

        public String DoubleDepLocality { get; set; }

        public String PostTownTidy { get; set; }

        public String DepLocalityTidy { get; set; }

        public IList<LocalityViewModel> Localities { get; set; }

       
    }
}