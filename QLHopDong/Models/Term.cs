using System;
using System.Collections.Generic;

namespace QLHopDong.Models;

public partial class Term
{
    public string TermId { get; set; }

    public string ContractId { get; set; }

    public string TermDetail { get; set; }

    public virtual Contract Contract { get; set; }
}
