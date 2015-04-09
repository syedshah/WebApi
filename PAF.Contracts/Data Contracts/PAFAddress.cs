using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace PAF.Contracts
{
   
    [DataContract(Namespace = "")]
    public class PAFAddress
    {
        private string _address1;
        private string _address2;
        private string _address3;
        private string _address4;
        private string _address5;
        private string _town;
        private string _postCode;
        private string _county;
        private string _country;
       

        /// <summary>
        /// explicitly setting vlaues for xml format
        /// </summary>
        [DataMember(Order = 0)]
        public string Address1
        {
            get { return this._address1 ?? ""; }
            set { _address1 = value; }
        }

        [DataMember(Order = 1)]
        public string Address2
        {
            get { return _address2 ?? ""; }
            set { _address2 = value; }
        }

        [DataMember(Order = 2)]
        public string Address3
        {
            get { return _address3 ?? ""; }
            set { _address3 = value; }
        }

        [DataMember(Order = 3)]
        public string Address4
        {
            get { return _address4 ?? ""; }
            set { _address4 = value; }
        }
        
        [DataMember(Order = 4)]
        public string Address5
        {
            get { return _address5 ?? ""; }
            set { _address5 = value; }
        }

        [DataMember(Order = 5)]
        public string Town
        {
            get { return _town ?? ""; }
            set { _town = value; }
        }

        [DataMember(Order = 6)]
        public string PostCode
        {
            get { return _postCode ?? ""; }
            set { _postCode = value; }
        }

        

        //[DataMember(Order = 7)]
        //public string County
        //{
        //    get { return _county ?? ""; }
        //    set { _county = value; }
        //}

        //[DataMember(Order = 8)]
        //public string Country
        //{
        //    get { return _country ?? ""; }
        //    set { _country = value; }
        //}
    }
}
