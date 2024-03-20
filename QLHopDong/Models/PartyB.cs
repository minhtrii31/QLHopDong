using System;
using System.Collections.Generic;

namespace QLHopDong.Models;

public partial class PartyB
{
    public string PartyBid { get; set; }

    public string PartyBname { get; set; }

    public string PartyBaddress { get; set; }

    public string PartyBcontact { get; set; }

    public string PartyBaccount { get; set; }

    public string PartyBtax { get; set; }

    public string PartyBrepresentive { get; set; }

    public string PartyBposition { get; set; }

    public virtual ICollection<ContractDetail> ContractDetails { get; set; } = new List<ContractDetail>();
}
