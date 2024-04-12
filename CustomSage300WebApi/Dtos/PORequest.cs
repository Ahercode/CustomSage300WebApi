namespace CustomSage300WebApi.Dtos;

public class PORequest
{
       public decimal PORISEQ { get; set; }
        public decimal AUDTDATE { get; set; }
        public decimal AUDTTIME { get; set; }
        public string AUDTUSER { get; set; }
        public string AUDTORG { get; set; }
        public short OPERATION { get; set; }
        public decimal DATE { get; set; }
        public decimal POSTDATE { get; set; }
        public short ISCOMPLETE { get; set; }
        public decimal DTCOMPLETE { get; set; }
        public string CURRENCY { get; set; }
        public short ISPRINTED { get; set; }
        public string PONUMBER { get; set; }
        public string LASTRECEIP { get; set; }
        public string DESCRIPTIO { get; set; }
        public string REFERENCE { get; set; }
        public string VDCODE { get; set; }
        public string VDNAME { get; set; }
        public decimal SCAMOUNT { get; set; }
        public decimal FCAMOUNT { get; set; }
        public string AGFISCYEAR { get; set; }
        public string TRCURRENCY { get; set; }   
}