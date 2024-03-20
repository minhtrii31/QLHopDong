using System;
using System.Collections.Generic;

namespace QLHopDong.Models;

public partial class Contract
{
    public string ContractId { get; set; }

    public string ContractName { get; set; }

    public string ContractType { get; set; }

    public DateOnly? ContractStart { get; set; }

    public DateOnly? ContractEnd { get; set; }

    public virtual ICollection<ContractDetail> ContractDetails { get; set; } = new List<ContractDetail>();

    public virtual ICollection<Term> Terms { get; set; } = new List<Term>();
}
