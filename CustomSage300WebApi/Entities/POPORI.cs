using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CustomSage300WebApi.Entities;

[Table("POPORI")]
[Index("PORHSEQ", Name = "KEY_1")]
public partial class POPORI
{
    [Key]
    [Column(TypeName = "decimal(19, 0)")]
    public decimal PORISEQ { get; set; }

    [Column(TypeName = "decimal(9, 0)")]
    public decimal AUDTDATE { get; set; }

    [Column(TypeName = "decimal(9, 0)")]
    public decimal AUDTTIME { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string AUDTUSER { get; set; } = null!;

    [StringLength(6)]
    [Unicode(false)]
    public string AUDTORG { get; set; } = null!;

    public short OPERATION { get; set; }

    [Column(TypeName = "decimal(9, 0)")]
    public decimal DATE { get; set; }

    [Column(TypeName = "decimal(9, 0)")]
    public decimal POSTDATE { get; set; }

    public short ISCOMPLETE { get; set; }

    [Column(TypeName = "decimal(9, 0)")]
    public decimal DTCOMPLETE { get; set; }

    [Column(TypeName = "decimal(19, 0)")]
    public decimal PORHSEQ { get; set; }

    [StringLength(3)]
    [Unicode(false)]
    public string CURRENCY { get; set; } = null!;

    public short TAXCLASS1 { get; set; }

    public short TAXCLASS2 { get; set; }

    public short TAXCLASS3 { get; set; }

    public short TAXCLASS4 { get; set; }

    public short TAXCLASS5 { get; set; }

    [Column(TypeName = "decimal(19, 3)")]
    public decimal SCDOCTOTAL { get; set; }

    public short ISPRINTED { get; set; }

    [StringLength(22)]
    [Unicode(false)]
    public string PONUMBER { get; set; } = null!;

    [StringLength(22)]
    [Unicode(false)]
    public string LASTRECEIP { get; set; } = null!;

    public short RCPCOUNT { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string DESCRIPTIO { get; set; } = null!;

    [StringLength(60)]
    [Unicode(false)]
    public string REFERENCE { get; set; } = null!;

    public short HASRQNDATA { get; set; }

    public short PORTYPE { get; set; }

    public short ONHOLD { get; set; }

    [StringLength(22)]
    [Unicode(false)]
    public string RQNNUMBER { get; set; } = null!;

    [Column(TypeName = "decimal(19, 0)")]
    public decimal RQNHSEQ { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string VDCODE { get; set; } = null!;

    [StringLength(60)]
    [Unicode(false)]
    public string VDNAME { get; set; } = null!;

    [Column(TypeName = "decimal(15, 7)")]
    public decimal RATE { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string RATETYPE { get; set; } = null!;

    [Column(TypeName = "decimal(9, 0)")]
    public decimal RATEDATE { get; set; }

    public short RATEOPER { get; set; }

    public short RATEOVER { get; set; }

    public short SCURNDECML { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string TAXGROUP { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string TAXAUTH1 { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string TAXAUTH2 { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string TAXAUTH3 { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string TAXAUTH4 { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string TAXAUTH5 { get; set; } = null!;

    [Column(TypeName = "decimal(19, 3)")]
    public decimal SCAMOUNT { get; set; }

    [Column(TypeName = "decimal(19, 3)")]
    public decimal FCAMOUNT { get; set; }

    public short HASJOB { get; set; }

    public short AGENTTTYPE { get; set; }

    [Column(TypeName = "decimal(19, 0)")]
    public decimal AGENTHSEQ { get; set; }

    [Column(TypeName = "decimal(19, 0)")]
    public decimal AGTRANSNUM { get; set; }

    [StringLength(22)]
    [Unicode(false)]
    public string AGDOCNUM { get; set; } = null!;

    [StringLength(22)]
    [Unicode(false)]
    public string AGSRCDOC { get; set; } = null!;

    public short AGMULTIDOC { get; set; }

    [Column(TypeName = "decimal(9, 0)")]
    public decimal AGDATE { get; set; }

    [StringLength(4)]
    [Unicode(false)]
    public string AGFISCYEAR { get; set; } = null!;

    public short AGFISCPER { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string AGDESC { get; set; } = null!;

    [StringLength(60)]
    [Unicode(false)]
    public string AGREF { get; set; } = null!;

    [StringLength(3)]
    [Unicode(false)]
    public string TRCURRENCY { get; set; } = null!;

    [Column(TypeName = "decimal(15, 7)")]
    public decimal RATERC { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string RATETYPERC { get; set; } = null!;

    [Column(TypeName = "decimal(9, 0)")]
    public decimal RATEDATERC { get; set; }

    public short RATEOPERRC { get; set; }

    public short RATERCOVER { get; set; }

    public short RCURNDECML { get; set; }
}
