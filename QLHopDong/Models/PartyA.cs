using System;
using System.Collections.Generic;

namespace QLHopDong.Models;

public partial class PartyA
{
    public string PartyAid { get; set; }

    public string PartyAname { get; set; }

    public string PartyAaddress { get; set; }

    public string PartyAcontact { get; set; }

    public string PartyAaccount { get; set; }

    public string PartyAtax { get; set; }

    public string PartyArepresentive { get; set; }

    public string PartyAposition { get; set; }

    public virtual ICollection<ContractDetail> ContractDetails { get; set; } = new List<ContractDetail>();
}
