using System;
using System.Collections.Generic;

namespace QLHopDong.Models;

public partial class ContractDetail
{
    public string ContractDetailId { get; set; }

    public string ContractId { get; set; }

    public string ContractDetailContent { get; set; }

    public int? ContractDetailValue { get; set; }

    public string ContractDetailStatus { get; set; }

    public int? ContractDetailResign { get; set; }

    public string PartyAid { get; set; }

    public string PartyBid { get; set; }

    public virtual Contract Contract { get; set; }

    public virtual PartyA PartyA { get; set; }

    public virtual PartyB PartyB { get; set; }
}
